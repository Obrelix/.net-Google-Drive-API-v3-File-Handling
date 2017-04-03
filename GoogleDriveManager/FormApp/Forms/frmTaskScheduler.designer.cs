namespace GoogleDriveManager
{
    partial class frmTaskScheduler
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePickerOneTimeOnlyDay = new System.Windows.Forms.DateTimePicker();
            this.numericUpDownDaily = new System.Windows.Forms.NumericUpDown();
            this.labelDailyEvery = new System.Windows.Forms.Label();
            this.labelDailyDay = new System.Windows.Forms.Label();
            this.checkedListBoxWeeklyDays = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxMonthlyMonths = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxMonthlyDays = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxMonthlyWeekNumber = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxMonthlyWeekDay = new System.Windows.Forms.CheckedListBox();
            this.tabControlMode = new System.Windows.Forms.TabControl();
            this.tabPageOneTimeOnly = new System.Windows.Forms.TabPage();
            this.checkBoxOneTimeOnlyActive = new System.Windows.Forms.CheckBox();
            this.labelOneTimeOnlyDay = new System.Windows.Forms.Label();
            this.tabPageDaily = new System.Windows.Forms.TabPage();
            this.tabPageWeekly = new System.Windows.Forms.TabPage();
            this.labelWeeklyDays = new System.Windows.Forms.Label();
            this.tabPageMonthly = new System.Windows.Forms.TabPage();
            this.tabControlMonthlyMode = new System.Windows.Forms.TabControl();
            this.tabPageMonthlyDayOfMonth = new System.Windows.Forms.TabPage();
            this.tabPageMonthlyWeekDay = new System.Windows.Forms.TabPage();
            this.labelMonthlyMonth = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.buttonCreateTrigger = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.listViewItems = new System.Windows.Forms.ListView();
            this.ItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NextTrigger = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonShowAllTrigger = new System.Windows.Forms.Button();
            this.dateTimePickerTriggerTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
            this.textBoxEvents = new System.Windows.Forms.TextBox();
            this.buttonItemToXML = new System.Windows.Forms.Button();
            this.textBoxlabelOneTimeOnlyTag = new System.Windows.Forms.TextBox();
            this.labelOneTimeOnlyTag = new System.Windows.Forms.Label();
            this.buttonItemFromXML = new System.Windows.Forms.Button();
            this.buttonCollectionToXML = new System.Windows.Forms.Button();
            this.buttonCollectionFromXML = new System.Windows.Forms.Button();
            this.buttonSaveAsServiceConfig = new System.Windows.Forms.Button();
            this.buttonInstallService = new System.Windows.Forms.Button();
            this.buttonUninstallService = new System.Windows.Forms.Button();
            this.buttonStartService = new System.Windows.Forms.Button();
            this.buttonStopService = new System.Windows.Forms.Button();
            this.buttonReadServiceConfig = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDaily)).BeginInit();
            this.tabControlMode.SuspendLayout();
            this.tabPageOneTimeOnly.SuspendLayout();
            this.tabPageDaily.SuspendLayout();
            this.tabPageWeekly.SuspendLayout();
            this.tabPageMonthly.SuspendLayout();
            this.tabControlMonthlyMode.SuspendLayout();
            this.tabPageMonthlyDayOfMonth.SuspendLayout();
            this.tabPageMonthlyWeekDay.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePickerOneTimeOnlyDay
            // 
            this.dateTimePickerOneTimeOnlyDay.Location = new System.Drawing.Point(68, 47);
            this.dateTimePickerOneTimeOnlyDay.Name = "dateTimePickerOneTimeOnlyDay";
            this.dateTimePickerOneTimeOnlyDay.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerOneTimeOnlyDay.TabIndex = 1;
            // 
            // numericUpDownDaily
            // 
            this.numericUpDownDaily.Location = new System.Drawing.Point(60, 18);
            this.numericUpDownDaily.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownDaily.Name = "numericUpDownDaily";
            this.numericUpDownDaily.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownDaily.TabIndex = 0;
            // 
            // labelDailyEvery
            // 
            this.labelDailyEvery.AutoSize = true;
            this.labelDailyEvery.Location = new System.Drawing.Point(20, 20);
            this.labelDailyEvery.Name = "labelDailyEvery";
            this.labelDailyEvery.Size = new System.Drawing.Size(34, 13);
            this.labelDailyEvery.TabIndex = 4;
            this.labelDailyEvery.Text = "Every";
            // 
            // labelDailyDay
            // 
            this.labelDailyDay.AutoSize = true;
            this.labelDailyDay.Location = new System.Drawing.Point(115, 20);
            this.labelDailyDay.Name = "labelDailyDay";
            this.labelDailyDay.Size = new System.Drawing.Size(24, 13);
            this.labelDailyDay.TabIndex = 5;
            this.labelDailyDay.Text = "day";
            // 
            // checkedListBoxWeeklyDays
            // 
            this.checkedListBoxWeeklyDays.FormattingEnabled = true;
            this.checkedListBoxWeeklyDays.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.checkedListBoxWeeklyDays.Location = new System.Drawing.Point(60, 20);
            this.checkedListBoxWeeklyDays.Name = "checkedListBoxWeeklyDays";
            this.checkedListBoxWeeklyDays.Size = new System.Drawing.Size(104, 109);
            this.checkedListBoxWeeklyDays.TabIndex = 0;
            // 
            // checkedListBoxMonthlyMonths
            // 
            this.checkedListBoxMonthlyMonths.FormattingEnabled = true;
            this.checkedListBoxMonthlyMonths.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.checkedListBoxMonthlyMonths.Location = new System.Drawing.Point(60, 20);
            this.checkedListBoxMonthlyMonths.Name = "checkedListBoxMonthlyMonths";
            this.checkedListBoxMonthlyMonths.Size = new System.Drawing.Size(120, 109);
            this.checkedListBoxMonthlyMonths.TabIndex = 0;
            // 
            // checkedListBoxMonthlyDays
            // 
            this.checkedListBoxMonthlyDays.FormattingEnabled = true;
            this.checkedListBoxMonthlyDays.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "Last Day"});
            this.checkedListBoxMonthlyDays.Location = new System.Drawing.Point(8, 8);
            this.checkedListBoxMonthlyDays.Name = "checkedListBoxMonthlyDays";
            this.checkedListBoxMonthlyDays.Size = new System.Drawing.Size(229, 109);
            this.checkedListBoxMonthlyDays.TabIndex = 29;
            // 
            // checkedListBoxMonthlyWeekNumber
            // 
            this.checkedListBoxMonthlyWeekNumber.FormattingEnabled = true;
            this.checkedListBoxMonthlyWeekNumber.Items.AddRange(new object[] {
            "First",
            "Second",
            "Third",
            "Fourth",
            "Last"});
            this.checkedListBoxMonthlyWeekNumber.Location = new System.Drawing.Point(8, 8);
            this.checkedListBoxMonthlyWeekNumber.Name = "checkedListBoxMonthlyWeekNumber";
            this.checkedListBoxMonthlyWeekNumber.Size = new System.Drawing.Size(120, 79);
            this.checkedListBoxMonthlyWeekNumber.TabIndex = 33;
            // 
            // checkedListBoxMonthlyWeekDay
            // 
            this.checkedListBoxMonthlyWeekDay.FormattingEnabled = true;
            this.checkedListBoxMonthlyWeekDay.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.checkedListBoxMonthlyWeekDay.Location = new System.Drawing.Point(132, 8);
            this.checkedListBoxMonthlyWeekDay.Name = "checkedListBoxMonthlyWeekDay";
            this.checkedListBoxMonthlyWeekDay.Size = new System.Drawing.Size(104, 109);
            this.checkedListBoxMonthlyWeekDay.TabIndex = 34;
            // 
            // tabControlMode
            // 
            this.tabControlMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMode.Controls.Add(this.tabPageOneTimeOnly);
            this.tabControlMode.Controls.Add(this.tabPageDaily);
            this.tabControlMode.Controls.Add(this.tabPageWeekly);
            this.tabControlMode.Controls.Add(this.tabPageMonthly);
            this.tabControlMode.Location = new System.Drawing.Point(16, 125);
            this.tabControlMode.Name = "tabControlMode";
            this.tabControlMode.SelectedIndex = 0;
            this.tabControlMode.Size = new System.Drawing.Size(639, 206);
            this.tabControlMode.TabIndex = 4;
            // 
            // tabPageOneTimeOnly
            // 
            this.tabPageOneTimeOnly.Controls.Add(this.checkBoxOneTimeOnlyActive);
            this.tabPageOneTimeOnly.Controls.Add(this.labelOneTimeOnlyDay);
            this.tabPageOneTimeOnly.Controls.Add(this.dateTimePickerOneTimeOnlyDay);
            this.tabPageOneTimeOnly.Location = new System.Drawing.Point(4, 22);
            this.tabPageOneTimeOnly.Name = "tabPageOneTimeOnly";
            this.tabPageOneTimeOnly.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOneTimeOnly.Size = new System.Drawing.Size(631, 180);
            this.tabPageOneTimeOnly.TabIndex = 0;
            this.tabPageOneTimeOnly.Tag = "1";
            this.tabPageOneTimeOnly.Text = "One time only";
            this.tabPageOneTimeOnly.UseVisualStyleBackColor = true;
            // 
            // checkBoxOneTimeOnlyActive
            // 
            this.checkBoxOneTimeOnlyActive.AutoSize = true;
            this.checkBoxOneTimeOnlyActive.Location = new System.Drawing.Point(20, 20);
            this.checkBoxOneTimeOnlyActive.Name = "checkBoxOneTimeOnlyActive";
            this.checkBoxOneTimeOnlyActive.Size = new System.Drawing.Size(56, 17);
            this.checkBoxOneTimeOnlyActive.TabIndex = 0;
            this.checkBoxOneTimeOnlyActive.Text = "Active";
            this.checkBoxOneTimeOnlyActive.UseVisualStyleBackColor = true;
            // 
            // labelOneTimeOnlyDay
            // 
            this.labelOneTimeOnlyDay.AutoSize = true;
            this.labelOneTimeOnlyDay.Location = new System.Drawing.Point(18, 53);
            this.labelOneTimeOnlyDay.Name = "labelOneTimeOnlyDay";
            this.labelOneTimeOnlyDay.Size = new System.Drawing.Size(29, 13);
            this.labelOneTimeOnlyDay.TabIndex = 2;
            this.labelOneTimeOnlyDay.Text = "Day:";
            // 
            // tabPageDaily
            // 
            this.tabPageDaily.Controls.Add(this.numericUpDownDaily);
            this.tabPageDaily.Controls.Add(this.labelDailyEvery);
            this.tabPageDaily.Controls.Add(this.labelDailyDay);
            this.tabPageDaily.Location = new System.Drawing.Point(4, 22);
            this.tabPageDaily.Name = "tabPageDaily";
            this.tabPageDaily.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDaily.Size = new System.Drawing.Size(631, 180);
            this.tabPageDaily.TabIndex = 1;
            this.tabPageDaily.Tag = "2";
            this.tabPageDaily.Text = "Daily";
            this.tabPageDaily.UseVisualStyleBackColor = true;
            // 
            // tabPageWeekly
            // 
            this.tabPageWeekly.Controls.Add(this.labelWeeklyDays);
            this.tabPageWeekly.Controls.Add(this.checkedListBoxWeeklyDays);
            this.tabPageWeekly.Location = new System.Drawing.Point(4, 22);
            this.tabPageWeekly.Name = "tabPageWeekly";
            this.tabPageWeekly.Size = new System.Drawing.Size(631, 180);
            this.tabPageWeekly.TabIndex = 3;
            this.tabPageWeekly.Tag = "3";
            this.tabPageWeekly.Text = "Weekly";
            this.tabPageWeekly.UseVisualStyleBackColor = true;
            // 
            // labelWeeklyDays
            // 
            this.labelWeeklyDays.AutoSize = true;
            this.labelWeeklyDays.Location = new System.Drawing.Point(20, 20);
            this.labelWeeklyDays.Name = "labelWeeklyDays";
            this.labelWeeklyDays.Size = new System.Drawing.Size(34, 13);
            this.labelWeeklyDays.TabIndex = 28;
            this.labelWeeklyDays.Text = "Days:";
            // 
            // tabPageMonthly
            // 
            this.tabPageMonthly.Controls.Add(this.tabControlMonthlyMode);
            this.tabPageMonthly.Controls.Add(this.labelMonthlyMonth);
            this.tabPageMonthly.Controls.Add(this.checkedListBoxMonthlyMonths);
            this.tabPageMonthly.Location = new System.Drawing.Point(4, 22);
            this.tabPageMonthly.Name = "tabPageMonthly";
            this.tabPageMonthly.Size = new System.Drawing.Size(631, 180);
            this.tabPageMonthly.TabIndex = 2;
            this.tabPageMonthly.Text = "Monthly";
            this.tabPageMonthly.UseVisualStyleBackColor = true;
            // 
            // tabControlMonthlyMode
            // 
            this.tabControlMonthlyMode.Controls.Add(this.tabPageMonthlyDayOfMonth);
            this.tabControlMonthlyMode.Controls.Add(this.tabPageMonthlyWeekDay);
            this.tabControlMonthlyMode.Location = new System.Drawing.Point(186, 20);
            this.tabControlMonthlyMode.Name = "tabControlMonthlyMode";
            this.tabControlMonthlyMode.SelectedIndex = 0;
            this.tabControlMonthlyMode.Size = new System.Drawing.Size(251, 154);
            this.tabControlMonthlyMode.TabIndex = 1;
            // 
            // tabPageMonthlyDayOfMonth
            // 
            this.tabPageMonthlyDayOfMonth.Controls.Add(this.checkedListBoxMonthlyDays);
            this.tabPageMonthlyDayOfMonth.Location = new System.Drawing.Point(4, 22);
            this.tabPageMonthlyDayOfMonth.Name = "tabPageMonthlyDayOfMonth";
            this.tabPageMonthlyDayOfMonth.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMonthlyDayOfMonth.Size = new System.Drawing.Size(243, 128);
            this.tabPageMonthlyDayOfMonth.TabIndex = 0;
            this.tabPageMonthlyDayOfMonth.Text = "Day of Month";
            this.tabPageMonthlyDayOfMonth.UseVisualStyleBackColor = true;
            // 
            // tabPageMonthlyWeekDay
            // 
            this.tabPageMonthlyWeekDay.Controls.Add(this.checkedListBoxMonthlyWeekNumber);
            this.tabPageMonthlyWeekDay.Controls.Add(this.checkedListBoxMonthlyWeekDay);
            this.tabPageMonthlyWeekDay.Location = new System.Drawing.Point(4, 22);
            this.tabPageMonthlyWeekDay.Name = "tabPageMonthlyWeekDay";
            this.tabPageMonthlyWeekDay.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMonthlyWeekDay.Size = new System.Drawing.Size(243, 128);
            this.tabPageMonthlyWeekDay.TabIndex = 1;
            this.tabPageMonthlyWeekDay.Text = "Weekday";
            this.tabPageMonthlyWeekDay.UseVisualStyleBackColor = true;
            // 
            // labelMonthlyMonth
            // 
            this.labelMonthlyMonth.AutoSize = true;
            this.labelMonthlyMonth.Location = new System.Drawing.Point(20, 20);
            this.labelMonthlyMonth.Name = "labelMonthlyMonth";
            this.labelMonthlyMonth.Size = new System.Drawing.Size(40, 13);
            this.labelMonthlyMonth.TabIndex = 29;
            this.labelMonthlyMonth.Text = "Month:";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(13, 15);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(32, 13);
            this.labelStartDate.TabIndex = 36;
            this.labelStartDate.Text = "Start:";
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(61, 12);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerStartDate.TabIndex = 0;
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(61, 38);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEndDate.TabIndex = 1;
            this.dateTimePickerEndDate.Value = new System.DateTime(2010, 7, 12, 17, 25, 0, 0);
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(13, 41);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(29, 13);
            this.labelEndDate.TabIndex = 38;
            this.labelEndDate.Text = "End:";
            // 
            // buttonCreateTrigger
            // 
            this.buttonCreateTrigger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateTrigger.Location = new System.Drawing.Point(381, 347);
            this.buttonCreateTrigger.Name = "buttonCreateTrigger";
            this.buttonCreateTrigger.Size = new System.Drawing.Size(130, 23);
            this.buttonCreateTrigger.TabIndex = 7;
            this.buttonCreateTrigger.Text = "Create TriggerItem";
            this.buttonCreateTrigger.UseVisualStyleBackColor = true;
            this.buttonCreateTrigger.Click += new System.EventHandler(this.buttonCreateTrigger_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.Location = new System.Drawing.Point(381, 376);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(130, 23);
            this.buttonReset.TabIndex = 8;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // listViewItems
            // 
            this.listViewItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemName,
            this.NextTrigger});
            this.listViewItems.FullRowSelect = true;
            this.listViewItems.Location = new System.Drawing.Point(16, 347);
            this.listViewItems.Name = "listViewItems";
            this.listViewItems.Size = new System.Drawing.Size(359, 115);
            this.listViewItems.TabIndex = 5;
            this.listViewItems.UseCompatibleStateImageBehavior = false;
            this.listViewItems.View = System.Windows.Forms.View.Details;
            // 
            // ItemName
            // 
            this.ItemName.Text = "Item";
            this.ItemName.Width = 150;
            // 
            // NextTrigger
            // 
            this.NextTrigger.Text = "Next Trigger";
            this.NextTrigger.Width = 150;
            // 
            // buttonShowAllTrigger
            // 
            this.buttonShowAllTrigger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowAllTrigger.Location = new System.Drawing.Point(381, 405);
            this.buttonShowAllTrigger.Name = "buttonShowAllTrigger";
            this.buttonShowAllTrigger.Size = new System.Drawing.Size(130, 23);
            this.buttonShowAllTrigger.TabIndex = 9;
            this.buttonShowAllTrigger.Text = "Show Day-List";
            this.buttonShowAllTrigger.UseVisualStyleBackColor = true;
            this.buttonShowAllTrigger.Click += new System.EventHandler(this.buttonShowAllTrigger_Click);
            // 
            // dateTimePickerTriggerTime
            // 
            this.dateTimePickerTriggerTime.CustomFormat = "";
            this.dateTimePickerTriggerTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerTriggerTime.Location = new System.Drawing.Point(61, 64);
            this.dateTimePickerTriggerTime.Name = "dateTimePickerTriggerTime";
            this.dateTimePickerTriggerTime.ShowUpDown = true;
            this.dateTimePickerTriggerTime.Size = new System.Drawing.Size(96, 20);
            this.dateTimePickerTriggerTime.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Time:";
            // 
            // checkBoxEnabled
            // 
            this.checkBoxEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEnabled.AutoSize = true;
            this.checkBoxEnabled.Checked = true;
            this.checkBoxEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnabled.Location = new System.Drawing.Point(532, 602);
            this.checkBoxEnabled.Name = "checkBoxEnabled";
            this.checkBoxEnabled.Size = new System.Drawing.Size(115, 17);
            this.checkBoxEnabled.TabIndex = 20;
            this.checkBoxEnabled.Text = "Scheduler enabled";
            this.checkBoxEnabled.UseVisualStyleBackColor = true;
            this.checkBoxEnabled.CheckedChanged += new System.EventHandler(this.checkBoxEnabled_CheckedChanged);
            // 
            // textBoxEvents
            // 
            this.textBoxEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEvents.Location = new System.Drawing.Point(16, 468);
            this.textBoxEvents.Multiline = true;
            this.textBoxEvents.Name = "textBoxEvents";
            this.textBoxEvents.Size = new System.Drawing.Size(359, 143);
            this.textBoxEvents.TabIndex = 6;
            this.textBoxEvents.WordWrap = false;
            // 
            // buttonItemToXML
            // 
            this.buttonItemToXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonItemToXML.Location = new System.Drawing.Point(517, 347);
            this.buttonItemToXML.Name = "buttonItemToXML";
            this.buttonItemToXML.Size = new System.Drawing.Size(130, 23);
            this.buttonItemToXML.TabIndex = 10;
            this.buttonItemToXML.Text = "Item to XML";
            this.buttonItemToXML.UseVisualStyleBackColor = true;
            this.buttonItemToXML.Click += new System.EventHandler(this.buttonToXML_Click);
            // 
            // textBoxlabelOneTimeOnlyTag
            // 
            this.textBoxlabelOneTimeOnlyTag.Location = new System.Drawing.Point(63, 88);
            this.textBoxlabelOneTimeOnlyTag.Name = "textBoxlabelOneTimeOnlyTag";
            this.textBoxlabelOneTimeOnlyTag.Size = new System.Drawing.Size(152, 20);
            this.textBoxlabelOneTimeOnlyTag.TabIndex = 3;
            this.textBoxlabelOneTimeOnlyTag.Text = "New Item";
            // 
            // labelOneTimeOnlyTag
            // 
            this.labelOneTimeOnlyTag.AutoSize = true;
            this.labelOneTimeOnlyTag.Location = new System.Drawing.Point(13, 91);
            this.labelOneTimeOnlyTag.Name = "labelOneTimeOnlyTag";
            this.labelOneTimeOnlyTag.Size = new System.Drawing.Size(29, 13);
            this.labelOneTimeOnlyTag.TabIndex = 53;
            this.labelOneTimeOnlyTag.Text = "Tag:";
            // 
            // buttonItemFromXML
            // 
            this.buttonItemFromXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonItemFromXML.Location = new System.Drawing.Point(517, 376);
            this.buttonItemFromXML.Name = "buttonItemFromXML";
            this.buttonItemFromXML.Size = new System.Drawing.Size(130, 23);
            this.buttonItemFromXML.TabIndex = 11;
            this.buttonItemFromXML.Text = "Item from XML";
            this.buttonItemFromXML.UseVisualStyleBackColor = true;
            this.buttonItemFromXML.Click += new System.EventHandler(this.buttonFromXML_Click);
            // 
            // buttonCollectionToXML
            // 
            this.buttonCollectionToXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCollectionToXML.Location = new System.Drawing.Point(517, 405);
            this.buttonCollectionToXML.Name = "buttonCollectionToXML";
            this.buttonCollectionToXML.Size = new System.Drawing.Size(130, 23);
            this.buttonCollectionToXML.TabIndex = 12;
            this.buttonCollectionToXML.Text = "Collection to XML";
            this.buttonCollectionToXML.UseVisualStyleBackColor = true;
            this.buttonCollectionToXML.Click += new System.EventHandler(this.buttonCollectionToXML_Click);
            // 
            // buttonCollectionFromXML
            // 
            this.buttonCollectionFromXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCollectionFromXML.Location = new System.Drawing.Point(517, 434);
            this.buttonCollectionFromXML.Name = "buttonCollectionFromXML";
            this.buttonCollectionFromXML.Size = new System.Drawing.Size(130, 23);
            this.buttonCollectionFromXML.TabIndex = 13;
            this.buttonCollectionFromXML.Text = "Collection from XML";
            this.buttonCollectionFromXML.UseVisualStyleBackColor = true;
            this.buttonCollectionFromXML.Click += new System.EventHandler(this.buttonCollectionFromXML_Click);
            // 
            // buttonSaveAsServiceConfig
            // 
            this.buttonSaveAsServiceConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveAsServiceConfig.Location = new System.Drawing.Point(381, 480);
            this.buttonSaveAsServiceConfig.Name = "buttonSaveAsServiceConfig";
            this.buttonSaveAsServiceConfig.Size = new System.Drawing.Size(130, 23);
            this.buttonSaveAsServiceConfig.TabIndex = 14;
            this.buttonSaveAsServiceConfig.Text = "Save as service config";
            this.buttonSaveAsServiceConfig.UseVisualStyleBackColor = true;
            this.buttonSaveAsServiceConfig.Click += new System.EventHandler(this.buttonSaveAsServiceConfig_Click);
            // 
            // buttonInstallService
            // 
            this.buttonInstallService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInstallService.Location = new System.Drawing.Point(517, 480);
            this.buttonInstallService.Name = "buttonInstallService";
            this.buttonInstallService.Size = new System.Drawing.Size(130, 23);
            this.buttonInstallService.TabIndex = 16;
            this.buttonInstallService.Text = "Install service";
            this.buttonInstallService.UseVisualStyleBackColor = true;
            this.buttonInstallService.Click += new System.EventHandler(this.buttonInstallService_Click);
            // 
            // buttonUninstallService
            // 
            this.buttonUninstallService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUninstallService.Location = new System.Drawing.Point(517, 509);
            this.buttonUninstallService.Name = "buttonUninstallService";
            this.buttonUninstallService.Size = new System.Drawing.Size(130, 23);
            this.buttonUninstallService.TabIndex = 17;
            this.buttonUninstallService.Text = "Uninstall service";
            this.buttonUninstallService.UseVisualStyleBackColor = true;
            this.buttonUninstallService.Click += new System.EventHandler(this.buttonUninstallService_Click);
            // 
            // buttonStartService
            // 
            this.buttonStartService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartService.Location = new System.Drawing.Point(517, 538);
            this.buttonStartService.Name = "buttonStartService";
            this.buttonStartService.Size = new System.Drawing.Size(130, 23);
            this.buttonStartService.TabIndex = 18;
            this.buttonStartService.Text = "Start service";
            this.buttonStartService.UseVisualStyleBackColor = true;
            this.buttonStartService.Click += new System.EventHandler(this.buttonStartService_Click);
            // 
            // buttonStopService
            // 
            this.buttonStopService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStopService.Location = new System.Drawing.Point(517, 567);
            this.buttonStopService.Name = "buttonStopService";
            this.buttonStopService.Size = new System.Drawing.Size(130, 23);
            this.buttonStopService.TabIndex = 19;
            this.buttonStopService.Text = "Stop service";
            this.buttonStopService.UseVisualStyleBackColor = true;
            this.buttonStopService.Click += new System.EventHandler(this.buttonStopService_Click);
            // 
            // buttonReadServiceConfig
            // 
            this.buttonReadServiceConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReadServiceConfig.Location = new System.Drawing.Point(381, 509);
            this.buttonReadServiceConfig.Name = "buttonReadServiceConfig";
            this.buttonReadServiceConfig.Size = new System.Drawing.Size(130, 23);
            this.buttonReadServiceConfig.TabIndex = 15;
            this.buttonReadServiceConfig.Text = "Read service config";
            this.buttonReadServiceConfig.UseVisualStyleBackColor = true;
            this.buttonReadServiceConfig.Click += new System.EventHandler(this.buttonReadServiceConfig_Click);
            // 
            // Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 623);
            this.Controls.Add(this.buttonReadServiceConfig);
            this.Controls.Add(this.buttonStopService);
            this.Controls.Add(this.buttonStartService);
            this.Controls.Add(this.buttonUninstallService);
            this.Controls.Add(this.buttonInstallService);
            this.Controls.Add(this.buttonSaveAsServiceConfig);
            this.Controls.Add(this.buttonCreateTrigger);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonItemToXML);
            this.Controls.Add(this.buttonShowAllTrigger);
            this.Controls.Add(this.buttonCollectionFromXML);
            this.Controls.Add(this.buttonItemFromXML);
            this.Controls.Add(this.textBoxlabelOneTimeOnlyTag);
            this.Controls.Add(this.buttonCollectionToXML);
            this.Controls.Add(this.labelOneTimeOnlyTag);
            this.Controls.Add(this.textBoxEvents);
            this.Controls.Add(this.checkBoxEnabled);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerTriggerTime);
            this.Controls.Add(this.listViewItems);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.tabControlMode);
            this.Name = "Demo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Scheduler ";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDaily)).EndInit();
            this.tabControlMode.ResumeLayout(false);
            this.tabPageOneTimeOnly.ResumeLayout(false);
            this.tabPageOneTimeOnly.PerformLayout();
            this.tabPageDaily.ResumeLayout(false);
            this.tabPageDaily.PerformLayout();
            this.tabPageWeekly.ResumeLayout(false);
            this.tabPageWeekly.PerformLayout();
            this.tabPageMonthly.ResumeLayout(false);
            this.tabPageMonthly.PerformLayout();
            this.tabControlMonthlyMode.ResumeLayout(false);
            this.tabPageMonthlyDayOfMonth.ResumeLayout(false);
            this.tabPageMonthlyWeekDay.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerOneTimeOnlyDay;
        private System.Windows.Forms.NumericUpDown numericUpDownDaily;
        private System.Windows.Forms.Label labelDailyEvery;
        private System.Windows.Forms.Label labelDailyDay;
        private System.Windows.Forms.CheckedListBox checkedListBoxWeeklyDays;
        private System.Windows.Forms.CheckedListBox checkedListBoxMonthlyMonths;
        private System.Windows.Forms.CheckedListBox checkedListBoxMonthlyDays;
        private System.Windows.Forms.CheckedListBox checkedListBoxMonthlyWeekNumber;
        private System.Windows.Forms.CheckedListBox checkedListBoxMonthlyWeekDay;
        private System.Windows.Forms.TabControl tabControlMode;
        private System.Windows.Forms.TabPage tabPageOneTimeOnly;
        private System.Windows.Forms.TabPage tabPageDaily;
        private System.Windows.Forms.TabPage tabPageMonthly;
        private System.Windows.Forms.Label labelOneTimeOnlyDay;
        private System.Windows.Forms.TabPage tabPageWeekly;
        private System.Windows.Forms.Label labelWeeklyDays;
        private System.Windows.Forms.Label labelMonthlyMonth;
        private System.Windows.Forms.TabControl tabControlMonthlyMode;
        private System.Windows.Forms.TabPage tabPageMonthlyDayOfMonth;
        private System.Windows.Forms.TabPage tabPageMonthlyWeekDay;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Button buttonCreateTrigger;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.ListView listViewItems;
        private System.Windows.Forms.ColumnHeader ItemName;
        private System.Windows.Forms.ColumnHeader NextTrigger;
        private System.Windows.Forms.Button buttonShowAllTrigger;
        private System.Windows.Forms.DateTimePicker dateTimePickerTriggerTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxEnabled;
        private System.Windows.Forms.TextBox textBoxEvents;
        private System.Windows.Forms.Button buttonItemToXML;
        private System.Windows.Forms.TextBox textBoxlabelOneTimeOnlyTag;
        private System.Windows.Forms.Label labelOneTimeOnlyTag;
        private System.Windows.Forms.CheckBox checkBoxOneTimeOnlyActive;
        private System.Windows.Forms.Button buttonItemFromXML;
        private System.Windows.Forms.Button buttonCollectionToXML;
        private System.Windows.Forms.Button buttonCollectionFromXML;
        private System.Windows.Forms.Button buttonSaveAsServiceConfig;
        private System.Windows.Forms.Button buttonInstallService;
        private System.Windows.Forms.Button buttonUninstallService;
        private System.Windows.Forms.Button buttonStartService;
        private System.Windows.Forms.Button buttonStopService;
        private System.Windows.Forms.Button buttonReadServiceConfig;

    }
}

