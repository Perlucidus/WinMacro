using System.Windows.Forms;
using static WinMacro.WinAPI.Keyboard.KeyboardEventAPI;
using static WinMacro.WinAPI.Keyboard.KeyboardEventFlag;

namespace WinMacro.Scripting
{
    public static class KeyboardScriptAPI
    {
        public static void PressKey(Keys key)
        {
            PressKey((uint)key);
        }

        public static void PressKey(uint vkCode)
        {
            HoldKey(vkCode);
            ReleaseKey(vkCode);
        }

        public static void HoldKey(Keys key)
        {
            HoldKey((uint)key);
        }

        public static void HoldKey(uint vkCode)
        {
            KeyboardEvent(vkCode, KEYEVENTF_EXTENDEDKEY);
        }

        public static void ReleaseKey(Keys key)
        {
            ReleaseKey((uint)key);
        }

        public static void ReleaseKey(uint vkCode)
        {
            KeyboardEvent(vkCode, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP);
        }
    }
}
