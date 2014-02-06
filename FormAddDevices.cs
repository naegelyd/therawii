using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TheraWii
{
    public partial class FormAddDevices : Form
    {
		private static Point prevLocation;
        public FormAddDevices(List<WiiType> inputs)
        {
            InitializeComponent();
            foreach (WiiType wi in inputs)
            {
                ListViewItem lvi = new ListViewItem(InputDevice.WiiTypeString[(int)wi]);
                lvi.Tag = wi;
                listViewInputs.Items.Add(lvi);
            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            bool allConnected = true;
            foreach (ListViewItem lvi in listViewInputs.Items)
            {
                // Query WiiUse for the device - assuming mouse is connected
                WiiUse.Connect();
                if ((WiiType)lvi.Tag != WiiType.Mouse)
                {
                    if (!WiiUse.IsConnected((WiiType)lvi.Tag))
                    {
                        allConnected = false;
                        lvi.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            if (allConnected)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormAddDevices_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                buttonAdd_Click(this, new EventArgs());
            }
            else if (e.KeyChar.Equals(Convert.ToChar(27)))
            {
                buttonCancel_Click(this, new EventArgs());
            }
        }

        private void FormAddDevices_DoubleClick(object sender, EventArgs e)
        {
            buttonAdd_Click(sender, e);
        }

		private void FormAddDevices_Load(object sender, EventArgs e)
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

		private void FormAddDevices_FormClosing(object sender, FormClosingEventArgs e)
		{
			prevLocation = this.Location;
		}
    }
}