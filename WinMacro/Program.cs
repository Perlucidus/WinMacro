using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WinMacro.Data;
using WinMacro.GUI;

namespace WinMacro
{
    public class Program
    {
        public static MainForm MainForm;

        [STAThread]
        static void Main(string[] args)
        {
            //AllocConsole();
            Application.Run(MainForm = new MainForm());
            MacroManager.SaveMacros();
        }

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
