using System;
using System.IO;
using WinMacro.Data;
using WinMacro.Macro.Function;

namespace WinMacro.Macro
{
    public abstract class MacroFunction : ISerializable, ICloneable
    {
        #region ISerializable Implementation

        public abstract void Serialize(BinaryWriter writer);

        public abstract void Deserialize(BinaryReader reader);

        #endregion

        public abstract void Execute();

        public static MacroFunction FromType(MacroType type)
        {
            switch (type)
            {
                case MacroType.KeyboardFunction:
                    return new KeyboardFunction();
                case MacroType.MouseFunction:
                    return new MouseFunction();
                case MacroType.StartProcess:
                    return new StartProcess();
                case MacroType.ExecuteScript:
                    return new ExecuteScript();
                default:
                    return null;
            }
        }

        public override String ToString()
        {
            return "Disabled";
        }

        public abstract Object Clone();
    }
}
