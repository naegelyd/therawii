namespace TheraWii
{
    partial class FormNewProfile
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
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelInstruct = new System.Windows.Forms.Label();
			this.labelTextBox = new System.Windows.Forms.Label();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(91, 69);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(150, 20);
			this.textBoxName.TabIndex = 0;
			this.textBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxName_KeyPress);
			// 
			// labelInstruct
			// 
			this.labelInstruct.AutoSize = true;
			this.labelInstruct.Location = new System.Drawing.Point(49, 17);
			this.labelInstruct.Name = "labelInstruct";
			this.labelInstruct.Size = new System.Drawing.Size(192, 13);
			this.labelInstruct.TabIndex = 1;
			this.labelInstruct.Text = "Enter a unique name for the new profile";
			// 
			// labelTextBox
			// 
			this.labelTextBox.AutoSize = true;
			this.labelTextBox.Location = new System.Drawing.Point(49, 72);
			this.labelTextBox.Name = "labelTextBox";
			this.labelTextBox.Size = new System.Drawing.Size(35, 13);
			this.labelTextBox.TabIndex = 2;
			this.labelTextBox.Text = "Name";
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(52, 104);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 3;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(166, 104);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// FormNewProfile
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(291, 140);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.labelTextBox);
			this.Controls.Add(this.labelInstruct);
			this.Controls.Add(this.textBoxName);
			this.KeyPreview = true;
			this.Name = "FormNewProfile";
			this.Text = "New Profile";
			this.Load += new System.EventHandler(this.FormNewProfile_Load);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormNewProfile_KeyPress);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewProfile_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelInstruct;
        private System.Windows.Forms.Label labelTextBox;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}