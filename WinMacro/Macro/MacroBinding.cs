using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WinMacro.Data;

namespace WinMacro.Macro
{
    public class MacroBinding : List<uint>, ISerializable
    {
        public bool Symmetric;

        public MacroBinding(bool symmetric = false)
        {
            Symmetric = symmetric;
        }

        public MacroBinding(MacroBinding other)
        {
            Symmetric = other.Symmetric;
            foreach (uint key in other)
                Add(key);
        }

        #region ISerializable Implementation

        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Symmetric);
            writer.Write(Count);
            foreach (uint key in this)
                writer.Write(key);
        }

        public void Deserialize(BinaryReader reader)
        {
            Symmetric = reader.ReadBoolean();
            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
                Add(reader.ReadUInt32());
        }

        #endregion

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is List<uint>)
            {
                List<uint> macro = obj as List<uint>;
                if (macro.Count != Count)
                    return false;
                if (Symmetric)
                {
                    foreach (uint key in macro)
                        if (!Contains(key))
                            return false;
                }
                else
                    for (int i = 0; i < Count; i++) //this could really be better
                        if (macro[i] != this[i])
                            return false;
                //wtf
                List<Keys> keys = new List<Keys>();
                ForEach(x => keys.Add((Keys)x));
                Console.WriteLine($"Executing: {string.Join(",", keys)}");
                //
                return true;
            }
            return base.Equals(obj);
        }

        public override string ToString() =>
            String.Join(" + ", this.Select(x => Enum.GetName(typeof(Keys), x))).Replace("Key", "");
    }
}
