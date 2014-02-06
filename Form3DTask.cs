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
    public partial class Form3DTask : Form
    {
        private Task3D task;
        private ButtonEndCondition buttonEnd;
        private TimeLimitEndCondition timeEnd;
        private List<InputDevice> additionalInputs;
		private static Point prevLocation;

        public Form3DTask(Task3D t)
        {
            InitializeComponent();
            comboBoxInputDevice.DataSource = Input3D.GetPossibleInputs();
            comboBoxEndButton.DataSource = ButtonEndCondition.ButtonText;
            comboBoxPerformanceMetric.DataSource = PerformanceMetrics.PerformanceMetricStrings;
			comboBoxShape.DataSource = new ShapeType[] { ShapeType.Cuboid, ShapeType.Ellipsoid };
			SpecifierLabel[] SpecifierLabels = new SpecifierLabel[] 
			{ 
				SpecifierLabel.Static, SpecifierLabel.Dynamic, 
				SpecifierLabel.Random
			};
			comboBoxPosX.BindingContext = new BindingContext();
			comboBoxPosX.DataSource = SpecifierLabels;
			comboBoxPosY.BindingContext = new BindingContext();
			comboBoxPosY.DataSource = SpecifierLabels;
			comboBoxPosZ.BindingContext = new BindingContext();
			comboBoxPosZ.DataSource = SpecifierLabels;
			comboBoxSizeX.BindingContext = new BindingContext();
			comboBoxSizeX.DataSource = SpecifierLabels;
			comboBoxSizeY.BindingContext = new BindingContext();
			comboBoxSizeY.DataSource = SpecifierLabels;
			comboBoxSizeZ.BindingContext = new BindingContext();
			comboBoxSizeZ.DataSource = SpecifierLabels;


            // Load Form from task data
            task = t;
            textBoxName.Text = task.Name;

            // Input loading
            comboBoxInputDevice.SelectedIndex = Input3D.GetInputIndex(task.primaryInput);
            additionalInputs = new List<InputDevice>();
            if (task.additionalInput != null)
                additionalInputs.AddRange(task.additionalInput);
            listBoxAdditionalInputs.DataSource = additionalInputs;

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
				comboBoxPosX.SelectedItem = ((RegionParameter)t.region.rParams[regPT.X]).SL_pos;
				comboBoxPosY.SelectedItem = ((RegionParameter)t.region.rParams[regPT.Y]).SL_pos;
				comboBoxPosZ.SelectedItem = ((RegionParameter)t.region.rParams[regPT.Z]).SL_pos;
				comboBoxSizeX.SelectedItem = ((RegionParameter)t.region.rParams[regPT.X]).SL_size;
				comboBoxSizeY.SelectedItem = ((RegionParameter)t.region.rParams[regPT.Y]).SL_size;
				comboBoxSizeZ.SelectedItem = ((RegionParameter)t.region.rParams[regPT.Z]).SL_size;
                numericUpDownPosX1.Value = (decimal)((RegionParameter)t.region.rParams[regPT.X]).pos[0];
                numericUpDownPosX2.Value = (decimal)((RegionParameter)t.region.rParams[regPT.X]).pos[1];
                numericUpDownPosY1.Value = (decimal)((RegionParameter)t.region.rParams[regPT.Y]).pos[0];
                numericUpDownPosY2.Value = (decimal)((RegionParameter)t.region.rParams[regPT.Y]).pos[1];
                numericUpDownPosZ1.Value = (decimal)((RegionParameter)t.region.rParams[regPT.Y]).pos[0];
                numericUpDownPosZ2.Value = (decimal)((RegionParameter)t.region.rParams[regPT.Y]).pos[1];
                numericUpDownSizeX1.Value = (decimal)((RegionParameter)t.region.rParams[regPT.X]).size[0];
                numericUpDownSizeX2.Value = (decimal)((RegionParameter)t.region.rParams[regPT.X]).size[1];
                numericUpDownSizeY1.Value = (decimal)((RegionParameter)t.region.rParams[regPT.Y]).size[0];
                numericUpDownSizeY2.Value = (decimal)((RegionParameter)t.region.rParams[regPT.Y]).size[1];
                numericUpDownSizeZ1.Value = (decimal)((RegionParameter)t.region.rParams[regPT.Z]).size[0];
                numericUpDownSizeZ2.Value = (decimal)((RegionParameter)t.region.rParams[regPT.Z]).size[1];
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
                comboBoxEndCondition.SelectedIndex = 1;
            }
            numericUpDownEndSeconds.Value = (decimal)timeEnd.TimeLimit;
            comboBoxEndButton.SelectedIndex = (int)buttonEnd.Button;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            task.Name = textBoxName.Text;

            // Save Input
            task.primaryInput = (InputDevice)comboBoxInputDevice.SelectedItem;
            task.additionalInput = additionalInputs;

            // Save performance metric
            task.performanceMetric = (PerformanceMetricType)comboBoxPerformanceMetric.SelectedIndex;

            // Save Region
            task.regionEnabled = checkBoxEnableRegion.Checked;
			task.region.Shape = (ShapeType)comboBoxShape.SelectedItem;
            //task.region.posx.sLabel = (RegionParameter.SpecifierLabel)comboBoxPosX.SelectedItem;
            //task.region.posy.sLabel = (RegionParameter.SpecifierLabel)comboBoxPosY.SelectedItem;
            //task.region.posz.sLabel = (RegionParameter.SpecifierLabel)comboBoxPosZ.SelectedItem;
            //task.region.sizex.sLabel = (RegionParameter.SpecifierLabel)comboBoxSizeX.SelectedItem;
            //task.region.sizey.sLabel = (RegionParameter.SpecifierLabel)comboBoxSizeY.SelectedItem;
            //task.region.sizez.sLabel = (RegionParameter.SpecifierLabel)comboBoxSizeZ.SelectedItem;
            //task.region.posx.param[0] = (float)numericUpDownPosX1.Value;
            //task.region.posx.param[1] = (float)numericUpDownPosX2.Value;
            //task.region.posy.param[0] = (float)numericUpDownPosY1.Value;
            //task.region.posy.param[1] = (float)numericUpDownPosY2.Value;
            //task.region.posz.param[0] = (float)numericUpDownPosZ1.Value;
            //task.region.posz.param[1] = (float)numericUpDownPosZ2.Value;
            //task.region.sizex.param[0] = (float)numericUpDownSizeX1.Value;
            //task.region.sizex.param[1] = (float)numericUpDownSizeX2.Value;
            //task.region.sizey.param[0] = (float)numericUpDownSizeY1.Value;
            //task.region.sizey.param[1] = (float)numericUpDownSizeY2.Value;
            //task.region.sizez.param[0] = (float)numericUpDownSizeZ1.Value;
            //task.region.sizez.param[1] = (float)numericUpDownSizeZ2.Value;

            // Save end condition
            timeEnd.TimeLimit = (double)numericUpDownEndSeconds.Value;
            buttonEnd.Button = (Button)comboBoxEndButton.SelectedIndex;
            switch (comboBoxEndCondition.SelectedIndex)
            {
                case 0:  // Button Press
                    task.endCondition = buttonEnd;
                    break;
                case 1:  // Time Limit
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
            InputDevice[] unused = Input3D.GetUnusedInputs(primary, additionalInputs);
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

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxInputHandling_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxPerformanceMetric_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxEnableRegion_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = checkBoxEnableRegion.Checked;
        }

        private void comboBoxShape_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void numericUpDownPosX1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownPosX2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownPosY1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownPosY2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownSizeX1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownSizeX2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownSizeY1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownSizeY2_ValueChanged(object sender, EventArgs e)
        {

        }

       
        private void comboBoxPosZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxPosZ.SelectedIndex)
            {
                case 0:
                    labelPosZ1.Text = "Value";
                    labelPosZ2.Visible = false;
                    numericUpDownPosZ1.Visible = false;
                    break;
                case 1:
                    labelPosZ1.Text = "Start";
                    labelPosZ2.Visible = true;
                    labelPosZ2.Text = "End";
                    numericUpDownPosZ1.Visible = true;
                    break;
                case 2:
                    labelPosZ1.Text = "Min";
                    labelPosZ2.Visible = true;
                    labelPosZ2.Text = "Max";
                    numericUpDownPosZ1.Visible = true;
                    break;
            }
        }

        private void comboBoxSizeZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxSizeZ.SelectedIndex)
            {
                case 0:
                    labelSizeZ1.Text = "Value";
                    labelSizeZ2.Visible = false;
                    numericUpDownSizeZ1.Visible = false;
                    break;
                case 1:
                    labelSizeZ1.Text = "Start";
                    labelSizeZ2.Visible = true;
                    labelSizeZ2.Text = "End";
                    numericUpDownSizeZ1.Visible = true;
                    break;
                case 2:
                    labelSizeZ1.Text = "Min";
                    labelSizeZ2.Visible = true;
                    labelSizeZ2.Text = "Max";
                    numericUpDownSizeZ1.Visible = true;
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
            }
        }

		private void Form3DTask_Load(object sender, EventArgs e)
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

		private void Form3DTask_FormClosing(object sender, FormClosingEventArgs e)
		{
			prevLocation = this.Location;
		}

    }
}