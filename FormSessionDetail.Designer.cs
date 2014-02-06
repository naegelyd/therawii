using System.Data;
using System.Collections.Generic;
namespace TheraWii
{
    partial class FormSessionDetail
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

        public void displaySessionDetails(Session s)
        {
            DScsv file = new DScsv();
            List<string[]> data = file.getData(s.GetDataFilePath());
            int max = 0;
            int current = 0;
            for(int i = 0; i < data.Count; i++)
            {
                current = 0;
                for(int j = 0; j < data[i].Length; j++)
                {
                    current++;
                }
                if (current > max)
                    max = current;
            }

            DataTable dt = new DataTable("Session");
            //name columns
            for (int i = 0; i < max; i++)
            {
                dt.Columns.Add((i+1).ToString());
            }
            //add rows
            for(int i = 0; i < data.Count; i++)
            {
                dt.Rows.Add(data[i]);
            }            
            DataView dv = new DataView(dt);
            dataGridView1.DataSource = dv;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 38);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(562, 342);
			this.dataGridView1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(7, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(371, 26);
			this.label1.TabIndex = 1;
			this.label1.Text = "Session Detail for Profile on 10/24/08";
			// 
			// FormSessionDetail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(586, 392);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridView1);
			this.KeyPreview = true;
			this.Name = "FormSessionDetail";
			this.Text = "SessionDetail";
			this.Load += new System.EventHandler(this.FormSessionDetail_Load);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormSessionDetail_KeyPress);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSessionDetail_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
    }
}