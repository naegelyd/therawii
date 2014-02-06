namespace TheraWii
{
    partial class FormAddDevices
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
			this.labelSelectTask = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.labelWarning = new System.Windows.Forms.Label();
			this.listViewInputs = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// labelSelectTask
			// 
			this.labelSelectTask.AutoSize = true;
			this.labelSelectTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSelectTask.Location = new System.Drawing.Point(22, 9);
			this.labelSelectTask.MaximumSize = new System.Drawing.Size(275, 0);
			this.labelSelectTask.MinimumSize = new System.Drawing.Size(275, 0);
			this.labelSelectTask.Name = "labelSelectTask";
			this.labelSelectTask.Size = new System.Drawing.Size(275, 17);
			this.labelSelectTask.TabIndex = 1;
			this.labelSelectTask.Text = "This therapy requires the following inputs:";
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(70, 264);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(173, 264);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(22, 171);
			this.label1.MinimumSize = new System.Drawing.Size(275, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(275, 17);
			this.label1.TabIndex = 4;
			this.label1.Text = "Please connect these devices in Windows.";
			// 
			// labelWarning
			// 
			this.labelWarning.AutoSize = true;
			this.labelWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelWarning.ForeColor = System.Drawing.Color.Red;
			this.labelWarning.Location = new System.Drawing.Point(22, 197);
			this.labelWarning.MaximumSize = new System.Drawing.Size(275, 0);
			this.labelWarning.MinimumSize = new System.Drawing.Size(275, 0);
			this.labelWarning.Name = "labelWarning";
			this.labelWarning.Size = new System.Drawing.Size(275, 51);
			this.labelWarning.TabIndex = 5;
			this.labelWarning.Text = "The devices in red were not detected.   Ensure they are detected by Windows, then" +
				" click OK.";
			this.labelWarning.Visible = false;
			// 
			// listViewInputs
			// 
			this.listViewInputs.Location = new System.Drawing.Point(25, 38);
			this.listViewInputs.MinimumSize = new System.Drawing.Size(268, 121);
			this.listViewInputs.Name = "listViewInputs";
			this.listViewInputs.Size = new System.Drawing.Size(268, 121);
			this.listViewInputs.TabIndex = 6;
			this.listViewInputs.UseCompatibleStateImageBehavior = false;
			this.listViewInputs.View = System.Windows.Forms.View.List;
			// 
			// FormAddDevices
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(318, 299);
			this.Controls.Add(this.listViewInputs);
			this.Controls.Add(this.labelWarning);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.labelSelectTask);
			this.KeyPreview = true;
			this.Name = "FormAddDevices";
			this.Text = "Device Connect";
			this.Load += new System.EventHandler(this.FormAddDevices_Load);
			this.DoubleClick += new System.EventHandler(this.FormAddDevices_DoubleClick);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormAddDevices_KeyPress);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAddDevices_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSelectTask;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.ListView listViewInputs;
    }
}