namespace TheraWii
{
    partial class FormDialogTask
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
			this.textBoxDisplayText = new System.Windows.Forms.RichTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelEndSeconds = new System.Windows.Forms.Label();
			this.numericUpDownEndSeconds = new System.Windows.Forms.NumericUpDown();
			this.comboBoxEndButton = new System.Windows.Forms.ComboBox();
			this.comboBoxEndCondition = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndSeconds)).BeginInit();
			this.SuspendLayout();
			// 
			// TaskTitle
			// 
			this.TaskTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TaskTitle.AutoSize = true;
			this.TaskTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TaskTitle.Location = new System.Drawing.Point(95, 9);
			this.TaskTitle.Name = "TaskTitle";
			this.TaskTitle.Size = new System.Drawing.Size(178, 24);
			this.TaskTitle.TabIndex = 0;
			this.TaskTitle.Text = "Dialog Task Options";
			this.TaskTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(98, 50);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(175, 20);
			this.textBoxName.TabIndex = 1;
			this.textBoxName.Text = "Intro";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(54, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Name:";
			// 
			// textBoxDisplayText
			// 
			this.textBoxDisplayText.Location = new System.Drawing.Point(98, 76);
			this.textBoxDisplayText.Name = "textBoxDisplayText";
			this.textBoxDisplayText.Size = new System.Drawing.Size(260, 98);
			this.textBoxDisplayText.TabIndex = 5;
			this.textBoxDisplayText.Text = "Welcome!\n\nPress A to continue.";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(24, 79);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Display Text:";
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(207, 241);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 10;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(288, 241);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 11;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelEndSeconds
			// 
			this.labelEndSeconds.AutoSize = true;
			this.labelEndSeconds.Location = new System.Drawing.Point(169, 210);
			this.labelEndSeconds.Name = "labelEndSeconds";
			this.labelEndSeconds.Size = new System.Drawing.Size(49, 13);
			this.labelEndSeconds.TabIndex = 38;
			this.labelEndSeconds.Text = "Seconds";
			this.labelEndSeconds.Visible = false;
			// 
			// numericUpDownEndSeconds
			// 
			this.numericUpDownEndSeconds.Location = new System.Drawing.Point(98, 207);
			this.numericUpDownEndSeconds.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
			this.numericUpDownEndSeconds.Name = "numericUpDownEndSeconds";
			this.numericUpDownEndSeconds.Size = new System.Drawing.Size(65, 20);
			this.numericUpDownEndSeconds.TabIndex = 37;
			this.numericUpDownEndSeconds.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.numericUpDownEndSeconds.Visible = false;
			// 
			// comboBoxEndButton
			// 
			this.comboBoxEndButton.FormattingEnabled = true;
			this.comboBoxEndButton.Items.AddRange(new object[] {
            "A",
            "B",
            "Home",
            "+",
            "-",
            "1",
            "2",
            "Up",
            "Down",
            "Left",
            "Right"});
			this.comboBoxEndButton.Location = new System.Drawing.Point(98, 207);
			this.comboBoxEndButton.Name = "comboBoxEndButton";
			this.comboBoxEndButton.Size = new System.Drawing.Size(173, 21);
			this.comboBoxEndButton.TabIndex = 36;
			this.comboBoxEndButton.Text = "A";
			// 
			// comboBoxEndCondition
			// 
			this.comboBoxEndCondition.FormattingEnabled = true;
			this.comboBoxEndCondition.Items.AddRange(new object[] {
            "Button Press",
            "Time Limit"});
			this.comboBoxEndCondition.Location = new System.Drawing.Point(98, 180);
			this.comboBoxEndCondition.Name = "comboBoxEndCondition";
			this.comboBoxEndCondition.Size = new System.Drawing.Size(173, 21);
			this.comboBoxEndCondition.TabIndex = 35;
			this.comboBoxEndCondition.Text = "Button Press";
			this.comboBoxEndCondition.SelectedIndexChanged += new System.EventHandler(this.comboBoxEndCondition_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 183);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(76, 13);
			this.label4.TabIndex = 34;
			this.label4.Text = "End Condition:";
			// 
			// FormDialogTask
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(375, 278);
			this.Controls.Add(this.labelEndSeconds);
			this.Controls.Add(this.numericUpDownEndSeconds);
			this.Controls.Add(this.comboBoxEndButton);
			this.Controls.Add(this.comboBoxEndCondition);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBoxDisplayText);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.TaskTitle);
			this.KeyPreview = true;
			this.Name = "FormDialogTask";
			this.Text = "Edit Dialog Task";
			this.Load += new System.EventHandler(this.FormDialogTask_Load);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormDialogTask_KeyPress);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDialogTask_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndSeconds)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TaskTitle;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox textBoxDisplayText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelEndSeconds;
        private System.Windows.Forms.NumericUpDown numericUpDownEndSeconds;
        private System.Windows.Forms.ComboBox comboBoxEndButton;
        private System.Windows.Forms.ComboBox comboBoxEndCondition;
        private System.Windows.Forms.Label label4;
    }
}