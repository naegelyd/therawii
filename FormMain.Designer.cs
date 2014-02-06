namespace TheraWii
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Intro (Dialog)");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Static Trace (2D)");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Dynamic (2D)");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Moving Regions (Repeat)", new System.Windows.Forms.TreeNode[] {
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("End (Dialog)");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTherapyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportTherapyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.importProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyTherapyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.copyTaskMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.pasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutTheraWiiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listViewProfiles = new System.Windows.Forms.ListView();
            this.ProfName = new System.Windows.Forms.ColumnHeader();
            this.CreateDate = new System.Windows.Forms.ColumnHeader();
            this.NumSessions = new System.Windows.Forms.ColumnHeader();
            this.buttonEditProfile = new System.Windows.Forms.Button();
            this.buttonDeleteProfile = new System.Windows.Forms.Button();
            this.buttonAddProfile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonMetrics = new System.Windows.Forms.Button();
            this.listViewSessions = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.buttonViewSession = new System.Windows.Forms.Button();
            this.buttonExportSession = new System.Windows.Forms.Button();
            this.buttonDeleteSession = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabWorkflows = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonDeleteTherapy = new System.Windows.Forms.Button();
            this.buttonAddTherapy = new System.Windows.Forms.Button();
            this.labelTherapy = new System.Windows.Forms.Label();
            this.listTherapies = new System.Windows.Forms.ListBox();
            this.treeViewTasks = new System.Windows.Forms.TreeView();
            this.labelTasks = new System.Windows.Forms.Label();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.buttonEditTask = new System.Windows.Forms.Button();
            this.buttonDeleteTask = new System.Windows.Forms.Button();
            this.buttonAddTask = new System.Windows.Forms.Button();
            this.tabs = new System.Windows.Forms.TabControl();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.labelProfiles = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Workflow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.labelSessions = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playFullscreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabProfile.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabWorkflows.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(753, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importTherapyToolStripMenuItem,
            this.exportTherapyToolStripMenuItem,
            this.toolStripSeparator2,
            this.importProfileToolStripMenuItem,
            this.exportProfileToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importTherapyToolStripMenuItem
            // 
            this.importTherapyToolStripMenuItem.Name = "importTherapyToolStripMenuItem";
            this.importTherapyToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.importTherapyToolStripMenuItem.Text = "Import Therapy...";
            this.importTherapyToolStripMenuItem.Click += new System.EventHandler(this.importTherapyToolStripMenuItem_Click);
            // 
            // exportTherapyToolStripMenuItem
            // 
            this.exportTherapyToolStripMenuItem.Name = "exportTherapyToolStripMenuItem";
            this.exportTherapyToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.exportTherapyToolStripMenuItem.Text = "Export Therapy...";
            this.exportTherapyToolStripMenuItem.Click += new System.EventHandler(this.exportTherapyToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // importProfileToolStripMenuItem
            // 
            this.importProfileToolStripMenuItem.Name = "importProfileToolStripMenuItem";
            this.importProfileToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.importProfileToolStripMenuItem.Text = "Import Profile...";
            this.importProfileToolStripMenuItem.Click += new System.EventHandler(this.importProfileToolStripMenuItem_Click);
            // 
            // exportProfileToolStripMenuItem
            // 
            this.exportProfileToolStripMenuItem.Name = "exportProfileToolStripMenuItem";
            this.exportProfileToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.exportProfileToolStripMenuItem.Text = "Export Profile...";
            this.exportProfileToolStripMenuItem.Click += new System.EventHandler(this.exportProfileToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyTherapyMenuItem,
            this.toolStripSeparator3,
            this.copyTaskMenuItem,
            this.toolStripSeparator4,
            this.pasteMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(this.editToolStripMenuItem_DropDownOpening);
            // 
            // copyTherapyMenuItem
            // 
            this.copyTherapyMenuItem.Name = "copyTherapyMenuItem";
            this.copyTherapyMenuItem.Size = new System.Drawing.Size(148, 22);
            this.copyTherapyMenuItem.Text = "Copy Therapy";
            this.copyTherapyMenuItem.Click += new System.EventHandler(this.copyTherapyMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(145, 6);
            // 
            // copyTaskMenuItem
            // 
            this.copyTaskMenuItem.Name = "copyTaskMenuItem";
            this.copyTaskMenuItem.Size = new System.Drawing.Size(148, 22);
            this.copyTaskMenuItem.Text = "Copy Task";
            this.copyTaskMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // pasteMenuItem
            // 
            this.pasteMenuItem.Name = "pasteMenuItem";
            this.pasteMenuItem.Size = new System.Drawing.Size(148, 22);
            this.pasteMenuItem.Text = "Paste";
            this.pasteMenuItem.Click += new System.EventHandler(this.pasteMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutTheraWiiToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutTheraWiiToolStripMenuItem
            // 
            this.aboutTheraWiiToolStripMenuItem.Name = "aboutTheraWiiToolStripMenuItem";
            this.aboutTheraWiiToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.aboutTheraWiiToolStripMenuItem.Text = "About TheraWii";
            this.aboutTheraWiiToolStripMenuItem.Click += new System.EventHandler(this.aboutTheraWiiToolStripMenuItem_Click);
            // 
            // tabProfile
            // 
            this.tabProfile.Controls.Add(this.splitContainer2);
            this.tabProfile.Location = new System.Drawing.Point(4, 22);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tabProfile.Size = new System.Drawing.Size(744, 412);
            this.tabProfile.TabIndex = 1;
            this.tabProfile.Text = "Profile Management";
            this.tabProfile.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listViewProfiles);
            this.splitContainer2.Panel1.Controls.Add(this.buttonEditProfile);
            this.splitContainer2.Panel1.Controls.Add(this.buttonDeleteProfile);
            this.splitContainer2.Panel1.Controls.Add(this.buttonAddProfile);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.buttonMetrics);
            this.splitContainer2.Panel2.Controls.Add(this.listViewSessions);
            this.splitContainer2.Panel2.Controls.Add(this.buttonViewSession);
            this.splitContainer2.Panel2.Controls.Add(this.buttonExportSession);
            this.splitContainer2.Panel2.Controls.Add(this.buttonDeleteSession);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Size = new System.Drawing.Size(746, 412);
            this.splitContainer2.SplitterDistance = 313;
            this.splitContainer2.TabIndex = 1;
            // 
            // listViewProfiles
            // 
            this.listViewProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewProfiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProfName,
            this.CreateDate,
            this.NumSessions});
            this.listViewProfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewProfiles.FullRowSelect = true;
            this.listViewProfiles.Location = new System.Drawing.Point(9, 37);
            this.listViewProfiles.MultiSelect = false;
            this.listViewProfiles.Name = "listViewProfiles";
            this.listViewProfiles.Size = new System.Drawing.Size(289, 340);
            this.listViewProfiles.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewProfiles.TabIndex = 14;
            this.listViewProfiles.UseCompatibleStateImageBehavior = false;
            this.listViewProfiles.View = System.Windows.Forms.View.Details;
            this.listViewProfiles.SelectedIndexChanged += new System.EventHandler(this.listViewProfiles_SelectedIndexChanged);
            this.listViewProfiles.DoubleClick += new System.EventHandler(this.listViewProfiles_DoubleClick);
            this.listViewProfiles.Leave += new System.EventHandler(this.listViewProfiles_Leave);
            this.listViewProfiles.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewProfiles_ColumnClick);
            this.listViewProfiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewProfiles_KeyDown);
            // 
            // ProfName
            // 
            this.ProfName.Text = "Name";
            this.ProfName.Width = 110;
            // 
            // CreateDate
            // 
            this.CreateDate.Text = "Created";
            this.CreateDate.Width = 80;
            // 
            // NumSessions
            // 
            this.NumSessions.Text = "Sessions";
            this.NumSessions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumSessions.Width = 74;
            // 
            // buttonEditProfile
            // 
            this.buttonEditProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEditProfile.Location = new System.Drawing.Point(137, 381);
            this.buttonEditProfile.Name = "buttonEditProfile";
            this.buttonEditProfile.Size = new System.Drawing.Size(50, 26);
            this.buttonEditProfile.TabIndex = 13;
            this.buttonEditProfile.Text = "Edit";
            this.buttonEditProfile.UseVisualStyleBackColor = true;
            this.buttonEditProfile.Click += new System.EventHandler(this.buttonEditProfile_Click);
            // 
            // buttonDeleteProfile
            // 
            this.buttonDeleteProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDeleteProfile.Location = new System.Drawing.Point(73, 381);
            this.buttonDeleteProfile.Name = "buttonDeleteProfile";
            this.buttonDeleteProfile.Size = new System.Drawing.Size(50, 26);
            this.buttonDeleteProfile.TabIndex = 12;
            this.buttonDeleteProfile.Text = "Delete";
            this.buttonDeleteProfile.UseVisualStyleBackColor = true;
            this.buttonDeleteProfile.Click += new System.EventHandler(this.buttonDeleteProfile_Click);
            // 
            // buttonAddProfile
            // 
            this.buttonAddProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddProfile.Location = new System.Drawing.Point(9, 381);
            this.buttonAddProfile.Name = "buttonAddProfile";
            this.buttonAddProfile.Size = new System.Drawing.Size(50, 26);
            this.buttonAddProfile.TabIndex = 11;
            this.buttonAddProfile.Text = "Add";
            this.buttonAddProfile.UseVisualStyleBackColor = true;
            this.buttonAddProfile.Click += new System.EventHandler(this.buttonAddProfile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Profiles";
            // 
            // buttonMetrics
            // 
            this.buttonMetrics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMetrics.Location = new System.Drawing.Point(317, 156);
            this.buttonMetrics.Name = "buttonMetrics";
            this.buttonMetrics.Size = new System.Drawing.Size(95, 26);
            this.buttonMetrics.TabIndex = 18;
            this.buttonMetrics.Text = "View Metrics";
            this.buttonMetrics.UseVisualStyleBackColor = true;
            this.buttonMetrics.Click += new System.EventHandler(this.buttonMetrics_Click);
            // 
            // listViewSessions
            // 
            this.listViewSessions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSessions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewSessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewSessions.FullRowSelect = true;
            this.listViewSessions.Location = new System.Drawing.Point(9, 37);
            this.listViewSessions.Name = "listViewSessions";
            this.listViewSessions.Size = new System.Drawing.Size(302, 340);
            this.listViewSessions.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewSessions.TabIndex = 17;
            this.listViewSessions.UseCompatibleStateImageBehavior = false;
            this.listViewSessions.View = System.Windows.Forms.View.Details;
            this.listViewSessions.DoubleClick += new System.EventHandler(this.listViewSessions_DoubleClick);
            this.listViewSessions.Leave += new System.EventHandler(this.listViewSessions_Leave);
            this.listViewSessions.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewSessions_ColumnClick);
            this.listViewSessions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewSessions_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Session Date";
            this.columnHeader2.Width = 133;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Therapy";
            this.columnHeader3.Width = 115;
            // 
            // buttonViewSession
            // 
            this.buttonViewSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonViewSession.Location = new System.Drawing.Point(317, 37);
            this.buttonViewSession.Name = "buttonViewSession";
            this.buttonViewSession.Size = new System.Drawing.Size(95, 26);
            this.buttonViewSession.TabIndex = 16;
            this.buttonViewSession.Text = "View Session";
            this.buttonViewSession.UseVisualStyleBackColor = true;
            this.buttonViewSession.Click += new System.EventHandler(this.buttonViewSession_Click);
            // 
            // buttonExportSession
            // 
            this.buttonExportSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExportSession.Location = new System.Drawing.Point(317, 69);
            this.buttonExportSession.Name = "buttonExportSession";
            this.buttonExportSession.Size = new System.Drawing.Size(95, 26);
            this.buttonExportSession.TabIndex = 5;
            this.buttonExportSession.Text = "Export Session";
            this.buttonExportSession.UseVisualStyleBackColor = true;
            this.buttonExportSession.Click += new System.EventHandler(this.buttonExportSession_Click);
            // 
            // buttonDeleteSession
            // 
            this.buttonDeleteSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteSession.Location = new System.Drawing.Point(317, 101);
            this.buttonDeleteSession.Name = "buttonDeleteSession";
            this.buttonDeleteSession.Size = new System.Drawing.Size(95, 26);
            this.buttonDeleteSession.TabIndex = 15;
            this.buttonDeleteSession.Text = "Delete Session";
            this.buttonDeleteSession.UseVisualStyleBackColor = true;
            this.buttonDeleteSession.Click += new System.EventHandler(this.buttonDeleteSession_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sessions in Profile";
            // 
            // tabWorkflows
            // 
            this.tabWorkflows.Controls.Add(this.splitContainer1);
            this.tabWorkflows.Location = new System.Drawing.Point(4, 22);
            this.tabWorkflows.Name = "tabWorkflows";
            this.tabWorkflows.Padding = new System.Windows.Forms.Padding(3);
            this.tabWorkflows.Size = new System.Drawing.Size(744, 412);
            this.tabWorkflows.TabIndex = 0;
            this.tabWorkflows.Text = "Therapy Editor";
            this.tabWorkflows.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonPlay);
            this.splitContainer1.Panel1.Controls.Add(this.buttonDeleteTherapy);
            this.splitContainer1.Panel1.Controls.Add(this.buttonAddTherapy);
            this.splitContainer1.Panel1.Controls.Add(this.labelTherapy);
            this.splitContainer1.Panel1.Controls.Add(this.listTherapies);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeViewTasks);
            this.splitContainer1.Panel2.Controls.Add(this.labelTasks);
            this.splitContainer1.Panel2.Controls.Add(this.buttonMoveDown);
            this.splitContainer1.Panel2.Controls.Add(this.buttonMoveUp);
            this.splitContainer1.Panel2.Controls.Add(this.buttonEditTask);
            this.splitContainer1.Panel2.Controls.Add(this.buttonDeleteTask);
            this.splitContainer1.Panel2.Controls.Add(this.buttonAddTask);
            this.splitContainer1.Size = new System.Drawing.Size(746, 412);
            this.splitContainer1.SplitterDistance = 313;
            this.splitContainer1.TabIndex = 2;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlay.ForeColor = System.Drawing.Color.ForestGreen;
            this.buttonPlay.Location = new System.Drawing.Point(137, 381);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(50, 26);
            this.buttonPlay.TabIndex = 17;
            this.buttonPlay.Text = "Play!";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonDeleteTherapy
            // 
            this.buttonDeleteTherapy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDeleteTherapy.Location = new System.Drawing.Point(73, 381);
            this.buttonDeleteTherapy.Name = "buttonDeleteTherapy";
            this.buttonDeleteTherapy.Size = new System.Drawing.Size(50, 26);
            this.buttonDeleteTherapy.TabIndex = 16;
            this.buttonDeleteTherapy.Text = "Delete";
            this.buttonDeleteTherapy.UseVisualStyleBackColor = true;
            this.buttonDeleteTherapy.Click += new System.EventHandler(this.buttonDeleteTherapy_Click);
            // 
            // buttonAddTherapy
            // 
            this.buttonAddTherapy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddTherapy.Location = new System.Drawing.Point(9, 381);
            this.buttonAddTherapy.Name = "buttonAddTherapy";
            this.buttonAddTherapy.Size = new System.Drawing.Size(50, 26);
            this.buttonAddTherapy.TabIndex = 15;
            this.buttonAddTherapy.Text = "Add";
            this.buttonAddTherapy.UseVisualStyleBackColor = true;
            this.buttonAddTherapy.Click += new System.EventHandler(this.buttonAddTherapy_Click);
            // 
            // labelTherapy
            // 
            this.labelTherapy.AutoSize = true;
            this.labelTherapy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTherapy.Location = new System.Drawing.Point(7, 8);
            this.labelTherapy.Name = "labelTherapy";
            this.labelTherapy.Size = new System.Drawing.Size(80, 24);
            this.labelTherapy.TabIndex = 14;
            this.labelTherapy.Text = "Therapy";
            // 
            // listTherapies
            // 
            this.listTherapies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listTherapies.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listTherapies.FormattingEnabled = true;
            this.listTherapies.IntegralHeight = false;
            this.listTherapies.ItemHeight = 16;
            this.listTherapies.Items.AddRange(new object[] {
            "Default"});
            this.listTherapies.Location = new System.Drawing.Point(9, 37);
            this.listTherapies.Name = "listTherapies";
            this.listTherapies.Size = new System.Drawing.Size(289, 340);
            this.listTherapies.TabIndex = 0;
            this.listTherapies.SelectedIndexChanged += new System.EventHandler(this.listTherapies_SelectedIndexChanged);
            this.listTherapies.Leave += new System.EventHandler(this.listTherapies_Leave);
            this.listTherapies.DoubleClick += new System.EventHandler(this.listTherapies_DoubleClick);
            this.listTherapies.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listTherapies_KeyDown);
            // 
            // treeViewTasks
            // 
            this.treeViewTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewTasks.Location = new System.Drawing.Point(9, 37);
            this.treeViewTasks.Name = "treeViewTasks";
            treeNode6.Name = "Node0";
            treeNode6.Text = "Intro (Dialog)";
            treeNode7.Name = "Node1";
            treeNode7.Text = "Static Trace (2D)";
            treeNode8.Name = "Node3";
            treeNode8.Text = "Dynamic (2D)";
            treeNode9.Name = "Node2";
            treeNode9.Text = "Moving Regions (Repeat)";
            treeNode10.Name = "Node4";
            treeNode10.Text = "End (Dialog)";
            this.treeViewTasks.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode9,
            treeNode10});
            this.treeViewTasks.Size = new System.Drawing.Size(302, 340);
            this.treeViewTasks.TabIndex = 12;
            this.treeViewTasks.DoubleClick += new System.EventHandler(this.treeViewTasks_DoubleClick);
            this.treeViewTasks.Leave += new System.EventHandler(this.treeViewTasks_Leave);
            this.treeViewTasks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewTasks_KeyDown);
            this.treeViewTasks.Click += new System.EventHandler(this.treeViewTasks_Click);
            // 
            // labelTasks
            // 
            this.labelTasks.AutoSize = true;
            this.labelTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTasks.Location = new System.Drawing.Point(7, 8);
            this.labelTasks.Name = "labelTasks";
            this.labelTasks.Size = new System.Drawing.Size(154, 24);
            this.labelTasks.TabIndex = 11;
            this.labelTasks.Text = "Tasks in Therapy";
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMoveDown.Location = new System.Drawing.Point(317, 231);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(74, 26);
            this.buttonMoveDown.TabIndex = 7;
            this.buttonMoveDown.Text = "Move Down";
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonTaskMoveDown_Click);
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMoveUp.Location = new System.Drawing.Point(317, 199);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(74, 26);
            this.buttonMoveUp.TabIndex = 6;
            this.buttonMoveUp.Text = "Move Up";
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonTaskMoveUp_Click);
            // 
            // buttonEditTask
            // 
            this.buttonEditTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditTask.Location = new System.Drawing.Point(317, 69);
            this.buttonEditTask.Name = "buttonEditTask";
            this.buttonEditTask.Size = new System.Drawing.Size(95, 26);
            this.buttonEditTask.TabIndex = 5;
            this.buttonEditTask.Text = "Edit Task";
            this.buttonEditTask.UseVisualStyleBackColor = true;
            this.buttonEditTask.Click += new System.EventHandler(this.buttonEditTask_Click);
            // 
            // buttonDeleteTask
            // 
            this.buttonDeleteTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteTask.Location = new System.Drawing.Point(317, 101);
            this.buttonDeleteTask.Name = "buttonDeleteTask";
            this.buttonDeleteTask.Size = new System.Drawing.Size(95, 26);
            this.buttonDeleteTask.TabIndex = 4;
            this.buttonDeleteTask.Text = "Delete Task";
            this.buttonDeleteTask.UseVisualStyleBackColor = true;
            this.buttonDeleteTask.Click += new System.EventHandler(this.buttonDeleteTask_Click);
            // 
            // buttonAddTask
            // 
            this.buttonAddTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddTask.Location = new System.Drawing.Point(317, 37);
            this.buttonAddTask.Name = "buttonAddTask";
            this.buttonAddTask.Size = new System.Drawing.Size(95, 26);
            this.buttonAddTask.TabIndex = 3;
            this.buttonAddTask.Text = "Add Task";
            this.buttonAddTask.UseVisualStyleBackColor = true;
            this.buttonAddTask.Click += new System.EventHandler(this.buttonAddTask_Click);
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabWorkflows);
            this.tabs.Controls.Add(this.tabProfile);
            this.tabs.Location = new System.Drawing.Point(0, 27);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(752, 438);
            this.tabs.TabIndex = 3;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(80, 385);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 26);
            this.button2.TabIndex = 13;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(48, 385);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 26);
            this.button3.TabIndex = 12;
            this.button3.Text = "-";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(16, 385);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(26, 26);
            this.button4.TabIndex = 11;
            this.button4.Text = "+";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Joe",
            "Tim",
            "Tom",
            "Bob",
            "Mary",
            "Jane"});
            this.listBox1.Location = new System.Drawing.Point(9, 37);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(178, 342);
            this.listBox1.TabIndex = 3;
            // 
            // labelProfiles
            // 
            this.labelProfiles.AutoSize = true;
            this.labelProfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProfiles.Location = new System.Drawing.Point(3, 9);
            this.labelProfiles.Name = "labelProfiles";
            this.labelProfiles.Size = new System.Drawing.Size(71, 24);
            this.labelProfiles.TabIndex = 2;
            this.labelProfiles.Text = "Profiles";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Workflow,
            this.DateTime});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Location = new System.Drawing.Point(22, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Size = new System.Drawing.Size(249, 339);
            this.dataGridView1.TabIndex = 17;
            // 
            // Workflow
            // 
            this.Workflow.HeaderText = "Workflow";
            this.Workflow.Name = "Workflow";
            this.Workflow.ReadOnly = true;
            // 
            // DateTime
            // 
            this.DateTime.HeaderText = "DateTime";
            this.DateTime.Name = "DateTime";
            this.DateTime.ReadOnly = true;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(54, 383);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(44, 26);
            this.buttonOpen.TabIndex = 16;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(277, 38);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(95, 26);
            this.buttonExport.TabIndex = 5;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(22, 383);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(26, 26);
            this.button5.TabIndex = 15;
            this.button5.Text = "-";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // labelSessions
            // 
            this.labelSessions.AutoSize = true;
            this.labelSessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSessions.Location = new System.Drawing.Point(3, 9);
            this.labelSessions.Name = "labelSessions";
            this.labelSessions.Size = new System.Drawing.Size(86, 24);
            this.labelSessions.TabIndex = 3;
            this.labelSessions.Text = "Sessions";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playFullscreenToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // playFullscreenToolStripMenuItem
            // 
            this.playFullscreenToolStripMenuItem.CheckOnClick = true;
            this.playFullscreenToolStripMenuItem.Name = "playFullscreenToolStripMenuItem";
            this.playFullscreenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.playFullscreenToolStripMenuItem.Text = "Play Fullscreen";
            this.playFullscreenToolStripMenuItem.Click += new System.EventHandler(this.playFullscreenToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 464);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "TheraWii";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabProfile.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.tabWorkflows.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.TabPage tabWorkflows;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listTherapies;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.Button buttonEditTask;
        private System.Windows.Forms.Button buttonDeleteTask;
        private System.Windows.Forms.Button buttonAddTask;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button buttonEditProfile;
        private System.Windows.Forms.Button buttonDeleteProfile;
        private System.Windows.Forms.Button buttonAddProfile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonViewSession;
        private System.Windows.Forms.Button buttonExportSession;
        private System.Windows.Forms.Button buttonDeleteSession;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label labelProfiles;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Workflow;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTime;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label labelSessions;
        private System.Windows.Forms.Label labelTherapy;
        private System.Windows.Forms.Label labelTasks;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonDeleteTherapy;
        private System.Windows.Forms.Button buttonAddTherapy;
        private System.Windows.Forms.ToolStripMenuItem importTherapyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportTherapyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem importProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutTheraWiiToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyTaskMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteMenuItem;
        private System.Windows.Forms.TreeView treeViewTasks;
        private System.Windows.Forms.ListView listViewProfiles;
        private System.Windows.Forms.ColumnHeader ProfName;
        private System.Windows.Forms.ColumnHeader CreateDate;
        private System.Windows.Forms.ColumnHeader NumSessions;
        private System.Windows.Forms.ListView listViewSessions;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button buttonMetrics;
		private System.Windows.Forms.ToolStripMenuItem copyTherapyMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playFullscreenToolStripMenuItem;

    }
}

