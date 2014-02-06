using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TheraWii
{
    public partial class FormNewProfile : Form
    {
        private DataModel dm;
        private bool rename;
        private Profile p;
		private static Point prevLocation;

        public FormNewProfile(DataModel dm)
        {
            InitializeComponent();
            this.dm = dm;
            rename = false;
			p = new Profile();
        }

        public FormNewProfile(DataModel dm, Profile p)
        {
            this.p = p;
            InitializeComponent();
            this.Name = "Rename Profile";
            this.labelInstruct.Text = "Please enter a unique name for the profile";
            this.textBoxName.Text = p.Name;
            this.dm = dm;
            rename = true;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length != 0 && ( (textBoxName.Text.IndexOfAny(System.IO.Path.GetInvalidPathChars())) == -1))
            {
                String newPath = Path.Combine(DataStorage.DATA_STORE_FOLDER, textBoxName.Text);

                if (rename)
                {
					if (dm.isProfileNameUnique(textBoxName.Text) && !System.IO.Directory.Exists(newPath))
                    {
                        p.Rename(textBoxName.Text);
                        this.Close();
                    }
                    else if (p.Name == textBoxName.Text)
                    {
                        this.Close();
                    }
                    else
                    {
                        this.labelInstruct.Text = "ERROR:  PROFILE/FOLDER NAME" +
                            " ALREADY IN USE.\n\nPlease try again.";
                    }
                }
                else
                {
                    if (dm.isProfileNameUnique(textBoxName.Text) && !System.IO.Directory.Exists(newPath))
					{
                        p.initialize(textBoxName.Text);
                        dm.Profiles.Add(p);
                        dm.Profiles.Sort();
                        this.Close();
                    }
                    else
                    {
						
						this.labelInstruct.ForeColor = System.Drawing.Color.Red;
                        this.labelInstruct.Text = "ERROR:  PROFILE/FOLDER NAME\n" +
                            "ALREADY IN USE.\nPlease try again.";
                    }
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FormNewProfile_KeyPress(object sender, KeyPressEventArgs e)
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

		private void FormNewProfile_Load(object sender, EventArgs e)
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

		private void FormNewProfile_FormClosing(object sender, FormClosingEventArgs e)
		{
			prevLocation = this.Location;
		}
    }
}