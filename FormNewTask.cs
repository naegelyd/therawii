using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TheraWii
{
    public partial class FormNewTask : Form
    {
        private Therapy therapy;
		private static Point prevLocation;

        public FormNewTask(Therapy t)
        {
            therapy = t;
            InitializeComponent();
        }

        private void NewTask_Load(object sender, EventArgs e)
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
			listBoxTasks.Select();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Task newTask;
            Form newTaskForm;
            switch (listBoxTasks.SelectedIndex)
            {
                case 0:
                    newTask = new DialogTask();
                    newTaskForm = new FormDialogTask((DialogTask) newTask);
                    break;
                case 1:
                    newTask = new Task2D();
                    newTaskForm = new Form2DTask((Task2D) newTask);
                    break;
                case 2:
                    newTask = new RepeatTask();
                    newTaskForm = new FormRepeatTask((RepeatTask) newTask);
                    break;
                default:
                    return;
            }
            this.Visible = false;
			newTaskForm.Tag = this.Tag;
            DialogResult result = newTaskForm.ShowDialog();
			if (result == DialogResult.OK)
			{
				//if the task name is left empty then set it to a generic name based on the task type
                if (newTask.Name == null || newTask.Name.Length == 0)
                {
                    switch (listBoxTasks.SelectedIndex)
                    {
                        case 0:
                            newTask.Name = "Dialog Task";
                            break;
                        case 1:
                            newTask.Name = "2D Task";
                            break;
                        case 2:
                            newTask.Name = "Repeat Task";
                            break;
                        default:
                            newTask.Name = "Task Name";
                            return;
                    }
                }
				therapy.addTask(newTask);
				this.DialogResult = DialogResult.OK;
			}
			else
				this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormNewTask_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                buttonCreate_Click(this, new EventArgs());
            }
            else if (e.KeyChar.Equals(Convert.ToChar(27)))
            {
                buttonCancel_Click(this, new EventArgs());
            }
        }

        private void listBoxTasks_DoubleClick(object sender, EventArgs e)
        {
            buttonCreate_Click(this, new EventArgs());
        }

        private void FormNewTask_DoubleClick(object sender, EventArgs e)
        {
            buttonCreate_Click(sender, e);
        }

		private void FormNewTask_FormClosing(object sender, FormClosingEventArgs e)
		{
			prevLocation = this.Location;
		}

    }
}