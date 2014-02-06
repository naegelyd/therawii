using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TheraWii
{
    public partial class FormSessionDetail : Form
    {
		private static Point prevLocation;
        public FormSessionDetail(Session s)
        {
            InitializeComponent();
            try
            {
                displaySessionDetails(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormSessionDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(27)))
            {
                this.Close();
            }
        }

		private void FormSessionDetail_Load(object sender, EventArgs e)
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

		private void FormSessionDetail_FormClosing(object sender, FormClosingEventArgs e)
		{
			prevLocation = this.Location;
		}
    }
}