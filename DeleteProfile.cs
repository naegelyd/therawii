using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TheraWii
{
    public partial class FormDeleteProfile : Form
    {
        private DataModel dm;

        public FormDeleteProfile(DataModel dm)
        {
            InitializeComponent();
            this.dm = dm;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length != 0)
            {
                Profile t = new Profile();
                t.initialize(textBoxName.Text);
                dm.Profiles.Add(t);
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}