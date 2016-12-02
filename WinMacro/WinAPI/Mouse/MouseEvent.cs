namespace WinMacro.WinAPI.Mouse
{
    public struct MouseEvent
    {
        public MouseEventFlag Flags;
        public int X;
        public int Y;
        public uint Data;
        public int ExtraInfo;
    }
}
