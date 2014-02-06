namespace TheraWii
{
    partial class FormProfileChooser
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
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelInstructions = new System.Windows.Forms.Label();
			this.listProfiles = new System.Windows.Forms.ListBox();
			this.buttonAddProfile = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(241, 134);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(330, 134);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelInstructions
			// 
			this.labelInstructions.AutoSize = true;
			this.labelInstructions.Location = new System.Drawing.Point(12, 12);
			this.labelInstructions.Name = "labelInstructions";
			this.labelInstructions.Size = new System.Drawing.Size(264, 13);
			this.labelInstructions.TabIndex = 2;
			this.labelInstructions.Text = "Please select a profile from the list below and click OK.";
			// 
			// listProfiles
			// 
			this.listProfiles.FormattingEnabled = true;
			this.listProfiles.Location = new System.Drawing.Point(15, 28);
			this.listProfiles.Name = "listProfiles";
			this.listProfiles.Size = new System.Drawing.Size(390, 95);
			this.listProfiles.TabIndex = 3;
			this.listProfiles.DoubleClick += new System.EventHandler(this.listProfiles_DoubleClick);
			// 
			// buttonAddProfile
			// 
			this.buttonAddProfile.Location = new System.Drawing.Point(15, 131);
			this.buttonAddProfile.Name = "buttonAddProfile";
			this.buttonAddProfile.Size = new System.Drawing.Size(74, 26);
			this.buttonAddProfile.TabIndex = 16;
			this.buttonAddProfile.Text = "Create New";
			this.buttonAddProfile.UseVisualStyleBackColor = true;
			this.buttonAddProfile.Click += new System.EventHandler(this.buttonAddProfile_Click);
			// 
			// FormProfileChooser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(417, 169);
			this.Controls.Add(this.buttonAddProfile);
			this.Controls.Add(this.listProfiles);
			this.Controls.Add(this.labelInstructions);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.KeyPreview = true;
			this.Name = "FormProfileChooser";
			this.Text = "Profile Chooser";
			this.Load += new System.EventHandler(this.FormProfileChooser_Load);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormProfileChooser_KeyPress);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormProfileChooser_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelInstructions;
        private System.Windows.Forms.ListBox listProfiles;
        private System.Windows.Forms.Button buttonAddProfile;
    }
}