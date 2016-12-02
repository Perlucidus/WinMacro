namespace WinMacro.GUI
{
    partial class MacroSaveForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MacroSaveForm));
            this.label1 = new System.Windows.Forms.Label();
            this.m_binding = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_function = new System.Windows.Forms.TextBox();
            this.m_description = new System.Windows.Forms.RichTextBox();
            this.m_btSave = new System.Windows.Forms.Button();
            this.m_btCancel = new System.Windows.Forms.Button();
            this.m_symmetric = new System.Windows.Forms.CheckBox();
            this.m_btClear = new System.Windows.Forms.Button();
            this.m_btFunc = new System.Windows.Forms.Button();
            this.m_fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Binding:";
            // 
            // m_binding
            // 
            this.m_binding.Location = new System.Drawing.Point(73, 6);
            this.m_binding.Name = "m_binding";
            this.m_binding.Size = new System.Drawing.Size(154, 20);
            this.m_binding.TabIndex = 1;
            this.m_binding.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnBindingKey);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type:";
            // 
            // m_type
            // 
            this.m_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_type.FormattingEnabled = true;
            this.m_type.Location = new System.Drawing.Point(73, 55);
            this.m_type.Name = "m_type";
            this.m_type.Size = new System.Drawing.Size(199, 21);
            this.m_type.TabIndex = 3;
            this.m_type.SelectedIndexChanged += new System.EventHandler(this.OnTypeSelection);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Function:";
            // 
            // m_function
            // 
            this.m_function.Enabled = false;
            this.m_function.Location = new System.Drawing.Point(73, 82);
            this.m_function.Name = "m_function";
            this.m_function.Size = new System.Drawing.Size(169, 20);
            this.m_function.TabIndex = 5;
            this.m_function.TextChanged += new System.EventHandler(this.OnSetFunction);
            this.m_function.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnFunctionKey);
            // 
            // m_description
            // 
            this.m_description.Location = new System.Drawing.Point(12, 108);
            this.m_description.Name = "m_description";
            this.m_description.Size = new System.Drawing.Size(260, 96);
            this.m_description.TabIndex = 6;
            this.m_description.Text = "Description";
            this.m_description.TextChanged += new System.EventHandler(this.OnSetDescription);
            // 
            // m_btSave
            // 
            this.m_btSave.Enabled = false;
            this.m_btSave.Location = new System.Drawing.Point(12, 210);
            this.m_btSave.Name = "m_btSave";
            this.m_btSave.Size = new System.Drawing.Size(125, 25);
            this.m_btSave.TabIndex = 7;
            this.m_btSave.Text = "Save";
            this.m_btSave.UseVisualStyleBackColor = true;
            this.m_btSave.Click += new System.EventHandler(this.OnSave);
            // 
            // m_btCancel
            // 
            this.m_btCancel.Location = new System.Drawing.Point(147, 210);
            this.m_btCancel.Name = "m_btCancel";
            this.m_btCancel.Size = new System.Drawing.Size(125, 25);
            this.m_btCancel.TabIndex = 8;
            this.m_btCancel.Text = "Cancel";
            this.m_btCancel.UseVisualStyleBackColor = true;
            this.m_btCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // m_symmetric
            // 
            this.m_symmetric.AutoSize = true;
            this.m_symmetric.Location = new System.Drawing.Point(15, 32);
            this.m_symmetric.Name = "m_symmetric";
            this.m_symmetric.Size = new System.Drawing.Size(222, 17);
            this.m_symmetric.TabIndex = 9;
            this.m_symmetric.Text = "Symmetric (Can be used from end to start)";
            this.m_symmetric.UseVisualStyleBackColor = true;
            // 
            // m_btClear
            // 
            this.m_btClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.m_btClear.Location = new System.Drawing.Point(233, 5);
            this.m_btClear.Name = "m_btClear";
            this.m_btClear.Size = new System.Drawing.Size(39, 23);
            this.m_btClear.TabIndex = 10;
            this.m_btClear.Text = "Clear";
            this.m_btClear.UseVisualStyleBackColor = true;
            this.m_btClear.Click += new System.EventHandler(this.OnBindingClear);
            // 
            // m_btFunc
            // 
            this.m_btFunc.Location = new System.Drawing.Point(248, 80);
            this.m_btFunc.Name = "m_btFunc";
            this.m_btFunc.Size = new System.Drawing.Size(24, 23);
            this.m_btFunc.TabIndex = 11;
            this.m_btFunc.Text = "...";
            this.m_btFunc.UseVisualStyleBackColor = true;
            this.m_btFunc.Click += new System.EventHandler(this.OnFunctionEditor);
            // 
            // m_fileDialog
            // 
            this.m_fileDialog.FileName = "openFileDialog1";
            // 
            // MacroSaveForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 244);
            this.Controls.Add(this.m_btFunc);
            this.Controls.Add(this.m_btClear);
            this.Controls.Add(this.m_symmetric);
            this.Controls.Add(this.m_btCancel);
            this.Controls.Add(this.m_btSave);
            this.Controls.Add(this.m_description);
            this.Controls.Add(this.m_function);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_type);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_binding);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MacroSaveForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WinMacro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_binding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox m_type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_function;
        private System.Windows.Forms.RichTextBox m_description;
        private System.Windows.Forms.Button m_btSave;
        private System.Windows.Forms.Button m_btCancel;
        private System.Windows.Forms.CheckBox m_symmetric;
        private System.Windows.Forms.Button m_btClear;
        private System.Windows.Forms.Button m_btFunc;
        private System.Windows.Forms.OpenFileDialog m_fileDialog;
    }
}