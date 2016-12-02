namespace WinMacro.GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.m_notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.m_trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewMacrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startWithWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_macroList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_macroMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editMacroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMacroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMacroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_trayMenu.SuspendLayout();
            this.m_macroMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_notifyIcon
            // 
            this.m_notifyIcon.ContextMenuStrip = this.m_trayMenu;
            this.m_notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("m_notifyIcon.Icon")));
            this.m_notifyIcon.Visible = true;
            this.m_notifyIcon.BalloonTipClicked += new System.EventHandler(this.OnNotificationClick);
            this.m_notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnActivate);
            // 
            // m_trayMenu
            // 
            this.m_trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewMacrosToolStripMenuItem,
            this.startWithWindowsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.m_trayMenu.Name = "m_trayMenu";
            this.m_trayMenu.Size = new System.Drawing.Size(177, 70);
            // 
            // viewMacrosToolStripMenuItem
            // 
            this.viewMacrosToolStripMenuItem.Name = "viewMacrosToolStripMenuItem";
            this.viewMacrosToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.viewMacrosToolStripMenuItem.Text = "View Macros";
            this.viewMacrosToolStripMenuItem.Click += new System.EventHandler(this.OnViewMacros);
            // 
            // startWithWindowsToolStripMenuItem
            // 
            this.startWithWindowsToolStripMenuItem.CheckOnClick = true;
            this.startWithWindowsToolStripMenuItem.Name = "startWithWindowsToolStripMenuItem";
            this.startWithWindowsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.startWithWindowsToolStripMenuItem.Text = "Start with Windows";
            this.startWithWindowsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.OnSetWindowsStartup);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExit);
            // 
            // m_macroList
            // 
            this.m_macroList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_macroList.CheckBoxes = true;
            this.m_macroList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.m_macroList.ContextMenuStrip = this.m_macroMenu;
            this.m_macroList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_macroList.FullRowSelect = true;
            this.m_macroList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_macroList.Location = new System.Drawing.Point(0, 0);
            this.m_macroList.MultiSelect = false;
            this.m_macroList.Name = "m_macroList";
            this.m_macroList.Size = new System.Drawing.Size(574, 261);
            this.m_macroList.TabIndex = 0;
            this.m_macroList.UseCompatibleStateImageBehavior = false;
            this.m_macroList.View = System.Windows.Forms.View.Details;
            this.m_macroList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.OnMacroEnabled);
            this.m_macroList.SelectedIndexChanged += new System.EventHandler(this.OnMacroSelect);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 19;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Binding";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Function";
            this.columnHeader4.Width = 156;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Description";
            this.columnHeader5.Width = 180;
            // 
            // m_macroMenu
            // 
            this.m_macroMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMacroToolStripMenuItem,
            this.addMacroToolStripMenuItem,
            this.deleteMacroToolStripMenuItem});
            this.m_macroMenu.Name = "m_macroMenu";
            this.m_macroMenu.Size = new System.Drawing.Size(145, 70);
            // 
            // editMacroToolStripMenuItem
            // 
            this.editMacroToolStripMenuItem.Name = "editMacroToolStripMenuItem";
            this.editMacroToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.editMacroToolStripMenuItem.Text = "Edit Macro";
            this.editMacroToolStripMenuItem.Click += new System.EventHandler(this.OnMacroEdit);
            // 
            // addMacroToolStripMenuItem
            // 
            this.addMacroToolStripMenuItem.Name = "addMacroToolStripMenuItem";
            this.addMacroToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.addMacroToolStripMenuItem.Text = "Add Macro";
            this.addMacroToolStripMenuItem.Click += new System.EventHandler(this.OnMacroAdd);
            // 
            // deleteMacroToolStripMenuItem
            // 
            this.deleteMacroToolStripMenuItem.Name = "deleteMacroToolStripMenuItem";
            this.deleteMacroToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.deleteMacroToolStripMenuItem.Text = "Delete Macro";
            this.deleteMacroToolStripMenuItem.Click += new System.EventHandler(this.OnMacroDelete);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 261);
            this.Controls.Add(this.m_macroList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinMacro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.Shown += new System.EventHandler(this.OnShown);
            this.m_trayMenu.ResumeLayout(false);
            this.m_macroMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon m_notifyIcon;
        private System.Windows.Forms.ListView m_macroList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip m_macroMenu;
        private System.Windows.Forms.ToolStripMenuItem editMacroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMacroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMacroToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ContextMenuStrip m_trayMenu;
        private System.Windows.Forms.ToolStripMenuItem viewMacrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startWithWindowsToolStripMenuItem;
    }
}