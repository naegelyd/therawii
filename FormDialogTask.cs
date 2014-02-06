using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TheraWii
{
    public partial class FormDialogTask : Form
    {
        private DialogTask task;
        private ButtonEndCondition buttonEnd;
        private TimeLimitEndCondition timeEnd;
		private static Point prevLocation;

        public FormDialogTask(DialogTask t)
        {
            InitializeComponent();
            comboBoxEndButton.DataSource = ButtonEndCondition.ButtonText;

            task = t;
            textBoxName.Text = task.Name;
            textBoxDisplayText.Text = task.DisplayText;

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

        private void buttonOk_Click(object sender, EventArgs e)
        {
            task.Name = textBoxName.Text;
            task.DisplayText = textBoxDisplayText.Text;

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

        private void FormDialogTask_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.ActiveControl != textBoxDisplayText && e.KeyChar.Equals(Convert.ToChar(13)))
            {
                buttonOk_Click(this, new EventArgs());
            }
            else if (e.KeyChar.Equals(Convert.ToChar(27)))
            {
                buttonCancel_Click(this, new EventArgs());
            }
        }

        private void FormDialogTask_Load(object sender, EventArgs e)
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

		private void FormDialogTask_FormClosing(object sender, FormClosingEventArgs e)
		{
			prevLocation = this.Location;
		}

    }
}