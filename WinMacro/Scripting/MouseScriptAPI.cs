using WinMacro.WinAPI.Mouse;
using static WinMacro.WinAPI.Mouse.MouseEventAPI;
using static WinMacro.WinAPI.Mouse.MouseEventFlag;

namespace WinMacro.Scripting
{
    public static class MouseScriptAPI
    {
        public const int WHEEL_DELTA = 120;

        public static void LeftClick()
        {
            MouseEvent(MOUSEEVENTF_LEFTDOWN);
            MouseEvent(MOUSEEVENTF_LEFTUP);
        }

        public static void RightClick()
        {
            MouseEvent(MOUSEEVENTF_RIGHTDOWN);
            MouseEvent(MOUSEEVENTF_RIGHTUP);
        }

        public static void MiddleClick()
        {
            MouseEvent(MOUSEEVENTF_MIDDLEDOWN);
            MouseEvent(MOUSEEVENTF_MIDDLEUP);
        }

        public static void MouseButton4()
        {
            MouseEvent(MOUSEEVENTF_XDOWN, (int)MouseEventDataXButton.XBUTTON1);
            MouseEvent(MOUSEEVENTF_XUP, (int)MouseEventDataXButton.XBUTTON1);
        }

        public static void MouseButton5()
        {
            MouseEvent(MOUSEEVENTF_XDOWN, (int)MouseEventDataXButton.XBUTTON2);
            MouseEvent(MOUSEEVENTF_XUP, (int)MouseEventDataXButton.XBUTTON2);
        }

        public static void DoubleClick()
        {
            LeftClick();
            LeftClick();
        }

        public static void ScrollDown()
        {
            MouseEvent(MOUSEEVENTF_WHEEL, WHEEL_DELTA);
        }

        public static void ScrollUp()
        {
            MouseEvent(MOUSEEVENTF_WHEEL, -WHEEL_DELTA);
        }
    }
}
