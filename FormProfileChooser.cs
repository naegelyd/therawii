using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TheraWii
{
    public partial class FormProfileChooser : Form
    {
        private Form parent;
		private static Point prevLocation;
        public FormProfileChooser(List<Profile> profiles, Form f)
        {
            InitializeComponent();
            parent = f;
            //make sure users can only select one profile at a time
            listProfiles.SelectionMode = SelectionMode.One;
			this.listProfilesRefresh();
			if (listProfiles.Items.Count > 0)
			{
				listProfiles.SelectedIndex = 0;
				listProfiles.Select();
			}
        }

        public String getSelectedProfileName()
        {
            if (listProfiles.SelectedItem != null)
            {
                return listProfiles.SelectedItem.ToString();
            }
            else
            {
                return null;
            }
        }

        private void listProfilesRefresh()
        {
            listProfiles.Items.Clear();
            foreach (Profile p in ((FormMain)parent).dm.Profiles)
            {
                listProfiles.Items.Add(p.Name);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
			if (listProfiles.SelectedItems.Count == 1)
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddProfile_Click(object sender, EventArgs e)
        {
            Form f = new FormNewProfile(((FormMain)parent).dm);
			f.Tag = this.Tag;
            f.ShowDialog();
            ((FormMain)parent).ds.SerializeDataModel();
            ((FormMain)parent).listProfilesRefresh();
            this.listProfilesRefresh();
            if (this.listProfiles.Items.Count > 0)
                this.listProfiles.SelectedIndex = this.listProfiles.Items.Count - 1;
        }

        private void FormProfileChooser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                buttonOK_Click(this, new EventArgs());
            }
            else if (e.KeyChar.Equals(Convert.ToChar(27)))
            {
                buttonCancel_Click(this, new EventArgs());
            }
        }

        private void listProfiles_DoubleClick(object sender, EventArgs e)
        {
            buttonOK_Click(sender, e);
        }

		private void FormProfileChooser_Load(object sender, EventArgs e)
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

		private void FormProfileChooser_FormClosing(object sender, FormClosingEventArgs e)
		{
			prevLocation = this.Location;
		}
    }
}