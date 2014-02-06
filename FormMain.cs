using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;

namespace TheraWii
{
    public partial class FormMain : Form
    {
        public DataStorage ds;
        public DataModel dm;
        private Therapy selectedTherapy, tempCopyTherapy;
		private Task tempCopyTask;
        private Profile selectedProfile;
		private bool lvP, lvS, lvT, tvT;
		private enum CopyCut { copyTherapy, copyTask };
		private CopyCut editAction;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ds = new DataStorage();
            dm = ds.DataModel;
			lvP = false;
			lvS = false;

            listProfilesRefresh();
            listTherapiesRefresh();
            listTherapies.SelectedIndex = -1;
            treeViewTasksRefresh();
            //disable the Session buttons, they will be enabled when a profile is selected
            splitContainer2.Panel2.Enabled = false;
            playFullscreenToolStripMenuItem.Checked = dm.PlayFullscreen;

            // !!!! Skip GUI while debugging game
            /*
            selectedProfile = dm.Profiles[0];
            selectedTherapy = dm.Therapies[0];
            Thread thread = new Thread(new ThreadStart(RunXna));
            thread.Name = "TheraWii Game";
            thread.Start();
            Application.Exit();
            */

            /* WiiUse testing */
            int found = WiiUse.Connect();
            Console.WriteLine("Found {0} wiimotes", found);
            Console.WriteLine("Wiimote " + WiiUse.IsConnected(WiiType.Remote));
            Console.WriteLine("Nunchuck " + WiiUse.IsConnected(WiiType.Nunchuck));
            Console.WriteLine("Balance Board " + WiiUse.IsConnected(WiiType.BalanceBoard));
			//getCenterPosition();
        }

		public Point getCenterPosition()
		{
			Point p = this.Location;
			p.X += (this.Width / 2);
			p.Y += (this.Height / 2);
			return p;
		}

        private void listTherapiesRefresh()
        {
            listTherapies.DataSource = null;
            listTherapies.DataSource = dm.Therapies;
            listTherapies.DisplayMember = "Name";
        }

        private void treeViewTasksRefresh()
        {
            Therapy ther = (Therapy) listTherapies.SelectedItem;
            treeViewTasks.Nodes.Clear();
            if (ther == null)
            {
                splitContainer1.Panel2.Enabled = false;
            }
            else
            {
                splitContainer1.Panel2.Enabled = true;
                treeViewTasks.BeginUpdate();
                TreeNode[] nodes = ther.GetTaskTreeNodes();
                treeViewTasks.Nodes.AddRange(nodes);
                treeViewTasks.EndUpdate();
                treeViewTasks.ExpandAll();
            }
        }

        private void aboutTheraWiiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form About = new FormAbout();
			About.Tag = this;
            About.Show();
        }

        private void buttonViewSession_Click(object sender, EventArgs e)
        {
            if (listViewProfiles.SelectedItems.Count > 0 && listViewSessions.SelectedItems.Count >= 1)
            {
                Session s = (Session)listViewSessions.SelectedItems[0].Tag;
                Form SessDetail = new FormSessionDetail(s);
				SessDetail.Tag = this;
                SessDetail.Show();
                listViewSessions.Select();
            }
        }

        private void exportTherapyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( selectedTherapy != null )
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "TheraWii Therapy (*.twf)|*.twf|All Files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ds.SerializeTherapy(saveFileDialog1.FileName, selectedTherapy);
                }
            }
            else
            {
                MessageBox.Show("Error: No Therapy selected.\nPlease select a Therapy from the Therapy Editor tab.", "Export Therapy", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedProfile != null)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "TheraWii Profile (*.twp.zip)|*.twp.zip|All Files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ds.SerializeProfile(saveFileDialog1.FileName, selectedProfile);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Export error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error: No Profile selected.\nPlease select a Profile from the Profile Management tab.", "Export Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void importTherapyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "TheraWii Therapy (*.twf)|*.twf|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Therapy t = new Therapy();
                try
                {
                    ds.DeserializeTherapy(openFileDialog1.FileName, ref t);
                    dm.Therapies.Add(t);
                    ds.SerializeDataModel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Import error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                listTherapiesRefresh();
                listTherapies.SelectedIndex = listTherapies.Items.Count - 1;
            }
        }

        private void importProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "TheraWii Profile (*.twp.zip)|*.twp.zip|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Profile p = new Profile();
                try
                {
                    ds.DeserializeProfile(openFileDialog1.FileName, ref p);
                    dm.Profiles.Add(p);
                    ds.SerializeDataModel(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Import error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                listProfilesRefresh();
                listViewProfiles.Select();
                if (listViewProfiles.Items.Count > 0)
                {
                    listViewProfiles.Items[listViewProfiles.Items.Count - 1].Selected = true;
                    listViewProfiles.Items[listViewProfiles.Items.Count - 1].Focused = true;
                }
            }
        }

        private void buttonExportSession_Click(object sender, EventArgs e)
        {
            if (listViewProfiles.SelectedItems.Count > 0)
            {
                if (listViewSessions.SelectedItems.Count > 0)
                {
                    Session s = (Session)listViewSessions.SelectedItems[0].Tag;

                    //Open file for reading
					SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Comma Separated Values (*.csv)|*.csv|All Files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.RestoreDirectory = true;
					saveFileDialog1.InitialDirectory = Environment.GetFolderPath( Environment.SpecialFolder.Desktop);
					saveFileDialog1.FileName = s.dataFile;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        String saveFile = saveFileDialog1.FileName;
                        try
                        {
                            DScsv.exportSession(s, saveFile);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Export error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    listViewSessions.Select();
                }
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

		private void buttonAddTask_Click(object sender, EventArgs e)
		{
			TreeNode t = treeViewTasks.SelectedNode;
			List<int> path = new List<int>();
			Form newTaskForm = new FormNewTask((Therapy)listTherapies.SelectedItem);
			newTaskForm.Tag = this;
			DialogResult r = newTaskForm.ShowDialog();
			if (r == DialogResult.OK)
			{
				//are we adding to a repeat task?
				if (treeViewTasks.SelectedNode != null && (treeViewTasks.SelectedNode.Tag.GetType() == typeof(RepeatTask) || treeViewTasks.SelectedNode.Parent != null))
				{
					t = treeViewTasks.SelectedNode;
					Task newTask = selectedTherapy.tasks.tasks[selectedTherapy.tasks.Count - 1];
					// nest the new task under the repeat task
					if (t.Tag.GetType() == typeof(RepeatTask))
					{
						((RepeatTask)t.Tag).addTask(newTask);
						selectedTherapy.tasks.tasks.RemoveAt(selectedTherapy.tasks.Count - 1);
					}
					// we selected a sibling, add newtask to the parent repeat task
					else
					{
						((RepeatTask)t.Parent.Tag).addTask(newTask);
						selectedTherapy.tasks.tasks.RemoveAt(selectedTherapy.tasks.Count - 1);
					}
				}
				// preserve the node's location
                if (t != null)
                {
                    path.Add(t.Index);
                    while (t.Parent != null)
                    {
                        t = t.Parent;
                        path.Add(t.Index);
                    }
                }
				ds.SerializeDataModel();
				treeViewTasksRefresh();

				// select the previously selected node
                if (t != null)
                {
                    t = treeViewTasks.Nodes[path[path.Count - 1]];
                    for (int iter = path.Count - 2; iter >= 0; --iter)
                    {
                        t = t.Nodes[path[iter]];
                    }
                    if (t.Tag.GetType() == typeof(RepeatTask) && t.GetNodeCount(false) > 0)
                        treeViewTasks.SelectedNode = t.Nodes[t.GetNodeCount(false) - 1];
                    else if (t.NextNode != null)
                    {
                        treeViewTasks.SelectedNode = t;
                        while (treeViewTasks.SelectedNode.NextNode != null)
                        {
                            treeViewTasks.SelectedNode = treeViewTasks.SelectedNode.NextNode;
                        }
                    }
                    else
                        treeViewTasks.SelectedNode = t;
                }
			}
			treeViewTasks.Select();
		}

        private void buttonAddTherapy_Click(object sender, EventArgs e)
        {
            FormNewTherapy f = new FormNewTherapy(dm);
			f.Tag = this;
            f.ShowDialog();
			ds.SerializeDataModel();
            listTherapiesRefresh();
			listTherapies.SelectedIndex = listTherapies.Items.Count - 1;
        }

        private void buttonDeleteTherapy_Click(object sender, EventArgs e)
        {
            Therapy t = (Therapy)listTherapies.SelectedItem;
			int i = listTherapies.SelectedIndex;
            if (t != null)
            {
                string message = String.Format("Are you sure you want to delete \"{0}\"?", t);
                string caption = "Confirm Delete";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    dm.removeTherapy(t);
					ds.SerializeDataModel();
                    listTherapiesRefresh();
                }
            }
			if (listTherapies.Items.Count > 0)
			{
				if (i < listTherapies.Items.Count)
					listTherapies.SelectedIndex = i;
				else
					listTherapies.SelectedIndex = listTherapies.Items.Count - 1;
			}
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            //create a dialog window to connect devices, then move onto profile select
            selectedProfile = null;
            if (listTherapies.SelectedItem != null && ((Therapy)listTherapies.SelectedItem).tasks.Count > 0)
            {
                using (FormAddDevices fad = new FormAddDevices(((Therapy)listTherapies.SelectedItem).getRequiredDevices()))
                {
					fad.Tag = this;
                    if (fad.ShowDialog() == DialogResult.OK)
                    {
                        // create a dialog window to get the profile to use for the game
                        using (FormProfileChooser fpc = new FormProfileChooser(dm.Profiles, this))
                        {
							fpc.Tag = this;
                            if (fpc.ShowDialog() == DialogResult.OK)
                            {
                                String selectedName = fpc.getSelectedProfileName();
                                if (selectedName == null)
                                {
                                    selectedProfile = null;
                                }
                                foreach (Profile p in dm.Profiles)
                                {
                                    if (p.Name.CompareTo(selectedName) == 0)
                                    {
                                        selectedProfile = p;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                string caption = "Therapy Required";
                DialogResult result = MessageBox.Show("Could not start Therapy. Please make sure that:\n\n  1. A Therapy is selected.\n  2. The selected Therapy contains at least one task.", caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            if (listTherapies.SelectedItem != null && selectedProfile != null)
            {
                //Console.WriteLine(selectedProfile + "\n");
                selectedTherapy = (Therapy)listTherapies.SelectedItem;
				Thread thread = new Thread(new ThreadStart(RunXna));
				thread.Name = "TheraWii Game";
				thread.Start();
				thread.Join();
				ds.SerializeDataModel();
            }
        }

        public void RunXna()
        {
            Game game = new Game(selectedTherapy, selectedProfile, dm.PlayFullscreen);
            game.Run();
        }

        private void listTherapies_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTherapy = (Therapy)listTherapies.SelectedItem;
            treeViewTasksRefresh();
        }

        private void buttonEditTask_Click(object sender, EventArgs e)
        {
			int i = -1;
            if (treeViewTasks.SelectedNode != null)
            {
				i = treeViewTasks.SelectedNode.Index;
                Task t = (Task)treeViewTasks.SelectedNode.Tag;
                Form f = t.GetTaskForm();
				f.Tag = this;
                f.ShowDialog();
                treeViewTasksRefresh();
                ds.SerializeDataModel();
				if (treeViewTasks.Nodes.Count > 0)
				{
					if (i < treeViewTasks.Nodes.Count)
						treeViewTasks.SelectedNode = treeViewTasks.Nodes[i];
					else
						treeViewTasks.SelectedNode = treeViewTasks.Nodes[treeViewTasks.Nodes.Count - 1];
					treeViewTasks.Select();
				}
            }

        }

        private void buttonDeleteTask_Click(object sender, EventArgs e)
        {
			TreeNode t = treeViewTasks.SelectedNode;
			int i = -1;
			int io = -1;
            if (t != null)
            {
				io = t.Index;
				// Set Node to select after delete
				if (t.Parent == null && t.NextNode != null)
					i = t.Index;  //t.index and not NextNode because we're deleting t.
				else if (t.Parent == null && t.NextNode == null && t.PrevNode != null)
					i = t.PrevNode.Index;
				else if (t.Parent != null)
				{
					TreeNode r = treeViewTasks.SelectedNode;
					while (r.Parent != null)
						r = r.Parent;
					i = r.Index;
				}

				string message = String.Format("Are you sure you want to delete \"{0}\"?", t.Text);
				string caption = "Confirm Delete";
				DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes)
				{
					if (t.Parent != null && t.Parent.Tag.GetType() == typeof(RepeatTask))
					{
						((RepeatTask)t.Parent.Tag).removeTask((Task)t.Tag);
					}
					else
					{
						((Therapy)listTherapies.SelectedItem).removeTask((Task)(treeViewTasks.SelectedNode.Tag));
					}
					ds.SerializeDataModel();
					treeViewTasksRefresh();
				}
				else
					i = io;
            }
			if (treeViewTasks.Nodes.Count > 0)
			{
                if (0 <= i && i < treeViewTasks.Nodes.Count)
                {
                    treeViewTasks.SelectedNode = treeViewTasks.Nodes[i];
                    treeViewTasks.Select();
                }
			}
        }

        public void listProfilesRefresh()
        {
            listViewProfiles.Items.Clear();
            foreach(Profile p in dm.Profiles)
            {
                listViewProfiles.Items.Add(p.getListViewItem());
            }
			if (listViewProfiles.Tag == null)
				listViewProfiles.Tag = 0;
			listViewProfiles.ListViewItemSorter = new ListComparer((int)listViewProfiles.Tag);
        }

        public void buttonAddProfile_Click(object sender, EventArgs e)
        {
			Form f = new FormNewProfile(dm);
			f.Tag = this;
            f.ShowDialog();
			ds.SerializeDataModel();
            listProfilesRefresh();
			listViewProfiles.Select();
			if (listViewProfiles.Items.Count > 0)
			{
				listViewProfiles.Items[listViewProfiles.Items.Count - 1].Selected = true;
				listViewProfiles.Items[listViewProfiles.Items.Count - 1].Focused = true;
			}
        }

        private void buttonDeleteProfile_Click(object sender, EventArgs e)
        {
			int i = -1;
            if (listViewProfiles.SelectedItems.Count > 0)
            {
				i = listViewProfiles.SelectedIndices[0];
                Profile p = (Profile)listViewProfiles.SelectedItems[0].Tag;
                string message = String.Format("Are you sure you want to delete \"{0}\"?\n\n" +
                    "WARNING:  THIS WILL DELETE ALL SESSION DATA ASSOCIATED WITH \"{0}\""
                    , p);
                string caption = "Confirm Delete";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    p.delete();
                    dm.removeProfile(p);
                    listViewProfiles.Items.Remove(listViewProfiles.SelectedItems[0]);
                    ds.SerializeDataModel();
                    listProfilesRefresh();
                }
                listViewSessions.Items.Clear();
            }
			if (listViewProfiles.Items.Count > 0)
			{
				if (i < listViewProfiles.Items.Count)
				{
					listViewProfiles.Items[i].Selected = true;
					listViewProfiles.Items[i].Focused = true;
				}
				else
				{
					listViewProfiles.Items[listViewProfiles.Items.Count - 1].Selected = true;
					listViewProfiles.Items[listViewProfiles.Items.Count - 1].Focused = true;
				}
				listViewProfiles.Select();
			}
        }

        private void buttonEditProfile_Click(object sender, EventArgs e)
        {
			int i = -1;
            if (listViewProfiles.SelectedItems.Count > 0)
            {
				i = listViewProfiles.SelectedIndices[0];
                Form f = new FormNewProfile(dm, ((Profile)listViewProfiles.SelectedItems[0].Tag));
				f.Tag = this;
                f.ShowDialog();
                ds.SerializeDataModel();
                listProfilesRefresh();

				listViewProfiles.Items[i].Selected = true;
				listViewProfiles.Items[i].Focused = true;
				listViewProfiles.Select();
            }
        }

        private void buttonDeleteSession_Click(object sender, EventArgs e)
        {
			int ii = -1;
            if (listViewSessions.SelectedItems.Count > 0)
            {
				ii = listViewSessions.SelectedIndices[0];
				string message = String.Format("Are you sure you want to delete session #\"{0}\"?", listViewSessions.SelectedItems[0].Text);
				string caption = "Confirm Delete";
				DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes)
				{
					ListViewItem lvi = (ListViewItem)listViewSessions.SelectedItems[0];
					((Profile)listViewProfiles.SelectedItems[0].Tag).deleteSession((Session)lvi.Tag);
					listViewSessions.Items.Remove(lvi);

					ds.SerializeDataModel();

					//just to make sure session list is in sync with serialized data model
					int i = listViewProfiles.SelectedIndices[0];
					listProfilesRefresh();
					listViewProfiles.Items[i].Selected = false;
					listViewProfiles.Select();
					listViewProfiles.Items[i].Selected = true;
					listViewProfiles.Select();
					if (ii < listViewSessions.Items.Count)
					{
						listViewSessions.Items[ii].Selected = false;
						listViewSessions.Select();
						listViewSessions.Items[ii].Selected = true;
						listViewSessions.Select();
					}
					else if (listViewSessions.Items.Count > 0)
					{
						listViewSessions.Items[listViewSessions.Items.Count - 1].Selected = false;
						listViewSessions.Select();
						listViewSessions.Items[listViewSessions.Items.Count - 1].Selected = true;
						listViewSessions.Select();
					}
				}
            }
        }

        private void listViewProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView l = (ListView)sender;
            if (l.SelectedItems.Count > 0)
            {
                listViewSessions.Items.Clear();
                Profile p = (Profile)l.SelectedItems[0].Tag;
                selectedProfile = p;
                ListView.ListViewItemCollection lc = p.getSessionList(listViewSessions);
				if (listViewSessions.Tag == null)
					listViewSessions.Tag = 0;
				listViewSessions.ListViewItemSorter = new ListComparer((int)listViewSessions.Tag);
                splitContainer2.Panel2.Enabled = true;
            }
            else
            {
                listViewSessions.Items.Clear();
                splitContainer2.Panel2.Enabled = false;
            }
        }

        private void buttonTaskMoveUp_Click(object sender, EventArgs e)
        {
            TreeNode t = treeViewTasks.SelectedNode;
            List<int> path = new List<int>();
            if (treeViewTasks.SelectedNode != null)
            {
                path.Add(t.Index);
                while (t.Parent != null)
                {
                    t = t.Parent;
                    path.Add(t.Index);
                }
                path = ((Therapy)listTherapies.SelectedItem).MoveUp(path);
                treeViewTasksRefresh();

                t = treeViewTasks.Nodes[path[path.Count - 1]];
                for (int iter = path.Count - 2; iter >= 0; --iter)
                {
                    t = t.Nodes[path[iter]];
                }
                treeViewTasks.SelectedNode = t;
            }
            treeViewTasks.Select();
            ds.SerializeDataModel();
        }

        private void buttonTaskMoveDown_Click(object sender, EventArgs e)
        {
            TreeNode t = treeViewTasks.SelectedNode;
            List<int> path = new List<int>();
            if (treeViewTasks.SelectedNode != null)
            {
                path.Add(t.Index);
                while (t.Parent != null)
                {
                    t = t.Parent;
                    path.Add(t.Index);
                }
                path = ((Therapy)listTherapies.SelectedItem).MoveDown(path);
                treeViewTasksRefresh();

                t = treeViewTasks.Nodes[path[path.Count - 1]];
                for (int iter = path.Count - 2; iter >= 0; --iter)
                {
                    t = t.Nodes[path[iter]];
                }
                treeViewTasks.SelectedNode = t;
            }
            treeViewTasks.Select();
            ds.SerializeDataModel();
        }

        private void treeViewTasks_DoubleClick(object sender, EventArgs e)
        {
            buttonEditTask_Click(new object(), new EventArgs());
        }

        private void listViewProfiles_DoubleClick(object sender, EventArgs e)
        {
            buttonEditProfile_Click(new object(), new EventArgs());
        }

        private void listViewSessions_DoubleClick(object sender, EventArgs e)
        {
            buttonViewSession_Click(new object(), new EventArgs());
        }

        private void listTherapies_DoubleClick(object sender, EventArgs e)
        {
            buttonPlay_Click(new object(), new EventArgs());
        }

		private void listTherapies_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
			{
				buttonDeleteTherapy_Click(this, new EventArgs());
			}
		}

		private void treeViewTasks_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
			{
				buttonDeleteTask_Click(this, new EventArgs());
			}
		}

		private void listViewProfiles_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
			{
				buttonDeleteProfile_Click(this, new EventArgs());
			}
		}

		private void listViewSessions_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
			{
				buttonDeleteSession_Click(this, new EventArgs());
			}
		}

		private void tabs_SelectedIndexChanged(object sender, EventArgs e)
		{
			int i = -1;
			int ii = -1;
			TreeNode t = null;
			if (tabs.SelectedIndex == 0)
			{
				if (listTherapies.SelectedIndices.Count > 0)
					i = listTherapies.SelectedIndices[0];
				if (treeViewTasks.SelectedNode != null)
					t = treeViewTasks.SelectedNode;
				listTherapiesRefresh();
				if (i != -1)
				{
					listTherapies.SelectedIndex = i;
					if (t != null)
					{
						treeViewTasks.SelectedNode = t;
						treeViewTasks.Select();
					}
				}
			}
			else if (tabs.SelectedIndex == 1)
			{
				if (listViewProfiles.SelectedIndices.Count > 0)
					i = listViewProfiles.SelectedIndices[0];
				if (listViewSessions.SelectedIndices.Count > 0)
					ii = listViewSessions.SelectedIndices[0];
				listProfilesRefresh();
				if (i != -1)
				{
					listViewProfiles.Items[i].Selected = false;
					listViewProfiles.Select();
					listViewProfiles.Items[i].Selected = true;
					listViewProfiles.Select();
					if (ii != -1)
					{
						listViewSessions.Items[ii].Selected = false;
						listViewSessions.Select();
						listViewSessions.Items[ii].Selected = true;
						listViewSessions.Select();
					}
				}

				if (lvP)
					listViewProfiles.Select();
				if (lvS)
					listViewSessions.Select();

			}
		}

		private void listViewSessions_Leave(object sender, EventArgs e)
		{
			lvS = listViewSessions.Focused;
			lvP = listViewProfiles.Focused;
		}

		private void listViewProfiles_Leave(object sender, EventArgs e)
		{
			lvS = listViewSessions.Focused;
			lvP = listViewProfiles.Focused;
		}

		private void listTherapies_Leave(object sender, EventArgs e)
		{
			lvT = listTherapies.Focused;
			tvT = treeViewTasks.Focused;
		}

		private void treeViewTasks_Leave(object sender, EventArgs e)
		{
			lvT = listTherapies.Focused;
			tvT = treeViewTasks.Focused;
		}

		private void treeViewTasks_Click(object sender, EventArgs e)
		{
			((TreeView)sender).SelectedNode = treeViewTasks.GetNodeAt(((MouseEventArgs)e).Location);
		}

        private void buttonMetrics_Click(object sender, EventArgs e)
        {
            if (listViewProfiles.SelectedItems.Count > 0)
            {
                Profile p = (Profile)listViewProfiles.SelectedItems[0].Tag;
                FormPerformance f = new FormPerformance(p);
                f.Show();
            }
        }

		private void listViewSessions_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			listViewSessions.ListViewItemSorter = new ListComparer(e.Column);
			listViewSessions.Tag = e.Column;
			if (listViewSessions.Sorting == SortOrder.Ascending)
				listViewSessions.Sorting = SortOrder.Descending;
			else
				listViewSessions.Sorting = SortOrder.Ascending;
		}

		private void listViewProfiles_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			listViewProfiles.Tag = e.Column;
			listViewProfiles.ListViewItemSorter = new ListComparer(e.Column);
			if (listViewProfiles.Sorting == SortOrder.Ascending)
				listViewProfiles.Sorting = SortOrder.Descending;
			else
				listViewProfiles.Sorting = SortOrder.Ascending;
		}

		private void copyTherapyMenuItem_Click(object sender, EventArgs e)
		{
			tempCopyTherapy = ((Therapy)listTherapies.SelectedItem);
			editAction = CopyCut.copyTherapy;
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tempCopyTask = ((Task)treeViewTasks.SelectedNode.Tag);
			editAction = CopyCut.copyTask;
		}

		private void pasteMenuItem_Click(object sender, EventArgs e)
		{
			switch (editAction)
			{
				case CopyCut.copyTherapy:
					dm.Therapies.Add(new Therapy(tempCopyTherapy));
					listTherapiesRefresh();
                    ds.SerializeDataModel();
					break;
				case CopyCut.copyTask:
					if (tempCopyTask.GetType() == typeof(DialogTask))
						((Therapy)listTherapies.SelectedItem).addTask(new DialogTask((DialogTask)tempCopyTask));
					else if (tempCopyTask.GetType() == typeof(Task2D))
						((Therapy)listTherapies.SelectedItem).addTask(new Task2D((Task2D)tempCopyTask));
					else if (tempCopyTask.GetType() == typeof(RepeatTask))
						((Therapy)listTherapies.SelectedItem).addTask(new RepeatTask((RepeatTask)tempCopyTask));
					treeViewTasksRefresh();
                    ds.SerializeDataModel();
					break;
			}
		}

		private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
		{
			if (this.tabs.SelectedIndex != 0)
			{
				copyTaskMenuItem.Enabled = false;
				copyTherapyMenuItem.Enabled = false;
				pasteMenuItem.Enabled = false;
			}
			else
			{
				//copy active
				if (listTherapies.SelectedItem == null)
				{
					copyTherapyMenuItem.Enabled = false;
				}
				else
				{
					copyTherapyMenuItem.Enabled = true;
				}
				if (treeViewTasks.SelectedNode == null)
				{
					copyTaskMenuItem.Enabled = false;
				}
				else
				{
					copyTaskMenuItem.Enabled = true;
				}
				//Paste active
				if (tempCopyTherapy != null || tempCopyTask != null)
				{
					if (editAction == CopyCut.copyTherapy)
						pasteMenuItem.Text = "Paste Therapy";
					else
						pasteMenuItem.Text = "Paste Task";

					pasteMenuItem.Enabled = true;
				}
				else
					pasteMenuItem.Enabled = false;
			}
		}

        private void playFullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dm.PlayFullscreen = playFullscreenToolStripMenuItem.Checked;
            ds.SerializeDataModel();
        }
    }
}