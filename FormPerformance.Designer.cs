namespace TheraWii
{
    partial class FormPerformance
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxTherapy = new System.Windows.Forms.ComboBox();
			this.comboBoxMetric = new System.Windows.Forms.ComboBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCopy = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.comboBoxTask = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// chart1
			// 
			this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			chartArea1.AxisX.Interval = 1;
			chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont)
						| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
						| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
						| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45)
						| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90)
						| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
			chartArea1.AxisX.LabelStyle.Format = "G";
			chartArea1.AxisX.LabelStyle.IsEndLabelVisible = false;
			chartArea1.AxisX.MajorGrid.Enabled = false;
			chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DimGray;
			chartArea1.AxisX.Title = "Session";
			chartArea1.AxisX2.MajorGrid.Enabled = false;
			chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisY.MinorTickMark.Enabled = true;
			chartArea1.AxisY.MinorTickMark.Size = 0.3F;
			chartArea1.AxisY2.MajorGrid.Enabled = false;
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			this.chart1.Location = new System.Drawing.Point(12, 100);
			this.chart1.Name = "chart1";
			series1.BorderWidth = 3;
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.IsValueShownAsLabel = true;
			series1.IsXValueIndexed = true;
			series1.LabelFormat = "F";
			series1.MarkerBorderColor = System.Drawing.Color.Black;
			series1.MarkerSize = 7;
			series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
			series1.Name = "Series1";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(640, 480);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
			title1.Name = "Title";
			title1.Text = "Chart";
			this.chart1.Titles.Add(title1);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(242, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Therapy";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(189, 69);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(99, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Performance Metric";
			// 
			// comboBoxTherapy
			// 
			this.comboBoxTherapy.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.comboBoxTherapy.FormattingEnabled = true;
			this.comboBoxTherapy.Location = new System.Drawing.Point(294, 12);
			this.comboBoxTherapy.Name = "comboBoxTherapy";
			this.comboBoxTherapy.Size = new System.Drawing.Size(141, 21);
			this.comboBoxTherapy.TabIndex = 3;
			this.comboBoxTherapy.SelectedIndexChanged += new System.EventHandler(this.comboBoxTherapy_SelectedIndexChanged);
			// 
			// comboBoxMetric
			// 
			this.comboBoxMetric.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.comboBoxMetric.FormattingEnabled = true;
			this.comboBoxMetric.Location = new System.Drawing.Point(294, 66);
			this.comboBoxMetric.Name = "comboBoxMetric";
			this.comboBoxMetric.Size = new System.Drawing.Size(141, 21);
			this.comboBoxMetric.TabIndex = 4;
			this.comboBoxMetric.SelectedIndexChanged += new System.EventHandler(this.comboBoxMetric_SelectedIndexChanged);
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonSave.Location = new System.Drawing.Point(214, 594);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 5;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonCopy
			// 
			this.buttonCopy.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonCopy.Location = new System.Drawing.Point(295, 594);
			this.buttonCopy.Name = "buttonCopy";
			this.buttonCopy.Size = new System.Drawing.Size(75, 23);
			this.buttonCopy.TabIndex = 6;
			this.buttonCopy.Text = "Copy";
			this.buttonCopy.UseVisualStyleBackColor = true;
			this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonClose.Location = new System.Drawing.Point(376, 594);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 7;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// comboBoxTask
			// 
			this.comboBoxTask.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.comboBoxTask.FormattingEnabled = true;
			this.comboBoxTask.Location = new System.Drawing.Point(294, 39);
			this.comboBoxTask.Name = "comboBoxTask";
			this.comboBoxTask.Size = new System.Drawing.Size(141, 21);
			this.comboBoxTask.TabIndex = 9;
			this.comboBoxTask.SelectedIndexChanged += new System.EventHandler(this.comboBoxTask_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(257, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(31, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Task";
			// 
			// FormPerformance
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(664, 629);
			this.Controls.Add(this.comboBoxTask);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonCopy);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.comboBoxMetric);
			this.Controls.Add(this.comboBoxTherapy);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.chart1);
			this.Name = "FormPerformance";
			this.Text = "Performance Metrics";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTherapy;
        private System.Windows.Forms.ComboBox comboBoxMetric;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ComboBox comboBoxTask;
        private System.Windows.Forms.Label label3;


    }
}