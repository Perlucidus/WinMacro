using System;
using System.IO;
using WinMacro.Scripting;

namespace WinMacro.Macro.Function
{
    public class MouseFunction : MacroFunction
    {
        public MouseActionType Action;

        public MouseFunction()
        {
            Action = MouseActionType.LeftClick;
        }

        public MouseFunction(MouseFunction other)
        {
            Action = other.Action;
        }

        #region ISerializable Implementation

        public override void Serialize(BinaryWriter writer)
        {
            writer.Write((uint)Action);
        }

        public override void Deserialize(BinaryReader reader)
        {
            Action = (MouseActionType)reader.ReadUInt32();
        }

        #endregion

        public override void Execute()
        {
            switch (Action)
            {
                case MouseActionType.LeftClick:
                    MouseScriptAPI.LeftClick();
                    break;
                case MouseActionType.RightClick:
                    MouseScriptAPI.RightClick();
                    break;
                case MouseActionType.ScrollClick:
                    MouseScriptAPI.MiddleClick();
                    break;
                case MouseActionType.MouseButton4:
                    MouseScriptAPI.MouseButton4();
                    break;
                case MouseActionType.MouseButton5:
                    MouseScriptAPI.MouseButton5();
                    break;
                case MouseActionType.DoubleClick:
                    MouseScriptAPI.DoubleClick();
                    break;
                case MouseActionType.ScrollUp:
                    MouseScriptAPI.ScrollUp();
                    break;
                case MouseActionType.ScrollDown:
                    MouseScriptAPI.ScrollDown();
                    break;
            }
        }

        public override String ToString()
        {
            return Action.ToString();
        }

        public override Object Clone()
        {
            return new MouseFunction(this);
        }
    }
}
