using System;
using System.Diagnostics;
using System.IO;

namespace WinMacro.Macro.Function
{
    public class StartProcess : MacroFunction
    {
        public string Path;

        public StartProcess()
        {
            Path = String.Empty;
        }

        public StartProcess(string path)
        {
            Path = path;
        }

        #region ISerializable Implementation

        public override void Serialize(BinaryWriter writer)
        {
            writer.Write(Path);
        }

        public override void Deserialize(BinaryReader reader)
        {
            Path = reader.ReadString();
        }

        #endregion

        public override void Execute()
        {
            Process.Start(Path);
        }

        public override String ToString()
        {
            return Path;
        }

        public override Object Clone()
        {
            return new StartProcess(Path);
        }
    }
}
