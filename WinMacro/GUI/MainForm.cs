using Microsoft.Win32;
using System;
using System.Windows.Forms;
using static WinMacro.Data.MacroManager;

namespace WinMacro.GUI
{
    public partial class MainForm : Form
    {
        private const string RegistryName = "WinMacro";
        private const string WindowsRunPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        public MainForm()
        {
            InitializeComponent();
        }

        #region Form Events

        private void OnLoad(Object sender, EventArgs e)
        {
            ReloadMacros();
            RegistryKey startup = Registry.CurrentUser.OpenSubKey(WindowsRunPath, true);
            startWithWindowsToolStripMenuItem.Checked = startup.GetValue(RegistryName) != null;
            if (startWithWindowsToolStripMenuItem.Checked && (string)startup.GetValue(RegistryName) != Application.ExecutablePath)
                startup.SetValue(RegistryName, Application.ExecutablePath);
        }

        private void OnShown(Object sender, EventArgs e)
        {
            Hide();
            Notify("Application running in background.\nAccess through notification area icon.");
        }

        private void OnClosing(Object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        #endregion

        #region Macro Operations

        private void OnMacroSelect(Object sender, EventArgs e)
        {
            editMacroToolStripMenuItem.Visible = m_macroList.SelectedItems.Count == 1;
            deleteMacroToolStripMenuItem.Visible = m_macroList.SelectedItems.Count == 1;
        }

        private void OnMacroEdit(Object sender, EventArgs e)
        {
            if (m_macroList.SelectedItems.Count != 1)
                return;
            uint id = (uint)m_macroList.SelectedItems[0].Tag;
            if (!Macros.ContainsKey(id))
            {
                MessageBox.Show("An error has occured while attempting to edit macro.");
                return;
            }
            EditMacro(Macros[id]);
        }

        private void OnMacroAdd(Object sender, EventArgs e)
        {
            EditMacro(null);
        }

        private void OnMacroDelete(Object sender, EventArgs e)
        {
            if (m_macroList.SelectedItems.Count != 1)
                return;
            Macros.Remove((uint)m_macroList.SelectedItems[0].Tag);
            SaveMacros();
            ReloadMacros();
        }

        private void OnMacroEnabled(Object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Tag != null)
                Macros[(uint)e.Item.Tag].Enabled = e.Item.Checked;
        }

        private void ReloadMacros()
        {
            m_macroList.Items.Clear();
            foreach (MacroEntry entry in Macros.Values)
            {
                ListViewItem macro = m_macroList.Items.Add(new ListViewItem(new string[] {
                    String.Empty, //Enabled
                    entry.Binding.ToString(),
                    entry.Type.ToString(),
                    entry.Function?.ToString(),
                    entry.Description
                }));
                macro.Tag = entry.Id;
                macro.Checked = entry.Enabled;
            }
            editMacroToolStripMenuItem.Visible = false;
            deleteMacroToolStripMenuItem.Visible = false;
        }

        private void EditMacro(MacroEntry macro)
        {
            MacroSaveForm form = new MacroSaveForm(NextFreeId, macro);
            form.ShowDialog();
            ReloadMacros();
        }

        #endregion

        #region Notification Icon

        private void OnViewMacros(Object sender, EventArgs e)
        {
            Show();
        }

        private void OnExit(Object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnActivate(Object sender, MouseEventArgs e)
        {
            Show();
        }

        private void OnNotificationClick(Object sender, EventArgs e)
        {
            Show();
        }

        private void OnSetWindowsStartup(Object sender, EventArgs e)
        {
            RegistryKey startup = Registry.CurrentUser.OpenSubKey(WindowsRunPath, true);
            if (startWithWindowsToolStripMenuItem.Checked)
                startup.SetValue(RegistryName, Application.ExecutablePath);
            else
                startup.DeleteValue(RegistryName);
        }

        public void Notify(string text, string title = "", ToolTipIcon icon = ToolTipIcon.None)
        {
            m_notifyIcon.ShowBalloonTip(0, title, text, icon);
        }

        #endregion
    }
}
