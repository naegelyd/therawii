namespace TheraWii
{
    partial class Form2DTask
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
			this.label5 = new System.Windows.Forms.Label();
			this.TaskTitle = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBoxEndCondition = new System.Windows.Forms.ComboBox();
			this.comboBoxEndButton = new System.Windows.Forms.ComboBox();
			this.comboBoxInputDevice = new System.Windows.Forms.ComboBox();
			this.comboBoxInputHandling = new System.Windows.Forms.ComboBox();
			this.comboBoxPerformanceMetric = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.listBoxAdditionalInputs = new System.Windows.Forms.ListBox();
			this.buttonAddInput = new System.Windows.Forms.Button();
			this.buttonRemoveInput = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.numericUpDownSizeY1 = new System.Windows.Forms.NumericUpDown();
			this.labelSizeY2 = new System.Windows.Forms.Label();
			this.numericUpDownSizeY2 = new System.Windows.Forms.NumericUpDown();
			this.labelSizeY1 = new System.Windows.Forms.Label();
			this.numericUpDownSizeX1 = new System.Windows.Forms.NumericUpDown();
			this.labelSizeX2 = new System.Windows.Forms.Label();
			this.numericUpDownSizeX2 = new System.Windows.Forms.NumericUpDown();
			this.labelSizeX1 = new System.Windows.Forms.Label();
			this.comboBoxSizeY = new System.Windows.Forms.ComboBox();
			this.comboBoxSizeX = new System.Windows.Forms.ComboBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.numericUpDownPosY1 = new System.Windows.Forms.NumericUpDown();
			this.labelPosY2 = new System.Windows.Forms.Label();
			this.numericUpDownPosY2 = new System.Windows.Forms.NumericUpDown();
			this.labelPosY1 = new System.Windows.Forms.Label();
			this.numericUpDownPosX1 = new System.Windows.Forms.NumericUpDown();
			this.labelPosX2 = new System.Windows.Forms.Label();
			this.numericUpDownPosX2 = new System.Windows.Forms.NumericUpDown();
			this.label20 = new System.Windows.Forms.Label();
			this.labelPosX1 = new System.Windows.Forms.Label();
			this.comboBoxPosY = new System.Windows.Forms.ComboBox();
			this.comboBoxPosX = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.comboBoxShape = new System.Windows.Forms.ComboBox();
			this.checkBoxEnableRegion = new System.Windows.Forms.CheckBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.numericUpDownEndSeconds = new System.Windows.Forms.NumericUpDown();
			this.labelEndSeconds = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeY1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeY2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeX1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeX2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosY1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosY2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosX1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosX2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndSeconds)).BeginInit();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 157);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(0, 13);
			this.label5.TabIndex = 12;
			// 
			// TaskTitle
			// 
			this.TaskTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TaskTitle.AutoSize = true;
			this.TaskTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TaskTitle.Location = new System.Drawing.Point(187, 9);
			this.TaskTitle.Name = "TaskTitle";
			this.TaskTitle.Size = new System.Drawing.Size(148, 24);
			this.TaskTitle.TabIndex = 0;
			this.TaskTitle.Text = "2D Task Options";
			this.TaskTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(174, 47);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(173, 20);
			this.textBoxName.TabIndex = 1;
			this.textBoxName.Text = "Dynamic";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(130, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Name:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(97, 94);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Input Device:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(89, 119);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Input Handling:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(92, 528);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(76, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "End Condition:";
			// 
			// comboBoxEndCondition
			// 
			this.comboBoxEndCondition.FormattingEnabled = true;
			this.comboBoxEndCondition.Items.AddRange(new object[] {
            "Button Press",
            "Time Limit",
            "Time In Region",
            "Time Out of Region"});
			this.comboBoxEndCondition.Location = new System.Drawing.Point(174, 525);
			this.comboBoxEndCondition.Name = "comboBoxEndCondition";
			this.comboBoxEndCondition.Size = new System.Drawing.Size(173, 21);
			this.comboBoxEndCondition.TabIndex = 8;
			this.comboBoxEndCondition.Text = "Button Press";
			this.comboBoxEndCondition.SelectedIndexChanged += new System.EventHandler(this.comboBoxEndCondition_SelectedIndexChanged);
			// 
			// comboBoxEndButton
			// 
			this.comboBoxEndButton.FormattingEnabled = true;
			this.comboBoxEndButton.Items.AddRange(new object[] {
            "A",
            "B",
            "Home",
            "+",
            "-",
            "1",
            "2",
            "Up",
            "Down",
            "Left",
            "Right"});
			this.comboBoxEndButton.Location = new System.Drawing.Point(174, 552);
			this.comboBoxEndButton.Name = "comboBoxEndButton";
			this.comboBoxEndButton.Size = new System.Drawing.Size(173, 21);
			this.comboBoxEndButton.TabIndex = 9;
			this.comboBoxEndButton.Text = "A";
			// 
			// comboBoxInputDevice
			// 
			this.comboBoxInputDevice.FormattingEnabled = true;
			this.comboBoxInputDevice.Items.AddRange(new object[] {
            "Balance Board",
            "IR Pointer",
            "Remote Roll/Pitch",
            "Remote + Nunchuck Joystick",
            "Remote + Nunchuck Roll/Pitch"});
			this.comboBoxInputDevice.Location = new System.Drawing.Point(174, 91);
			this.comboBoxInputDevice.Name = "comboBoxInputDevice";
			this.comboBoxInputDevice.Size = new System.Drawing.Size(173, 21);
			this.comboBoxInputDevice.TabIndex = 10;
			this.comboBoxInputDevice.Text = "Balance Board";
			// 
			// comboBoxInputHandling
			// 
			this.comboBoxInputHandling.FormattingEnabled = true;
			this.comboBoxInputHandling.Location = new System.Drawing.Point(174, 116);
			this.comboBoxInputHandling.Name = "comboBoxInputHandling";
			this.comboBoxInputHandling.Size = new System.Drawing.Size(173, 21);
			this.comboBoxInputHandling.TabIndex = 11;
			this.comboBoxInputHandling.Text = "Absolute";
			// 
			// comboBoxPerformanceMetric
			// 
			this.comboBoxPerformanceMetric.FormattingEnabled = true;
			this.comboBoxPerformanceMetric.Items.AddRange(new object[] {
            "Time in region",
            "Time out of region",
            "Total Time",
            "Center of Balance Position",
            "Center of Balance Average",
            "Smoothness"});
			this.comboBoxPerformanceMetric.Location = new System.Drawing.Point(174, 276);
			this.comboBoxPerformanceMetric.Name = "comboBoxPerformanceMetric";
			this.comboBoxPerformanceMetric.Size = new System.Drawing.Size(173, 21);
			this.comboBoxPerformanceMetric.TabIndex = 21;
			this.comboBoxPerformanceMetric.Text = "Smoothness";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(29, 279);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(139, 13);
			this.label10.TabIndex = 22;
			this.label10.Text = "Primary Performance Metric:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(30, 143);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(138, 13);
			this.label11.TabIndex = 24;
			this.label11.Text = "Additional Inputs to Record:";
			// 
			// listBoxAdditionalInputs
			// 
			this.listBoxAdditionalInputs.FormattingEnabled = true;
			this.listBoxAdditionalInputs.Items.AddRange(new object[] {
            "Wii Remote Acceleration",
            "Nunchuck Joystick"});
			this.listBoxAdditionalInputs.Location = new System.Drawing.Point(174, 143);
			this.listBoxAdditionalInputs.Name = "listBoxAdditionalInputs";
			this.listBoxAdditionalInputs.Size = new System.Drawing.Size(173, 121);
			this.listBoxAdditionalInputs.TabIndex = 25;
			// 
			// buttonAddInput
			// 
			this.buttonAddInput.Location = new System.Drawing.Point(353, 143);
			this.buttonAddInput.Name = "buttonAddInput";
			this.buttonAddInput.Size = new System.Drawing.Size(95, 26);
			this.buttonAddInput.TabIndex = 26;
			this.buttonAddInput.Text = "Add Input";
			this.buttonAddInput.UseVisualStyleBackColor = true;
			this.buttonAddInput.Click += new System.EventHandler(this.buttonAddInput_Click);
			// 
			// buttonRemoveInput
			// 
			this.buttonRemoveInput.Location = new System.Drawing.Point(353, 175);
			this.buttonRemoveInput.Name = "buttonRemoveInput";
			this.buttonRemoveInput.Size = new System.Drawing.Size(95, 26);
			this.buttonRemoveInput.TabIndex = 27;
			this.buttonRemoveInput.Text = "RemoveInput";
			this.buttonRemoveInput.UseVisualStyleBackColor = true;
			this.buttonRemoveInput.Click += new System.EventHandler(this.buttonRemoveInput_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.numericUpDownSizeY1);
			this.groupBox1.Controls.Add(this.labelSizeY2);
			this.groupBox1.Controls.Add(this.numericUpDownSizeY2);
			this.groupBox1.Controls.Add(this.labelSizeY1);
			this.groupBox1.Controls.Add(this.numericUpDownSizeX1);
			this.groupBox1.Controls.Add(this.labelSizeX2);
			this.groupBox1.Controls.Add(this.numericUpDownSizeX2);
			this.groupBox1.Controls.Add(this.labelSizeX1);
			this.groupBox1.Controls.Add(this.comboBoxSizeY);
			this.groupBox1.Controls.Add(this.comboBoxSizeX);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.numericUpDownPosY1);
			this.groupBox1.Controls.Add(this.labelPosY2);
			this.groupBox1.Controls.Add(this.numericUpDownPosY2);
			this.groupBox1.Controls.Add(this.labelPosY1);
			this.groupBox1.Controls.Add(this.numericUpDownPosX1);
			this.groupBox1.Controls.Add(this.labelPosX2);
			this.groupBox1.Controls.Add(this.numericUpDownPosX2);
			this.groupBox1.Controls.Add(this.label20);
			this.groupBox1.Controls.Add(this.labelPosX1);
			this.groupBox1.Controls.Add(this.comboBoxPosY);
			this.groupBox1.Controls.Add(this.comboBoxPosX);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.comboBoxShape);
			this.groupBox1.Location = new System.Drawing.Point(12, 336);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(468, 173);
			this.groupBox1.TabIndex = 29;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Region Settings";
			// 
			// numericUpDownSizeY1
			// 
			this.numericUpDownSizeY1.DecimalPlaces = 2;
			this.numericUpDownSizeY1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownSizeY1.Location = new System.Drawing.Point(311, 143);
			this.numericUpDownSizeY1.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.numericUpDownSizeY1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownSizeY1.Name = "numericUpDownSizeY1";
			this.numericUpDownSizeY1.Size = new System.Drawing.Size(53, 20);
			this.numericUpDownSizeY1.TabIndex = 69;
			this.numericUpDownSizeY1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownSizeY1.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownSizeY1.Visible = false;
			// 
			// labelSizeY2
			// 
			this.labelSizeY2.AutoSize = true;
			this.labelSizeY2.Location = new System.Drawing.Point(377, 145);
			this.labelSizeY2.Name = "labelSizeY2";
			this.labelSizeY2.Size = new System.Drawing.Size(26, 13);
			this.labelSizeY2.TabIndex = 67;
			this.labelSizeY2.Text = "End";
			this.labelSizeY2.Visible = false;
			// 
			// numericUpDownSizeY2
			// 
			this.numericUpDownSizeY2.DecimalPlaces = 2;
			this.numericUpDownSizeY2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownSizeY2.Location = new System.Drawing.Point(409, 143);
			this.numericUpDownSizeY2.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.numericUpDownSizeY2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownSizeY2.Name = "numericUpDownSizeY2";
			this.numericUpDownSizeY2.Size = new System.Drawing.Size(53, 20);
			this.numericUpDownSizeY2.TabIndex = 68;
			this.numericUpDownSizeY2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownSizeY2.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			// 
			// labelSizeY1
			// 
			this.labelSizeY1.AutoSize = true;
			this.labelSizeY1.Location = new System.Drawing.Point(271, 145);
			this.labelSizeY1.Name = "labelSizeY1";
			this.labelSizeY1.Size = new System.Drawing.Size(34, 13);
			this.labelSizeY1.TabIndex = 66;
			this.labelSizeY1.Text = "Value";
			// 
			// numericUpDownSizeX1
			// 
			this.numericUpDownSizeX1.DecimalPlaces = 2;
			this.numericUpDownSizeX1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownSizeX1.Location = new System.Drawing.Point(311, 90);
			this.numericUpDownSizeX1.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.numericUpDownSizeX1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownSizeX1.Name = "numericUpDownSizeX1";
			this.numericUpDownSizeX1.Size = new System.Drawing.Size(53, 20);
			this.numericUpDownSizeX1.TabIndex = 65;
			this.numericUpDownSizeX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownSizeX1.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownSizeX1.Visible = false;
			// 
			// labelSizeX2
			// 
			this.labelSizeX2.AutoSize = true;
			this.labelSizeX2.Location = new System.Drawing.Point(377, 92);
			this.labelSizeX2.Name = "labelSizeX2";
			this.labelSizeX2.Size = new System.Drawing.Size(26, 13);
			this.labelSizeX2.TabIndex = 63;
			this.labelSizeX2.Text = "End";
			this.labelSizeX2.Visible = false;
			// 
			// numericUpDownSizeX2
			// 
			this.numericUpDownSizeX2.DecimalPlaces = 2;
			this.numericUpDownSizeX2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownSizeX2.Location = new System.Drawing.Point(409, 90);
			this.numericUpDownSizeX2.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.numericUpDownSizeX2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownSizeX2.Name = "numericUpDownSizeX2";
			this.numericUpDownSizeX2.Size = new System.Drawing.Size(53, 20);
			this.numericUpDownSizeX2.TabIndex = 64;
			this.numericUpDownSizeX2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownSizeX2.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			// 
			// labelSizeX1
			// 
			this.labelSizeX1.AutoSize = true;
			this.labelSizeX1.Location = new System.Drawing.Point(271, 92);
			this.labelSizeX1.Name = "labelSizeX1";
			this.labelSizeX1.Size = new System.Drawing.Size(34, 13);
			this.labelSizeX1.TabIndex = 61;
			this.labelSizeX1.Text = "Value";
			// 
			// comboBoxSizeY
			// 
			this.comboBoxSizeY.FormattingEnabled = true;
			this.comboBoxSizeY.Items.AddRange(new object[] {
            "Static",
            "Dynamic",
            "Random"});
			this.comboBoxSizeY.Location = new System.Drawing.Point(274, 116);
			this.comboBoxSizeY.Name = "comboBoxSizeY";
			this.comboBoxSizeY.Size = new System.Drawing.Size(188, 21);
			this.comboBoxSizeY.TabIndex = 62;
			this.comboBoxSizeY.Text = "Static";
			this.comboBoxSizeY.SelectedIndexChanged += new System.EventHandler(this.comboBoxSizeY_SelectedIndexChanged);
			// 
			// comboBoxSizeX
			// 
			this.comboBoxSizeX.FormattingEnabled = true;
			this.comboBoxSizeX.Items.AddRange(new object[] {
            "Static",
            "Dynamic",
            "Random"});
			this.comboBoxSizeX.Location = new System.Drawing.Point(274, 62);
			this.comboBoxSizeX.Name = "comboBoxSizeX";
			this.comboBoxSizeX.Size = new System.Drawing.Size(188, 21);
			this.comboBoxSizeX.TabIndex = 60;
			this.comboBoxSizeX.Text = "Static";
			this.comboBoxSizeX.SelectedIndexChanged += new System.EventHandler(this.comboBoxSizeX_SelectedIndexChanged);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(254, 119);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(14, 13);
			this.label16.TabIndex = 59;
			this.label16.Text = "Y";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(254, 65);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(14, 13);
			this.label17.TabIndex = 58;
			this.label17.Text = "X";
			// 
			// numericUpDownPosY1
			// 
			this.numericUpDownPosY1.DecimalPlaces = 2;
			this.numericUpDownPosY1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownPosY1.Location = new System.Drawing.Point(84, 143);
			this.numericUpDownPosY1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownPosY1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.numericUpDownPosY1.Name = "numericUpDownPosY1";
			this.numericUpDownPosY1.Size = new System.Drawing.Size(53, 20);
			this.numericUpDownPosY1.TabIndex = 57;
			this.numericUpDownPosY1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownPosY1.Visible = false;
			// 
			// labelPosY2
			// 
			this.labelPosY2.AutoSize = true;
			this.labelPosY2.Location = new System.Drawing.Point(150, 145);
			this.labelPosY2.Name = "labelPosY2";
			this.labelPosY2.Size = new System.Drawing.Size(26, 13);
			this.labelPosY2.TabIndex = 55;
			this.labelPosY2.Text = "End";
			this.labelPosY2.Visible = false;
			// 
			// numericUpDownPosY2
			// 
			this.numericUpDownPosY2.DecimalPlaces = 2;
			this.numericUpDownPosY2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownPosY2.Location = new System.Drawing.Point(182, 143);
			this.numericUpDownPosY2.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownPosY2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.numericUpDownPosY2.Name = "numericUpDownPosY2";
			this.numericUpDownPosY2.Size = new System.Drawing.Size(53, 20);
			this.numericUpDownPosY2.TabIndex = 56;
			this.numericUpDownPosY2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelPosY1
			// 
			this.labelPosY1.AutoSize = true;
			this.labelPosY1.Location = new System.Drawing.Point(44, 145);
			this.labelPosY1.Name = "labelPosY1";
			this.labelPosY1.Size = new System.Drawing.Size(34, 13);
			this.labelPosY1.TabIndex = 54;
			this.labelPosY1.Text = "Value";
			// 
			// numericUpDownPosX1
			// 
			this.numericUpDownPosX1.DecimalPlaces = 2;
			this.numericUpDownPosX1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownPosX1.Location = new System.Drawing.Point(84, 90);
			this.numericUpDownPosX1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownPosX1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.numericUpDownPosX1.Name = "numericUpDownPosX1";
			this.numericUpDownPosX1.Size = new System.Drawing.Size(53, 20);
			this.numericUpDownPosX1.TabIndex = 53;
			this.numericUpDownPosX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownPosX1.Visible = false;
			// 
			// labelPosX2
			// 
			this.labelPosX2.AutoSize = true;
			this.labelPosX2.Location = new System.Drawing.Point(150, 92);
			this.labelPosX2.Name = "labelPosX2";
			this.labelPosX2.Size = new System.Drawing.Size(26, 13);
			this.labelPosX2.TabIndex = 37;
			this.labelPosX2.Text = "End";
			this.labelPosX2.Visible = false;
			// 
			// numericUpDownPosX2
			// 
			this.numericUpDownPosX2.DecimalPlaces = 2;
			this.numericUpDownPosX2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownPosX2.Location = new System.Drawing.Point(182, 90);
			this.numericUpDownPosX2.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownPosX2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.numericUpDownPosX2.Name = "numericUpDownPosX2";
			this.numericUpDownPosX2.Size = new System.Drawing.Size(53, 20);
			this.numericUpDownPosX2.TabIndex = 52;
			this.numericUpDownPosX2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(248, 47);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(30, 13);
			this.label20.TabIndex = 37;
			this.label20.Text = "Size:";
			// 
			// labelPosX1
			// 
			this.labelPosX1.AutoSize = true;
			this.labelPosX1.Location = new System.Drawing.Point(44, 92);
			this.labelPosX1.Name = "labelPosX1";
			this.labelPosX1.Size = new System.Drawing.Size(34, 13);
			this.labelPosX1.TabIndex = 23;
			this.labelPosX1.Text = "Value";
			// 
			// comboBoxPosY
			// 
			this.comboBoxPosY.FormattingEnabled = true;
			this.comboBoxPosY.Items.AddRange(new object[] {
            "Static",
            "Dynamic",
            "Random"});
			this.comboBoxPosY.Location = new System.Drawing.Point(47, 116);
			this.comboBoxPosY.Name = "comboBoxPosY";
			this.comboBoxPosY.Size = new System.Drawing.Size(188, 21);
			this.comboBoxPosY.TabIndex = 32;
			this.comboBoxPosY.Text = "Static";
			this.comboBoxPosY.SelectedIndexChanged += new System.EventHandler(this.comboBoxPosY_SelectedIndexChanged);
			// 
			// comboBoxPosX
			// 
			this.comboBoxPosX.FormattingEnabled = true;
			this.comboBoxPosX.Items.AddRange(new object[] {
            "Static",
            "Dynamic",
            "Random"});
			this.comboBoxPosX.Location = new System.Drawing.Point(47, 62);
			this.comboBoxPosX.Name = "comboBoxPosX";
			this.comboBoxPosX.Size = new System.Drawing.Size(188, 21);
			this.comboBoxPosX.TabIndex = 21;
			this.comboBoxPosX.Text = "Static";
			this.comboBoxPosX.SelectedIndexChanged += new System.EventHandler(this.comboBoxPosX_SelectedIndexChanged);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(27, 119);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(14, 13);
			this.label9.TabIndex = 20;
			this.label9.Text = "Y";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(27, 65);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(14, 13);
			this.label8.TabIndex = 19;
			this.label8.Text = "X";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(18, 46);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(47, 13);
			this.label7.TabIndex = 18;
			this.label7.Text = "Position:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(115, 20);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(41, 13);
			this.label6.TabIndex = 15;
			this.label6.Text = "Shape:";
			// 
			// comboBoxShape
			// 
			this.comboBoxShape.FormattingEnabled = true;
			this.comboBoxShape.Location = new System.Drawing.Point(162, 17);
			this.comboBoxShape.Name = "comboBoxShape";
			this.comboBoxShape.Size = new System.Drawing.Size(173, 21);
			this.comboBoxShape.TabIndex = 14;
			// 
			// checkBoxEnableRegion
			// 
			this.checkBoxEnableRegion.AutoSize = true;
			this.checkBoxEnableRegion.Location = new System.Drawing.Point(12, 313);
			this.checkBoxEnableRegion.Name = "checkBoxEnableRegion";
			this.checkBoxEnableRegion.Size = new System.Drawing.Size(98, 17);
			this.checkBoxEnableRegion.TabIndex = 13;
			this.checkBoxEnableRegion.Text = "Enable Region";
			this.checkBoxEnableRegion.UseVisualStyleBackColor = true;
			this.checkBoxEnableRegion.CheckedChanged += new System.EventHandler(this.checkBoxEnableRegion_CheckedChanged);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(405, 596);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 30;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(324, 596);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 31;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// numericUpDownEndSeconds
			// 
			this.numericUpDownEndSeconds.DecimalPlaces = 2;
			this.numericUpDownEndSeconds.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownEndSeconds.Location = new System.Drawing.Point(174, 552);
			this.numericUpDownEndSeconds.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
			this.numericUpDownEndSeconds.Name = "numericUpDownEndSeconds";
			this.numericUpDownEndSeconds.Size = new System.Drawing.Size(65, 20);
			this.numericUpDownEndSeconds.TabIndex = 32;
			this.numericUpDownEndSeconds.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.numericUpDownEndSeconds.Visible = false;
			// 
			// labelEndSeconds
			// 
			this.labelEndSeconds.AutoSize = true;
			this.labelEndSeconds.Location = new System.Drawing.Point(245, 555);
			this.labelEndSeconds.Name = "labelEndSeconds";
			this.labelEndSeconds.Size = new System.Drawing.Size(49, 13);
			this.labelEndSeconds.TabIndex = 33;
			this.labelEndSeconds.Text = "Seconds";
			this.labelEndSeconds.Visible = false;
			// 
			// Form2DTask
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(492, 639);
			this.Controls.Add(this.labelEndSeconds);
			this.Controls.Add(this.numericUpDownEndSeconds);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonRemoveInput);
			this.Controls.Add(this.buttonAddInput);
			this.Controls.Add(this.listBoxAdditionalInputs);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.comboBoxPerformanceMetric);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.comboBoxInputHandling);
			this.Controls.Add(this.comboBoxInputDevice);
			this.Controls.Add(this.comboBoxEndButton);
			this.Controls.Add(this.comboBoxEndCondition);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.TaskTitle);
			this.Controls.Add(this.checkBoxEnableRegion);
			this.Name = "Form2DTask";
			this.Text = "2D Task Options";
			this.Load += new System.EventHandler(this.Form2DTask_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2DTask_FormClosing);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeY1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeY2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeX1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeX2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosY1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosY2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosX1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosX2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndSeconds)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label TaskTitle;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxEndCondition;
        private System.Windows.Forms.ComboBox comboBoxEndButton;
        private System.Windows.Forms.ComboBox comboBoxInputDevice;
        private System.Windows.Forms.ComboBox comboBoxInputHandling;
        private System.Windows.Forms.ComboBox comboBoxPerformanceMetric;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox listBoxAdditionalInputs;
        private System.Windows.Forms.Button buttonAddInput;
        private System.Windows.Forms.Button buttonRemoveInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxShape;
        private System.Windows.Forms.CheckBox checkBoxEnableRegion;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxPosX;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelPosX1;
        private System.Windows.Forms.ComboBox comboBoxPosY;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numericUpDownPosX2;
        private System.Windows.Forms.Label labelPosX2;
        private System.Windows.Forms.NumericUpDown numericUpDownPosX1;
        private System.Windows.Forms.NumericUpDown numericUpDownPosY1;
        private System.Windows.Forms.Label labelPosY2;
        private System.Windows.Forms.NumericUpDown numericUpDownPosY2;
        private System.Windows.Forms.Label labelPosY1;
        private System.Windows.Forms.NumericUpDown numericUpDownSizeY1;
        private System.Windows.Forms.Label labelSizeY2;
        private System.Windows.Forms.NumericUpDown numericUpDownSizeY2;
        private System.Windows.Forms.Label labelSizeY1;
        private System.Windows.Forms.NumericUpDown numericUpDownSizeX1;
        private System.Windows.Forms.Label labelSizeX2;
        private System.Windows.Forms.NumericUpDown numericUpDownSizeX2;
        private System.Windows.Forms.Label labelSizeX1;
        private System.Windows.Forms.ComboBox comboBoxSizeY;
        private System.Windows.Forms.ComboBox comboBoxSizeX;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numericUpDownEndSeconds;
        private System.Windows.Forms.Label labelEndSeconds;
    }
}