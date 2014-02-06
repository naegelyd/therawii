using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TheraWii
{
    public partial class FormPerformance : Form
    {
        private Profile profile;
        private string therapy, task;
        private PerformanceMetricType metric;

        public FormPerformance(Profile p)
        {
            InitializeComponent();

            profile = p;

            comboBoxMetric.DataSource = PerformanceMetrics.PerformanceMetricStrings;
            comboBoxTherapy.DataSource = profile.GetAllTherapies();
        }

        private void comboBoxTherapy_SelectedIndexChanged(object sender, EventArgs e)
        {
            therapy = (string)comboBoxTherapy.SelectedItem;
            comboBoxTask.DataSource = profile.GetAllTasks(therapy);
        }

        private void comboBoxTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            task = (string)comboBoxTask.SelectedItem;
            metric = profile.GetPrimaryMetric(therapy, task);

            comboBoxMetric.SelectedIndex = -1;
            comboBoxMetric.SelectedIndex = (int)metric;
        }

        private void comboBoxMetric_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (0 <= comboBoxMetric.SelectedIndex
                && comboBoxMetric.SelectedIndex < PerformanceMetrics.PerformanceMetricStrings.Length)
            {
                metric = (PerformanceMetricType)comboBoxMetric.SelectedIndex;
                updateChart();
            }
        }

        private void updateChart()
        {
            DataPoints points = profile.GetMetricPoints(therapy, task, metric);
            chart1.Series["Series1"].Points.DataBindXY(points.Xs, points.Ys);
            //chart1.Series["Series1"].IsXValueIndexed = true;
            chart1.Titles[0].Text = PerformanceMetrics.PerformanceMetricStrings[(int)metric];

            switch (metric)
            {
                case PerformanceMetricType.TotalTime:
                case PerformanceMetricType.TimeInRegion:
                case PerformanceMetricType.TimeOutRegion:
                    chart1.ChartAreas[0].AxisY.Title = "Seconds";
                    break;
                case PerformanceMetricType.PathEfficiency:
                    chart1.ChartAreas[0].AxisY.Title = "Path Distance / Path Length";
                    break;
                case PerformanceMetricType.MotionArea:
                    chart1.ChartAreas[0].AxisY.Title = "Distance Units Square";
                    break;
                case PerformanceMetricType.SpeedAverage:
                    chart1.ChartAreas[0].AxisY.Title = "Distance Units per Second";
                    break;
                default:
                    chart1.ChartAreas[0].AxisY.Title = "Distance Units";
                    break;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Create a new save file dialog
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            // Sets the current file name filter string, which determines 
            // the choices that appear in the "Save as file type" or 
            // "Files of type" box in the dialog box.
            saveFileDialog1.Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg|EMF-Plus (*.emf)|*.emf|EMF-Dual (*.emf)|*.emf|EMF (*.emf)|*.emf|GIF (*.gif)|*.gif|TIFF (*.tif)|*.tif|Bitmap (*.bmp)|*.bmp";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            // Set image file format
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ChartImageFormat format = ChartImageFormat.Bmp;

                if (saveFileDialog1.FileName.EndsWith("bmp"))
                {
                    format = ChartImageFormat.Bmp;
                }
                else if (saveFileDialog1.FileName.EndsWith("jpg"))
                {
                    format = ChartImageFormat.Jpeg;
                }
                else if (saveFileDialog1.FileName.EndsWith("emf") && saveFileDialog1.FilterIndex == 3)
                {
                    format = ChartImageFormat.EmfPlus;
                }
                else if (saveFileDialog1.FileName.EndsWith("emf") && saveFileDialog1.FilterIndex == 4)
                {
                    format = ChartImageFormat.EmfDual;
                }
                else if (saveFileDialog1.FileName.EndsWith("emf"))
                {
                    format = ChartImageFormat.Emf;
                }
                else if (saveFileDialog1.FileName.EndsWith("gif"))
                {
                    format = ChartImageFormat.Gif;
                }
                else if (saveFileDialog1.FileName.EndsWith("png"))
                {
                    format = ChartImageFormat.Png;
                }
                else if (saveFileDialog1.FileName.EndsWith("tif"))
                {
                    format = ChartImageFormat.Tiff;
                }

                // Save image
                chart1.SaveImage(saveFileDialog1.FileName, format);
            }

        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            // create a memory stream to save the chart image    
            System.IO.MemoryStream stream = new System.IO.MemoryStream();

            // save the chart image to the stream
            chart1.SaveImage(stream, ImageFormat.Png);

            // create a bitmap using the stream
            Bitmap bmp = new Bitmap(stream);

            // save the bitmap to the clipboard    
            Clipboard.SetDataObject(bmp); 
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
