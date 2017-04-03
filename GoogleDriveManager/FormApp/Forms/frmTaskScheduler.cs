
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GoogleDriveManager
{
    public partial class frmTaskScheduler : Form
    {
        private TaskScheduler _taskScheduler;
        public frmTaskScheduler()
        {
            InitializeComponent();
            _taskScheduler = new TaskScheduler();

            // Set the synchronizing object to get trigger events within the main thread.
            // Important if you are using Windows Forms
            _taskScheduler.SynchronizingObject = this; 

            dateTimePickerStartDate.Value = DateTime.Today;
            dateTimePickerEndDate.Value = DateTime.Today.AddYears(1);
            dateTimePickerTriggerTime.Value = DateTime.Now.AddMinutes(10); // Add 10 Minutes for testing
        }

        private void UpdateTaskList()
        {
            listViewItems.Items.Clear();
            foreach (TaskScheduler.TriggerItem item in _taskScheduler.TriggerItems)
            {
                ListViewItem listItem = listViewItems.Items.Add(item.Tag.ToString());
                listItem.Tag = item;
                DateTime nextDate = item.GetNextTriggerDateTime();
                if (nextDate != DateTime.MaxValue)
                    listItem.SubItems.Add(nextDate.ToString());
                else
                    listItem.SubItems.Add("Never");
            }
        }

        private void ResetScheduler()
        {
            _taskScheduler.Enabled = false;
            _taskScheduler.TriggerItems.Clear();
            UpdateTaskList();
            textBoxEvents.Clear();
        }

        private void CreateSchedulerItem()
        {
            TaskScheduler.TriggerItem triggerItem = new TaskScheduler.TriggerItem();
            triggerItem.Tag = textBoxlabelOneTimeOnlyTag.Text;
            triggerItem.StartDate = dateTimePickerStartDate.Value;
            triggerItem.EndDate = dateTimePickerEndDate.Value;
            triggerItem.TriggerTime = dateTimePickerTriggerTime.Value;
            triggerItem.OnTrigger += new TaskScheduler.TriggerItem.OnTriggerEventHandler(triggerItem_OnTrigger); // And the trigger-Event :)

            // Set OneTimeOnly - Active and Date
            triggerItem.TriggerSettings.OneTimeOnly.Active = checkBoxOneTimeOnlyActive.Checked;
            triggerItem.TriggerSettings.OneTimeOnly.Date = dateTimePickerOneTimeOnlyDay.Value.Date;

            // Set the interval for daily trigger
            triggerItem.TriggerSettings.Daily.Interval = (ushort)numericUpDownDaily.Value;

            // Set the active days for weekly trigger
            for (byte day = 0; day < 7; day++) // Set the active Days
                triggerItem.TriggerSettings.Weekly.DaysOfWeek[day] = checkedListBoxWeeklyDays.GetItemChecked(day);

            // Set the active months for monthly trigger
            for (byte month = 0; month < 12; month++)
                triggerItem.TriggerSettings.Monthly.Month[month] = checkedListBoxMonthlyMonths.GetItemChecked(month);

            // Set active Days (0..30 = Days, 31=last Day) for monthly trigger
            for (byte day = 0; day < 32; day++)
                triggerItem.TriggerSettings.Monthly.DaysOfMonth[day] = checkedListBoxMonthlyDays.GetItemChecked(day);

            // Set the active weekNumber and DayOfWeek for monthly trigger
            // f.e. the first monday, or the last friday...
            for (byte weekNumber = 0; weekNumber < 5; weekNumber++) // 0..4: first, second, third, fourth or last week
                triggerItem.TriggerSettings.Monthly.WeekDay.WeekNumber[weekNumber] = checkedListBoxMonthlyWeekNumber.GetItemChecked(weekNumber);
            for (byte day = 0; day < 7; day++)
                triggerItem.TriggerSettings.Monthly.WeekDay.DayOfWeek[day] = checkedListBoxMonthlyWeekDay.GetItemChecked(day);

            triggerItem.Enabled = true; // Set the Item-Active - State
            _taskScheduler.AddTrigger(triggerItem); // Add the trigger to List
            _taskScheduler.Enabled = checkBoxEnabled.Checked; // Start the Scheduler

            UpdateTaskList();
        }

        private void ShowAllTriggerDates()
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                TaskScheduler.TriggerItem item = (TaskScheduler.TriggerItem)listViewItems.SelectedItems[0].Tag;
                Form form = new Form();
                ListView listView = new ListView();
                listView.FullRowSelect = true;

                form.Text = "Full list for Task: "+item.Tag.ToString();
                form.Width = 400;
                form.Height = 450;

                listView.Parent = form;
                listView.Dock = DockStyle.Fill;
                listView.View = View.Details;
                listView.Columns.Add("Date", 200);

                DateTime date = dateTimePickerStartDate.Value.Date;
                while (date <= dateTimePickerEndDate.Value.Date)
                {
                    if (item.CheckDate(date)) // probe this date
                        listView.Items.Add(date.ToLongDateString());
                    date = date.AddDays(1);
                }
                form.Show();
            }
            else
                MessageBox.Show("Please select a trigger!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportItemToXML()
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                TaskScheduler.TriggerItem item = (TaskScheduler.TriggerItem)listViewItems.SelectedItems[0].Tag;
                textBoxEvents.Clear();
                textBoxEvents.AppendText(item.ToXML()); // Save the configuration to XML
            }
            else
                MessageBox.Show("Please select a trigger!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ImportItemFromXML()
        {
            try
            {
                TaskScheduler.TriggerItem newItem = TaskScheduler.TriggerItem.FromXML(textBoxEvents.Text);
                newItem.Enabled = true; // Enable Item here if you like 
                newItem.OnTrigger += new TaskScheduler.TriggerItem.OnTriggerEventHandler(triggerItem_OnTrigger); // And the trigger-Event :)
                _taskScheduler.AddTrigger(newItem); // Trigger hinzufügen
                _taskScheduler.Enabled = checkBoxEnabled.Checked; // Start the Scheduler
                UpdateTaskList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: parse XML: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ExportCollectionToXML()
        {
            String xmlString = String.Empty;
            try
            {
                xmlString = _taskScheduler.TriggerItems.ToXML();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: generate XML: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return xmlString;
        }

        private void ImportCollectionFromXML(String xmlString)        
        {
            _taskScheduler.TriggerItems.Clear();
            try
            {
                TaskScheduler.TriggerItemCollection items = TaskScheduler.TriggerItemCollection.FromXML(xmlString);
                _taskScheduler.TriggerItems.AddRange(items, new TaskScheduler.TriggerItem.OnTriggerEventHandler(triggerItem_OnTrigger));
                _taskScheduler.Enabled = checkBoxEnabled.Checked; // Start the Scheduler
                UpdateTaskList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: parse XML: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportCollectionFromXML()
        {
            ImportCollectionFromXML(textBoxEvents.Text);
        }

        private String GetServiceConfigFileName()
        {
            String commonAppData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            String configDirectory = commonAppData + Path.DirectorySeparatorChar + "TaskScheduler";
            return configDirectory + Path.DirectorySeparatorChar + "SchedulerItems.xml";
        }

        private void ReadServiceConfig()
        {
            ResetScheduler();

            String configFile = GetServiceConfigFileName();

            String xmlString = String.Empty;
            try
            {
                xmlString = System.IO.File.ReadAllText(configFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(("Can't read config file: " + configFile + ": " + ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                ImportCollectionFromXML(xmlString);
            }
        }

        private void SaveAsServiceConfig()
        {
            if (_taskScheduler.TriggerItems.Count == 0)
            {
                MessageBox.Show("Please create trigger items!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String xmlString = ExportCollectionToXML();
            String configFile = GetServiceConfigFileName();

            String directory = Path.GetDirectoryName(configFile);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            using (StreamWriter outfile = new StreamWriter(configFile))
            {
                try
                {
                    outfile.Write(xmlString);
                    MessageBox.Show("Configuration saved successfully!" + Environment.NewLine + Environment.NewLine + "Filename: " + configFile, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: write XML: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void InstallService()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                TaskSchedulerServiceAssistant.Install();
                MessageBox.Show("Service installation successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: install service: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private static void UninstallService()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                TaskSchedulerServiceAssistant.Uninstall();
                MessageBox.Show("Service removed successfuly", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: uninstall service: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private static void StartService()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                TaskSchedulerServiceAssistant.StartService();
                MessageBox.Show("Service start successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: start service: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private static void StopService()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                TaskSchedulerServiceAssistant.StopService();
                MessageBox.Show("Service stop successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: stop service: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        void triggerItem_OnTrigger(object sender, TaskScheduler.OnTriggerEventArgs e)
        {
            String nextTrigger = String.Empty;
            if (e.Item.GetNextTriggerDateTime() != DateTime.MaxValue)
                nextTrigger = e.Item.GetNextTriggerDateTime().DayOfWeek.ToString() + ", " + e.Item.GetNextTriggerDateTime().ToString();
            else
                nextTrigger = "Never";
            textBoxEvents.AppendText(e.TriggerDate.ToString() + ": " + e.Item.Tag + ", next trigger: " + nextTrigger + "\r\n");
            UpdateTaskList();
        }

        private void buttonCreateTrigger_Click(object sender, EventArgs e)
        {
            CreateSchedulerItem();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetScheduler();
        }

        private void buttonShowAllTrigger_Click(object sender, EventArgs e)
        {
            ShowAllTriggerDates();
        }

        private void buttonToXML_Click(object sender, EventArgs e)
        {
            ExportItemToXML(); // Use the static method TaskScheduler.TriggerItem.FromXML to load a TriggerItem
        }

        private void checkBoxEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _taskScheduler.Enabled = checkBoxEnabled.Checked;
        }

        private void buttonFromXML_Click(object sender, EventArgs e)
        {
            ImportItemFromXML();
        }

        private void buttonCollectionToXML_Click(object sender, EventArgs e)
        {
            textBoxEvents.Clear();
            textBoxEvents.AppendText(ExportCollectionToXML()); // Save the configuration to XML
        }

        private void buttonCollectionFromXML_Click(object sender, EventArgs e)
        {
            ImportCollectionFromXML();
        }

        private void buttonSaveAsServiceConfig_Click(object sender, EventArgs e)
        {
            SaveAsServiceConfig();
        }

        private void buttonReadServiceConfig_Click(object sender, EventArgs e)
        {
            ReadServiceConfig();
        }

        private void buttonInstallService_Click(object sender, EventArgs e)
        {
            InstallService();
        }

        private void buttonUninstallService_Click(object sender, EventArgs e)
        {
            UninstallService();
        }

        private void buttonStartService_Click(object sender, EventArgs e)
        {
            StartService();
        }

        private void buttonStopService_Click(object sender, EventArgs e)
        {
            StopService();
        }
    }
}