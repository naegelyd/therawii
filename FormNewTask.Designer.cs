namespace TheraWii
{
    partial class FormNewTask
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
			this.listBoxTasks = new System.Windows.Forms.ListBox();
			this.labelSelectTask = new System.Windows.Forms.Label();
			this.buttonCreate = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBoxTasks
			// 
			this.listBoxTasks.FormattingEnabled = true;
			this.listBoxTasks.Items.AddRange(new object[] {
            "Dialog Task",
            "2D Task",
            "Repeat Task"});
			this.listBoxTasks.Location = new System.Drawing.Point(32, 23);
			this.listBoxTasks.Name = "listBoxTasks";
			this.listBoxTasks.Size = new System.Drawing.Size(156, 95);
			this.listBoxTasks.TabIndex = 0;
			this.listBoxTasks.DoubleClick += new System.EventHandler(this.listBoxTasks_DoubleClick);
			// 
			// labelSelectTask
			// 
			this.labelSelectTask.AutoSize = true;
			this.labelSelectTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSelectTask.Location = new System.Drawing.Point(45, 0);
			this.labelSelectTask.Name = "labelSelectTask";
			this.labelSelectTask.Size = new System.Drawing.Size(130, 20);
			this.labelSelectTask.TabIndex = 1;
			this.labelSelectTask.Text = "Select Task Type";
			// 
			// buttonCreate
			// 
			this.buttonCreate.Location = new System.Drawing.Point(32, 124);
			this.buttonCreate.Name = "buttonCreate";
			this.buttonCreate.Size = new System.Drawing.Size(75, 23);
			this.buttonCreate.TabIndex = 2;
			this.buttonCreate.Text = "Create Task";
			this.buttonCreate.UseVisualStyleBackColor = true;
			this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(113, 124);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.labelSelectTask);
			this.panel1.Controls.Add(this.buttonCancel);
			this.panel1.Controls.Add(this.listBoxTasks);
			this.panel1.Controls.Add(this.buttonCreate);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(221, 154);
			this.panel1.TabIndex = 4;
			// 
			// FormNewTask
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(246, 176);
			this.Controls.Add(this.panel1);
			this.KeyPreview = true;
			this.Name = "FormNewTask";
			this.Text = "NewTask";
			this.Load += new System.EventHandler(this.NewTask_Load);
			this.DoubleClick += new System.EventHandler(this.FormNewTask_DoubleClick);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormNewTask_KeyPress);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewTask_FormClosing);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTasks;
        private System.Windows.Forms.Label labelSelectTask;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel1;
    }
}