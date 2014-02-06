using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TheraWii
{
    public partial class FormRepeatTask : Form
    {
        private RepeatTask rTask;
		private static Point prevLocation;

        public FormRepeatTask(RepeatTask t)
        {
            InitializeComponent();
			rTask = t;

			textBoxName.Text = rTask.Name;

            // Load Repeat settings
			numericUpDownRepetitions.Value = rTask.numRepeats;
			numericUpDownTimeLimit.Value = rTask.TimeLimit;
            switch (rTask.RepeatEndType)
            {
                case RepeatEndType.Repetitions:
                    radioButtonRepetitions.Checked = true;
                    numericUpDownRepetitions.Enabled = true;
                    numericUpDownTimeLimit.Enabled = false;
                    break;
                case RepeatEndType.TimeLimit:
                    radioButtonTimeLimit.Checked = true;
                    numericUpDownRepetitions.Enabled = false;
                    numericUpDownTimeLimit.Enabled = true;
                    break;
                case RepeatEndType.Both:
                    radioButtonBoth.Checked = true;
                    numericUpDownRepetitions.Enabled = true;
                    numericUpDownTimeLimit.Enabled = true;
                    break;
                default:
                    throw new System.Exception("Unknown RepeatEndType!");
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
			rTask.Name = textBoxName.Text;
			rTask.numRepeats = (int)numericUpDownRepetitions.Value;
			rTask.TimeLimit = (int)numericUpDownTimeLimit.Value;
			if (radioButtonBoth.Checked == true)
			{
				rTask.RepeatEndType = RepeatEndType.Both;
				rTask.endCondition = new Repeat_BothEndCondition();
				((Repeat_BothEndCondition)rTask.endCondition).Initialize(rTask.numRepeats, rTask.TimeLimit);
			}
			else if (radioButtonRepetitions.Checked == true)
			{
				rTask.RepeatEndType = RepeatEndType.Repetitions;
				rTask.endCondition = new Repeat_rEndCondition();
				((Repeat_rEndCondition)rTask.endCondition).Initialize(rTask.numRepeats);
			}
			else if (radioButtonTimeLimit.Checked == true)
			{
				rTask.RepeatEndType = RepeatEndType.TimeLimit;
				rTask.endCondition = new Repeat_tEndCondition();
				((Repeat_tEndCondition)rTask.endCondition).Initialize(rTask.TimeLimit);
			}
            else
            {
                throw new System.Exception("Repeat Task Radio Button error");
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void radioButtonRepetitions_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownRepetitions.Enabled = true;
            numericUpDownTimeLimit.Enabled = false;
        }

        private void radioButtonTimeLimit_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownRepetitions.Enabled = false;
            numericUpDownTimeLimit.Enabled = true;
        }

        private void radioButtonBoth_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownRepetitions.Enabled = true;
            numericUpDownTimeLimit.Enabled = true;
        }

        private void FormRepeatTask_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                buttonOk_Click(this, new EventArgs());
            }
            else if (e.KeyChar.Equals(Convert.ToChar(27)))
            {
                buttonCancel_Click(this, new EventArgs());
            }
        }

		private void FormRepeatTask_Load(object sender, EventArgs e)
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

		private void FormRepeatTask_FormClosing(object sender, FormClosingEventArgs e)
		{
			prevLocation = this.Location;
		}
    }
}