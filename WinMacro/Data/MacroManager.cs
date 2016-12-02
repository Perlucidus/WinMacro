using LLHook.Keyboard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WinMacro.Macro;
using static LLHook.Keyboard.LowLevelKeyboardHook;

namespace WinMacro.Data
{
    public static class MacroManager
    {
        private const string Path = @"WinMacro\macros.dat";
        private static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static Dictionary<uint, MacroEntry> Macros;
        private static LowLevelKeyboardHook LLKH;
        private static List<uint> CurrentMacro;
        private static object MacroLock;

        public class MacroEntry : ISerializable
        {
            public uint Id;
            public bool Enabled;
            public MacroType Type;
            public MacroBinding Binding;
            public MacroFunction Function;
            public string Description;

            public MacroEntry()
            {
                Binding = new MacroBinding();
            }

            public MacroEntry(MacroEntry other)
            {
                Id = other.Id;
                Enabled = other.Enabled;
                Type = other.Type;
                Binding = new MacroBinding(other.Binding);
                Function = other.Function.Clone() as MacroFunction;
                Description = other.Description;
            }

            public void Serialize(BinaryWriter writer)
            {
                writer.Write(Id);
                writer.Write(Enabled);
                writer.Write((uint)Type);
                Binding.Serialize(writer);
                Function.Serialize(writer);
                writer.Write(Description);
            }

            public void Deserialize(BinaryReader reader)
            {
                Id = reader.ReadUInt32();
                Enabled = reader.ReadBoolean();
                Type = (MacroType)reader.ReadUInt32();
                Binding.Deserialize(reader);
                Function = MacroFunction.FromType(Type);
                Function.Deserialize(reader);
                Description = reader.ReadString();
            }
        }

        static MacroManager()
        {
            Macros = new Dictionary<uint, MacroEntry>();
            LLKH = new LowLevelKeyboardHook();
            CurrentMacro = new List<uint>();
            MacroLock = new object();
            try
            {
                string path = $@"{AppData}\{Path}";
                if (File.Exists(path))
                    using (BinaryReader data = new BinaryReader(new MemoryStream(File.ReadAllBytes(path))))
                    {
                        MacroEntry entry;
                        int count = data.ReadInt32();
                        for (int i = 0; i < count; i++)
                        {
                            entry = new MacroEntry();
                            entry.Deserialize(data);
                            Macros.Add(entry.Id, entry);
                            NextFreeId = Math.Max(NextFreeId, entry.Id + 1);
                        }
                    }
            }
            catch (Exception e)
            {
                Program.MainForm.Notify(e.ToString(), "Loading Error", ToolTipIcon.Error);
            }
            LLKH.KeyboardAction += OnKeyboardAction;
            LLKH.Start();
        }

        public static uint NextFreeId { get; private set; }

        private static void OnKeyboardAction(object sender, KeyboardActionEventArgs e)
        {
            Keys vkCode = (Keys)e.Data.VirtualKeyCode;
            //more research needed:
            if (vkCode == Keys.LControlKey || vkCode == Keys.RControlKey)
                vkCode = Keys.ControlKey;
            if (vkCode == Keys.LShiftKey || vkCode == Keys.RShiftKey)
                vkCode = Keys.ShiftKey;
            if (vkCode == Keys.LMenu || vkCode == Keys.RMenu)
                vkCode = Keys.Menu;
            switch (e.Action)
            {
                case KeyboardAction.KeyDown:
                case KeyboardAction.SysKeyDown:
                    lock (MacroLock)
                    {
                        if (!CurrentMacro.Contains((uint)vkCode))
                            CurrentMacro.Add((uint)vkCode);
                        foreach (MacroEntry entry in Macros.Values.Where(x => x.Enabled))
                            if (entry.Binding.Equals(CurrentMacro))
                            {
                                entry.Function.Execute();
                                e.IsCancelled = true;
                                break;
                            }
                        //wtf
                        Console.WriteLine($"Current macro: {String.Join(",", CurrentMacro)}");
                        //
                    }
                    break;
                case KeyboardAction.KeyUp:
                case KeyboardAction.SysKeyUp:
                    lock (MacroLock)
                        if (CurrentMacro.Count > 0)
                            if (CurrentMacro[0] == (uint)vkCode)
                                CurrentMacro.Clear();
                            else if (CurrentMacro.Last() == (uint)vkCode)
                                CurrentMacro.RemoveAt(CurrentMacro.Count - 1);
                    break;
            }
        }

        public static bool SaveMacros()
        {
            try
            {
                using (MemoryStream data = new MemoryStream())
                using (BinaryWriter writer = new BinaryWriter(data))
                {
                    writer.Write(Macros.Count);
                    foreach (MacroEntry entry in Macros.Values)
                        entry.Serialize(writer);
                    Directory.CreateDirectory(Path);
                    File.WriteAllBytes($@"{AppData}\{Path}", data.ToArray());
                }
            }
            catch (Exception e)
            {
                Program.MainForm.Notify(e.ToString(), "Saving Error", ToolTipIcon.Error);
                return false;
            }
            return true;
        }
    }
}
