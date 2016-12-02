using System;
using System.Windows.Forms;

namespace WinMacro.GUI
{
    public partial class MacroScriptEditor : Form
    {
        public string Script;

        public MacroScriptEditor(string script)
        {
            InitializeComponent();
            Script = script;
        }

        private void OnLoad(Object sender, EventArgs e)
        {
            m_script.Text = Script;
        }

        private void OnSetScript(Object sender, EventArgs e)
        {
            Script = m_script.Text;
        }
    }
}
