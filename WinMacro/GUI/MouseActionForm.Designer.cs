namespace WinMacro.GUI
{
    partial class MouseActionForm
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
            this.m_actionType = new System.Windows.Forms.ComboBox();
            this.m_btOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_actionType
            // 
            this.m_actionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_actionType.FormattingEnabled = true;
            this.m_actionType.Items.AddRange(new object[] {
            "Left Click",
            "Right Click",
            "Scroll Click",
            "Mouse Button 4",
            "Mouse Button 5",
            "Double-Click",
            "Scroll Up",
            "Scroll Down"});
            this.m_actionType.Location = new System.Drawing.Point(12, 12);
            this.m_actionType.Name = "m_actionType";
            this.m_actionType.Size = new System.Drawing.Size(154, 21);
            this.m_actionType.TabIndex = 0;
            this.m_actionType.SelectedIndexChanged += new System.EventHandler(this.OnActionSelected);
            // 
            // m_btOK
            // 
            this.m_btOK.Location = new System.Drawing.Point(172, 12);
            this.m_btOK.Name = "m_btOK";
            this.m_btOK.Size = new System.Drawing.Size(45, 21);
            this.m_btOK.TabIndex = 1;
            this.m_btOK.Text = "OK";
            this.m_btOK.UseVisualStyleBackColor = true;
            this.m_btOK.Click += new System.EventHandler(this.OnFinish);
            // 
            // MouseActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 45);
            this.Controls.Add(this.m_btOK);
            this.Controls.Add(this.m_actionType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MouseActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mouse Action";
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox m_actionType;
        private System.Windows.Forms.Button m_btOK;
    }
}