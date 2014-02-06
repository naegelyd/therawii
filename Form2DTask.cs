using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace TheraWii
{
    public partial class Form2DTask : Form
    {
        private Task2D task;
        private ButtonEndCondition buttonEnd;
        private TimeLimitEndCondition timeEnd;
        private List<InputDevice> additionalInputs;
		private static Point prevLocation;

        public Form2DTask(Task2D t)
        {
            InitializeComponent();
            comboBoxInputDevice.DataSource = Input2D.GetPossibleInputs();
            comboBoxInputHandling.DataSource = InputHandlingNames.InputHandlingStrings;
            comboBoxPerformanceMetric.DataSource = PerformanceMetrics.PerformanceMetricStrings;
            comboBoxEndButton.DataSource = ButtonEndCondition.ButtonText;
			comboBoxShape.DataSource = new ShapeType[] { ShapeType.Rectangle, ShapeType.Ellipse, ShapeType.Hoop };
			SpecifierLabel[] SpecifierLabels = new SpecifierLabel[] 
			{ 
				SpecifierLabel.Static, SpecifierLabel.Dynamic, 
				SpecifierLabel.Random
			};
			comboBoxPosX.BindingContext = new BindingContext();
			comboBoxPosX.DataSource = SpecifierLabels;
            comboBoxPosX.Tag = t.region.rParams[regPT.X];
			comboBoxPosY.BindingContext = new BindingContext();
			comboBoxPosY.DataSource = SpecifierLabels;
            comboBoxPosY.Tag = t.region.rParams[regPT.Y];
			comboBoxSizeX.BindingContext = new BindingContext();
			comboBoxSizeX.DataSource = SpecifierLabels;
			comboBoxSizeY.BindingContext = new BindingContext();
			comboBoxSizeY.DataSource = SpecifierLabels;


            // Load Form from task data
            task = t;
            textBoxName.Text = task.Name;

            // Input loading
            comboBoxInputDevice.SelectedIndex = Input2D.GetInputIndex(task.primaryInput);
            additionalInputs = new List<InputDevice>();
            additionalInputs.AddRange(task.additionalInput);
            listBoxAdditionalInputs.DataSource = additionalInputs;

            // Input handling load
            comboBoxInputHandling.SelectedIndex = (int)task.inputHandling;

            // Performance Metric load
            comboBoxPerformanceMetric.SelectedIndex = (int)task.performanceMetric;

            //Region Loading
            if (t.regionEnabled)
            {
                groupBox1.Enabled = true;
                checkBoxEnableRegion.Checked = true;
            }
            else
            {
                groupBox1.Enabled = false;
                checkBoxEnableRegion.Checked = false;
            }
            if (t.region.Shape != ShapeType.NONE)
            {
				comboBoxShape.SelectedItem = t.region.Shape;
				comboBoxPosX.SelectedItem  = ((RegionParameter)comboBoxPosX.Tag).SL_pos;
                comboBoxPosY.SelectedItem  = ((RegionParameter)comboBoxPosY.Tag).SL_pos;
				comboBoxSizeX.SelectedItem = ((RegionParameter)comboBoxPosX.Tag).SL_size;
                comboBoxSizeY.SelectedItem = ((RegionParameter)comboBoxPosY.Tag).SL_size;
                numericUpDownPosX1.Value   = (decimal)((RegionParameter)comboBoxPosX.Tag).pos[0];
                numericUpDownPosX2.Value   = (decimal)((RegionParameter)comboBoxPosX.Tag).pos[1];
                numericUpDownPosY1.Value   = (decimal)((RegionParameter)comboBoxPosY.Tag).pos[0];
                numericUpDownPosY2.Value   = (decimal)((RegionParameter)comboBoxPosY.Tag).pos[1];
                numericUpDownSizeX1.Value  = (decimal)((RegionParameter)comboBoxPosX.Tag).size[0];
                numericUpDownSizeX2.Value  = (decimal)((RegionParameter)comboBoxPosX.Tag).size[1];
                numericUpDownSizeY1.Value  = (decimal)((RegionParameter)comboBoxPosY.Tag).size[0];
                numericUpDownSizeY2.Value  = (decimal)((RegionParameter)comboBoxPosY.Tag).size[1];
            }

            // End Condition Loading
            if (task.endCondition.GetType() == typeof(ButtonEndCondition))
            {
                buttonEnd = (ButtonEndCondition)task.endCondition;
                timeEnd = new TimeLimitEndCondition();
                comboBoxEndCondition.SelectedIndex = 0;

            }
            else
            {
                buttonEnd = new ButtonEndCondition();
                timeEnd = (TimeLimitEndCondition)task.endCondition;
                if(((TimeLimitEndCondition)task.endCondition).Type == TimeLimitType.TotalTime)
                    comboBoxEndCondition.SelectedIndex = 1;
                else if(((TimeLimitEndCondition)task.endCondition).Type == TimeLimitType.TimeInRegion)
                    comboBoxEndCondition.SelectedIndex = 2;
                else if (((TimeLimitEndCondition)task.endCondition).Type == TimeLimitType.TimeOutRegion)
                    comboBoxEndCondition.SelectedIndex = 3;
            }
            numericUpDownEndSeconds.Value = (decimal)timeEnd.TimeLimit;
            comboBoxEndButton.SelectedIndex = (int)buttonEnd.Button;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            task.Name = textBoxName.Text;

            // Save Input
            task.primaryInput = (InputDevice) comboBoxInputDevice.SelectedItem;
            task.additionalInput = additionalInputs;

            // Save input handling
            task.inputHandling = (InputHandling)comboBoxInputHandling.SelectedIndex;

            // Save performance metric
            task.performanceMetric = (PerformanceMetricType)comboBoxPerformanceMetric.SelectedIndex;

            // Save Region
            task.regionEnabled = checkBoxEnableRegion.Checked;
            task.region.Shape = (ShapeType)comboBoxShape.SelectedIndex;
			            
            //Console.WriteLine("UI Size: " + (float)numericUpDownSizeX2.Value + "," + (float)numericUpDownSizeY2.Value);
            //Console.WriteLine("UI Pos: " + (float)numericUpDownPosX2.Value + "," + (float)numericUpDownPosY2.Value);

            task.region.Shape = (ShapeType)comboBoxShape.SelectedItem;
            ((RegionParameter)comboBoxPosX.Tag).SL_pos  = (SpecifierLabel)comboBoxPosX.SelectedItem;
            ((RegionParameter)comboBoxPosY.Tag).SL_pos  = (SpecifierLabel)comboBoxPosY.SelectedItem;
            ((RegionParameter)comboBoxPosX.Tag).SL_size = (SpecifierLabel)comboBoxSizeX.SelectedItem;
            ((RegionParameter)comboBoxPosY.Tag).SL_size = (SpecifierLabel)comboBoxSizeY.SelectedItem;
            ((RegionParameter)comboBoxPosX.Tag).pos[0]  = (float)numericUpDownPosX1.Value;
            ((RegionParameter)comboBoxPosX.Tag).pos[1]  = (float)numericUpDownPosX2.Value;
            ((RegionParameter)comboBoxPosY.Tag).pos[0]  = (float)numericUpDownPosY1.Value;
            ((RegionParameter)comboBoxPosY.Tag).pos[1]  = (float)numericUpDownPosY2.Value;
            ((RegionParameter)comboBoxPosX.Tag).size[0] = (float)numericUpDownSizeX1.Value;
            ((RegionParameter)comboBoxPosX.Tag).size[1] = (float)numericUpDownSizeX2.Value;
            ((RegionParameter)comboBoxPosY.Tag).size[0] = (float)numericUpDownSizeY1.Value;
            ((RegionParameter)comboBoxPosY.Tag).size[1] = (float)numericUpDownSizeY2.Value;

            // Save end condition
            timeEnd.TimeLimit = (double)numericUpDownEndSeconds.Value;            
            buttonEnd.Button = (Button)comboBoxEndButton.SelectedIndex;
            switch (comboBoxEndCondition.SelectedIndex)
            {
                case 0:  // Button Press
                    task.endCondition = buttonEnd;
                    break;
                case 1:  // Time Limit
                    timeEnd.Type = TimeLimitType.TotalTime;
                    task.endCondition = timeEnd;
                    break;
                case 2:  // Time In Region
                    timeEnd.Type = TimeLimitType.TimeInRegion;
                    task.endCondition = timeEnd;
                    break;
                case 3:  // Time Out of Region
                    timeEnd.Type = TimeLimitType.TimeOutRegion;
                    task.endCondition = timeEnd;
                    break;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonAddInput_Click(object sender, EventArgs e)
        {
            InputDevice primary = (InputDevice)comboBoxInputDevice.SelectedItem;
            InputDevice[] unused = Input2D.GetUnusedInputs(primary, additionalInputs);
            FormAddInputs f = new FormAddInputs(unused);
			f.Tag = this.Tag;
            DialogResult result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                additionalInputs.Add((InputDevice)f.GetSelectedInput());
            }
            listBoxAdditionalInputs.DataSource = null;
            listBoxAdditionalInputs.DataSource = additionalInputs;
        }

        private void buttonRemoveInput_Click(object sender, EventArgs e)
        {
            InputDevice item = (InputDevice)listBoxAdditionalInputs.SelectedItem;
            if (item != null)
            {
                additionalInputs.Remove(item);
                listBoxAdditionalInputs.DataSource = null;
                listBoxAdditionalInputs.DataSource = additionalInputs;
            }
        }

        private void checkBoxEnableRegion_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = checkBoxEnableRegion.Checked;
        }
        private void comboBoxPosX_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxPosX.SelectedIndex)
            {
                case 0:
                    labelPosX1.Text = "Value";
                    labelPosX2.Visible = false;
                    numericUpDownPosX1.Visible = false;
                    break;
                case 1:
                    labelPosX1.Text = "Start";
                    labelPosX2.Visible = true;
                    labelPosX2.Text = "End";
                    numericUpDownPosX1.Visible = true;
                    break;
                case 2:
                    labelPosX1.Text = "Min";
                    labelPosX2.Visible = true;
                    labelPosX2.Text = "Max";
                    numericUpDownPosX1.Visible = true;
                    break;
            }
        }

        private void comboBoxPosY_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxPosY.SelectedIndex)
            {
                case 0:
                    labelPosY1.Text = "Value";
                    labelPosY2.Visible = false;
                    numericUpDownPosY1.Visible = false;
                    break;
                case 1:
                    labelPosY1.Text = "Start";
                    labelPosY2.Visible = true;
                    labelPosY2.Text = "End";
                    numericUpDownPosY1.Visible = true;
                    break;
                case 2:
                    labelPosY1.Text = "Min";
                    labelPosY2.Visible = true;
                    labelPosY2.Text = "Max";
                    numericUpDownPosY1.Visible = true;
                    break;
            }
        }

        private void comboBoxSizeX_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxSizeX.SelectedIndex)
            {
                case 0:
                    labelSizeX1.Text = "Value";
                    labelSizeX2.Visible = false;
                    numericUpDownSizeX1.Visible = false;
                    break;
                case 1:
                    labelSizeX1.Text = "Start";
                    labelSizeX2.Visible = true;
                    labelSizeX2.Text = "End";
                    numericUpDownSizeX1.Visible = true;
                    break;
                case 2:
                    labelSizeX1.Text = "Min";
                    labelSizeX2.Visible = true;
                    labelSizeX2.Text = "Max";
                    numericUpDownSizeX1.Visible = true;
                    break;
            }
        }

        private void comboBoxSizeY_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxSizeY.SelectedIndex)
            {
                case 0:
                    labelSizeY1.Text = "Value";
                    labelSizeY2.Visible = false;
                    numericUpDownSizeY1.Visible = false;
                    break;
                case 1:
                    labelSizeY1.Text = "Start";
                    labelSizeY2.Visible = true;
                    labelSizeY2.Text = "End";
                    numericUpDownSizeY1.Visible = true;
                    break;
                case 2:
                    labelSizeY1.Text = "Min";
                    labelSizeY2.Visible = true;
                    labelSizeY2.Text = "Max";
                    numericUpDownSizeY1.Visible = true;
                    break;
            }
        }

        private void comboBoxEndCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxEndCondition.SelectedIndex)
            {
                case 0:  // Button Press
                    labelEndSeconds.Visible = false;
                    numericUpDownEndSeconds.Visible = false;
                    comboBoxEndButton.Visible = true;
                    break;
                case 1:  // Time Limit
                    labelEndSeconds.Visible = true;
                    numericUpDownEndSeconds.Visible = true;
                    comboBoxEndButton.Visible = false;
                    break;
                case 2:  // Time in Region
                    labelEndSeconds.Visible = true;
                    numericUpDownEndSeconds.Visible = true;
                    comboBoxEndButton.Visible = false;
                    break;
                case 3:  // Time out of Region
                    labelEndSeconds.Visible = true;
                    numericUpDownEndSeconds.Visible = true;
                    comboBoxEndButton.Visible = false;
                    break;
            }
        }

        private void Form2DTask_Load(object sender, EventArgs e)
        {
			if (prevLocation == null || prevLocation.X == 0 && prevLocation.Y == 0)
			{
				Point center = ((FormMain)this.Tag).getCenterPosition();
				Point newPosition = new Point();
				newPosition.X = center.X - this.Width / 2;
				newPosition.Y = center.Y - this.Height / 2;
				if (newPosition.Y < 1)
					newPosition.Y = 1;
				if (newPosition.X < 1)
					newPosition.X = 1;
				this.Location = newPosition;
			}
			else
				this.Location = prevLocation;
        }

		private void Form2DTask_FormClosing(object sender, FormClosingEventArgs e)
		{
			prevLocation = this.Location;
		}
    }
}
