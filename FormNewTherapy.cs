using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TheraWii
{
    public partial class FormNewTherapy : Form
    {
        private DataModel dm;
		private static Point prevLocation;

        public FormNewTherapy(DataModel dm)
        {
            InitializeComponent();
            this.dm = dm;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length != 0)
            {
                Therapy t = new Therapy();
                t.Name = textBoxName.Text;
                dm.Therapies.Add(t);
                dm.Therapies.Sort();
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormNewTherapy_KeyPress(object sender, KeyPressEventArgs e)
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

		private void FormNewTherapy_Load(object sender, EventArgs e)
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

		private void FormNewTherapy_FormClosing(object sender, FormClosingEventArgs e)
		{
			prevLocation = this.Location;
		}

    }
}