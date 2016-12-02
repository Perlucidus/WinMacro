using System;
using System.Windows.Forms;
using WinMacro.Macro.Function;

namespace WinMacro.GUI
{
    public partial class MouseActionForm : Form
    {
        public MouseActionType Action;

        public MouseActionForm(MouseActionType action)
        {
            InitializeComponent();
            Action = action;
        }

        private void OnLoad(Object sender, EventArgs e)
        {
            m_actionType.SelectedIndex = (int)Action;
        }

        private void OnActionSelected(Object sender, EventArgs e)
        {
            Action = (MouseActionType)m_actionType.SelectedIndex;
        }

        private void OnFinish(Object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
