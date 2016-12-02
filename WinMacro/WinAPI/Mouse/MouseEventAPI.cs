using System.Runtime.InteropServices;

namespace WinMacro.WinAPI.Mouse
{
    public static class MouseEventAPI
    {
        public static void MouseEvent(MouseEventFlag flag, int data = 0)
        {
            mouse_event((uint)flag, 0, 0, data, 0);
        }

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
    }
}
