using System;
using System.Windows.Forms;
using WinMacro.Macro;
using WinMacro.Macro.Function;
using static WinMacro.Data.MacroManager;

namespace WinMacro.GUI
{
    public partial class MacroSaveForm : Form
    {
        private MacroEntry m_entry;
        private bool m_edit;

        public MacroSaveForm(uint id, MacroEntry entry = null)
        {
            InitializeComponent();
            m_entry = new MacroEntry { Id = id };
            if (entry != null)
            {
                m_edit = true;
                m_entry = new MacroEntry(entry);
            }
        }

        private void OnLoad(Object sender, EventArgs e)
        {
            Text = "Add Macro";
            foreach (string type in Enum.GetNames(typeof(MacroType)))
                m_type.Items.Add(type);
            if (m_edit)
            {
                Text = "Edit Macro";
                m_binding.Text = m_entry.Binding.ToString();
                m_type.SelectedIndex = (int)m_entry.Type;
                m_function.Text = m_entry.Type == MacroType.ExecuteScript ? "Script" : m_entry.Function.ToString();
                m_description.Text = m_entry.Description;
            }
        }

        private void OnSave(Object sender, EventArgs e)
        {
            Save();
            DialogResult = DialogResult.OK;
        }

        private void OnCancel(Object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OnClosing(Object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing || !m_btSave.Enabled)
                return;
            switch (MessageBox.Show("Save changes?", "Closing", MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Yes:
                    Save();
                    DialogResult = DialogResult.OK;
                    break;
                case DialogResult.No:
                    DialogResult = DialogResult.Cancel;
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }

        private void OnBindingKey(Object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            m_entry.Binding.Add((uint)e.KeyCode);
            m_binding.Text = m_entry.Binding.ToString();
        }

        private void OnBindingClear(Object sender, EventArgs e)
        {
            m_entry.Binding.Clear();
            m_binding.Text = String.Empty;
        }

        private void OnFunctionKey(Object sender, KeyEventArgs e)
        {
            if (m_entry.Type == MacroType.KeyboardFunction)
            {
                e.SuppressKeyPress = true;
                (m_entry.Function as KeyboardFunction).Key = (uint)e.KeyCode;
                m_function.Text = m_entry.Function.ToString();
            }
        }

        private void OnTypeSelection(Object sender, EventArgs e)
        {
            if (m_type.SelectedIndex < 0)
                return;
            m_btSave.Enabled = true;
            if (m_entry.Type != (MacroType)m_type.SelectedIndex || m_entry.Function == null)
                switch (m_entry.Type = (MacroType)m_type.SelectedIndex)
                {
                    case MacroType.KeyboardFunction:
                        m_entry.Function = new KeyboardFunction();
                        break;
                    case MacroType.MouseFunction:
                        m_entry.Function = new MouseFunction();
                        break;
                    case MacroType.StartProcess:
                        m_entry.Function = new StartProcess();
                        break;
                    case MacroType.ExecuteScript:
                        m_entry.Function = new ExecuteScript();
                        break;
                }
            if (m_entry.Type == MacroType.KeyboardFunction || m_entry.Type == MacroType.StartProcess)
                m_function.Enabled = true;
            m_function.Text = m_entry.Type == MacroType.ExecuteScript ? "Script" : m_entry.Function.ToString();
        }

        private void OnSetDescription(Object sender, EventArgs e)
        {
            m_entry.Description = m_description.Text;
        }

        private void OnSetFunction(Object sender, EventArgs e)
        {
            if (m_entry.Type == MacroType.StartProcess)
                (m_entry.Function as StartProcess).Path = m_function.Text;
        }

        private void Save()
        {
            if (Macros.ContainsKey(m_entry.Id))
                Macros[m_entry.Id] = m_entry;
            else
                Macros.Add(m_entry.Id, m_entry);
            if (SaveMacros())
                Program.MainForm.Notify($"Macro saved: {m_entry.Binding}");
        }

        private void OnFunctionEditor(Object sender, EventArgs e)
        {
            switch (m_entry.Type)
            {
                case MacroType.KeyboardFunction:
                    break;
                case MacroType.MouseFunction:
                    MouseActionForm mouseAction = new MouseActionForm((m_entry.Function as MouseFunction).Action);
                    if (mouseAction.ShowDialog() == DialogResult.OK)
                    {
                        (m_entry.Function as MouseFunction).Action = mouseAction.Action;
                        m_function.Text = m_entry.Function.ToString();
                        m_btSave.Enabled = true;
                    }
                    break;
                case MacroType.StartProcess:
                    if (m_fileDialog.ShowDialog() == DialogResult.OK)
                        m_function.Text = m_fileDialog.FileName;
                    break;
                case MacroType.ExecuteScript:
                    ExecuteScript function = m_entry.Function as ExecuteScript;
                    MacroScriptEditor scriptEditor = new MacroScriptEditor(function.Script);
                    scriptEditor.ShowDialog();
                    if (function.Script != scriptEditor.Script)
                        function.Script = scriptEditor.Script;
                    break;
            }
        }

        private void OnDragEnter(Object sender, DragEventArgs e)
        {
            if (m_entry.Type == MacroType.StartProcess && e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void OnDragDrop(Object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (m_entry.Type == MacroType.StartProcess && files.Length > 0)
                m_function.Text = files[0];
        }
    }
}
