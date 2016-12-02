using System.Runtime.InteropServices;

namespace WinMacro.WinAPI.Keyboard
{
    public static class KeyboardEventAPI
    {
        public static void KeyboardEvent(uint vkCode, KeyboardEventFlag flags)
        {
            keybd_event((byte)vkCode, 0x45, (uint)flags, 0);
        }

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
    }
}
