using System;
using System.IO;
using System.Windows.Forms;
using static WinMacro.WinAPI.Keyboard.KeyboardEventAPI;
using static WinMacro.WinAPI.Keyboard.KeyboardEventFlag;

namespace WinMacro.Macro.Function
{
    public class KeyboardFunction : MacroFunction
    {
        public uint Key;

        public KeyboardFunction()
        {
            Key = 0;
        }

        public KeyboardFunction(KeyboardFunction other)
        {
            Key = other.Key;
        }
        
        #region ISerializable Implementation

        public override void Serialize(BinaryWriter writer)
        {
            writer.Write(Key);
        }

        public override void Deserialize(BinaryReader reader)
        {
            Key = reader.ReadUInt32();
        }

        #endregion

        public override void Execute()
        {
            KeyboardEvent((byte)Key, KEYEVENTF_EXTENDEDKEY);
            KeyboardEvent((byte)Key, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP);
        }

        public override String ToString()
        {
            return $"KeyPress({Enum.GetName(typeof(Keys), Key)})";
        }

        public override Object Clone()
        {
            return new KeyboardFunction(this);
        }
    }
}
