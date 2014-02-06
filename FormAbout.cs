using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TheraWii
{
    public partial class FormAbout : Form
    {
		private static Point prevLocation;
		public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                okButton_Click(this, new EventArgs());
            }
            else if (e.KeyChar.Equals(Convert.ToChar(27)))
            {
                okButton_Click(this, new EventArgs());
            }
        }

		private void FormAbout_Load(object sender, EventArgs e)
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

		private void FormAbout_FormClosing(object sender, FormClosingEventArgs e)
		{
			prevLocation = this.Location;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(linkLabel1.Text);
		}
     }
}