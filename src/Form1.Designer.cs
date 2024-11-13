using System.Windows.Forms;

namespace Cryptify
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.FileSelector = new System.Windows.Forms.Button();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ShowPassword = new System.Windows.Forms.CheckBox();
            this.AlgorithmBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // FileSelector
            // 
            this.FileSelector.BackColor = System.Drawing.Color.Transparent;
            this.FileSelector.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.FileSelector.FlatAppearance.BorderSize = 0;
            this.FileSelector.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.FileSelector.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.FileSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileSelector.ForeColor = System.Drawing.Color.Transparent;
            this.FileSelector.Image = global::Cryptify.Properties.Resources.folder;
            this.FileSelector.Location = new System.Drawing.Point(53, 21);
            this.FileSelector.Name = "FileSelector";
            this.FileSelector.Size = new System.Drawing.Size(263, 205);
            this.FileSelector.TabIndex = 0;
            this.FileSelector.UseVisualStyleBackColor = false;
            this.FileSelector.Click += new System.EventHandler(this.FileSelector_Click);
            // 
            // PasswordBox
            // 
            this.PasswordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.PasswordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordBox.ForeColor = System.Drawing.Color.Silver;
            this.PasswordBox.Location = new System.Drawing.Point(53, 254);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(155, 13);
            this.PasswordBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(50, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Password:";
            // 
            // ShowPassword
            // 
            this.ShowPassword.AutoSize = true;
            this.ShowPassword.ForeColor = System.Drawing.Color.Silver;
            this.ShowPassword.Location = new System.Drawing.Point(214, 254);
            this.ShowPassword.Name = "ShowPassword";
            this.ShowPassword.Size = new System.Drawing.Size(102, 17);
            this.ShowPassword.TabIndex = 3;
            this.ShowPassword.Text = "Show Password";
            this.ShowPassword.UseVisualStyleBackColor = true;
            this.ShowPassword.CheckedChanged += new System.EventHandler(this.ShowPassword_CheckedChanged);
            // 
            // AlgorithmBox
            // 
            this.AlgorithmBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.AlgorithmBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlgorithmBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlgorithmBox.ForeColor = System.Drawing.Color.Silver;
            this.AlgorithmBox.FormattingEnabled = true;
            this.AlgorithmBox.Items.AddRange(new object[] {
            "AES",
            "DES",
            "Triple DES"});
            this.AlgorithmBox.Location = new System.Drawing.Point(53, 273);
            this.AlgorithmBox.Name = "AlgorithmBox";
            this.AlgorithmBox.Size = new System.Drawing.Size(121, 21);
            this.AlgorithmBox.TabIndex = 4;
            this.AlgorithmBox.SelectionChangeCommitted += new System.EventHandler(this.Algorithm_SelectionChangeCommitted);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(370, 341);
            this.Controls.Add(this.AlgorithmBox);
            this.Controls.Add(this.ShowPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.FileSelector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Cryptify";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button FileSelector;
        private TextBox PasswordBox;
        private Label label1;
        private CheckBox ShowPassword;
        private ComboBox AlgorithmBox;
    }
}

