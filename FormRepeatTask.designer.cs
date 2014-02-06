namespace TheraWii
{
    partial class FormRepeatTask
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
			this.TaskTitle = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.numericUpDownRepetitions = new System.Windows.Forms.NumericUpDown();
			this.radioButtonRepetitions = new System.Windows.Forms.RadioButton();
			this.radioButtonTimeLimit = new System.Windows.Forms.RadioButton();
			this.radioButtonBoth = new System.Windows.Forms.RadioButton();
			this.numericUpDownTimeLimit = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepetitions)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeLimit)).BeginInit();
			this.SuspendLayout();
			// 
			// TaskTitle
			// 
			this.TaskTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TaskTitle.AutoSize = true;
			this.TaskTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TaskTitle.Location = new System.Drawing.Point(26, 9);
			this.TaskTitle.Name = "TaskTitle";
			this.TaskTitle.Size = new System.Drawing.Size(185, 24);
			this.TaskTitle.TabIndex = 0;
			this.TaskTitle.Text = "Repeat Task Options";
			this.TaskTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(96, 52);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(120, 20);
			this.textBoxName.TabIndex = 1;
			this.textBoxName.Text = "Intro";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Name:";
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(40, 179);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 10;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(121, 179);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 11;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// numericUpDownRepetitions
			// 
			this.numericUpDownRepetitions.Location = new System.Drawing.Point(172, 90);
			this.numericUpDownRepetitions.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
			this.numericUpDownRepetitions.Name = "numericUpDownRepetitions";
			this.numericUpDownRepetitions.Size = new System.Drawing.Size(44, 20);
			this.numericUpDownRepetitions.TabIndex = 12;
			this.numericUpDownRepetitions.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// radioButtonRepetitions
			// 
			this.radioButtonRepetitions.AutoSize = true;
			this.radioButtonRepetitions.Checked = true;
			this.radioButtonRepetitions.Location = new System.Drawing.Point(20, 90);
			this.radioButtonRepetitions.Name = "radioButtonRepetitions";
			this.radioButtonRepetitions.Size = new System.Drawing.Size(79, 17);
			this.radioButtonRepetitions.TabIndex = 14;
			this.radioButtonRepetitions.TabStop = true;
			this.radioButtonRepetitions.Text = "Repetitions";
			this.radioButtonRepetitions.UseVisualStyleBackColor = true;
			this.radioButtonRepetitions.CheckedChanged += new System.EventHandler(this.radioButtonRepetitions_CheckedChanged);
			// 
			// radioButtonTimeLimit
			// 
			this.radioButtonTimeLimit.AutoSize = true;
			this.radioButtonTimeLimit.Location = new System.Drawing.Point(20, 116);
			this.radioButtonTimeLimit.Name = "radioButtonTimeLimit";
			this.radioButtonTimeLimit.Size = new System.Drawing.Size(124, 17);
			this.radioButtonTimeLimit.TabIndex = 15;
			this.radioButtonTimeLimit.Text = "Time Limit (Seconds)";
			this.radioButtonTimeLimit.UseVisualStyleBackColor = true;
			this.radioButtonTimeLimit.CheckedChanged += new System.EventHandler(this.radioButtonTimeLimit_CheckedChanged);
			// 
			// radioButtonBoth
			// 
			this.radioButtonBoth.AutoSize = true;
			this.radioButtonBoth.Location = new System.Drawing.Point(20, 142);
			this.radioButtonBoth.Name = "radioButtonBoth";
			this.radioButtonBoth.Size = new System.Drawing.Size(48, 17);
			this.radioButtonBoth.TabIndex = 16;
			this.radioButtonBoth.Text = "Both";
			this.radioButtonBoth.UseVisualStyleBackColor = true;
			this.radioButtonBoth.CheckedChanged += new System.EventHandler(this.radioButtonBoth_CheckedChanged);
			// 
			// numericUpDownTimeLimit
			// 
			this.numericUpDownTimeLimit.Enabled = false;
			this.numericUpDownTimeLimit.Location = new System.Drawing.Point(172, 116);
			this.numericUpDownTimeLimit.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
			this.numericUpDownTimeLimit.Name = "numericUpDownTimeLimit";
			this.numericUpDownTimeLimit.Size = new System.Drawing.Size(44, 20);
			this.numericUpDownTimeLimit.TabIndex = 18;
			this.numericUpDownTimeLimit.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
			// 
			// FormRepeatTask
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(237, 214);
			this.Controls.Add(this.numericUpDownTimeLimit);
			this.Controls.Add(this.radioButtonBoth);
			this.Controls.Add(this.radioButtonTimeLimit);
			this.Controls.Add(this.radioButtonRepetitions);
			this.Controls.Add(this.numericUpDownRepetitions);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.TaskTitle);
			this.KeyPreview = true;
			this.Name = "FormRepeatTask";
			this.Text = "Repeat Task";
			this.Load += new System.EventHandler(this.FormRepeatTask_Load);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormRepeatTask_KeyPress);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRepeatTask_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepetitions)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeLimit)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TaskTitle;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.NumericUpDown numericUpDownRepetitions;
        private System.Windows.Forms.RadioButton radioButtonRepetitions;
        private System.Windows.Forms.RadioButton radioButtonTimeLimit;
        private System.Windows.Forms.RadioButton radioButtonBoth;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeLimit;
    }
}