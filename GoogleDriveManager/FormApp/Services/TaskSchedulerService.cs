using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;

namespace GoogleDriveManager
{
    class TaskSchedulerService : ServiceBase
    {
        TaskScheduler _taskScheduler;
        private Boolean _shutdownFlag;

        public TaskSchedulerService()
        {
            this.ServiceName = "TaskSchedulerDemoService";
            this.EventLog.Log = "Application";

            writeInfoLogEntry("TaskSchedulerService()");
           
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
            this.CanStop = true;

            _shutdownFlag = false;
        }

        private void RunService()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += DoWork;
            worker.RunWorkerAsync();
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            _taskScheduler = new TaskScheduler();
            loadItems();
            _taskScheduler.Enabled = true;

            bool shutdown;            
            do
            {
                lock (_taskScheduler)
                {
                    shutdown = _shutdownFlag;
                }
                System.Threading.Thread.Sleep(100);
            } while (!shutdown);
        }

        private void ShutdownService()
        {
            lock (_taskScheduler)
            {
                _shutdownFlag = true;
            }
        }

        private void writeInfoLogEntry(String Message)
        {
            EventLog.WriteEntry(Message, EventLogEntryType.Information);
        }

        private void writeErrorLogEntry(String Message)
        {
            EventLog.WriteEntry(Message, EventLogEntryType.Error);
        }

        private void loadItems()
        {
            String commonAppData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            String configDirectory = commonAppData + Path.DirectorySeparatorChar + "TaskScheduler";
            String configFile = configDirectory + Path.DirectorySeparatorChar + "scheduleritems.xml";

            if (!File.Exists(configFile))
            {
                writeErrorLogEntry("Config file not found: "+ configFile);
                return;
            }

            String xmlString = String.Empty;
            try
            {
                xmlString = System.IO.File.ReadAllText(configFile);
            }
            catch (Exception ex)
            {
                writeErrorLogEntry("Can't read config file: " + configFile + ": " + ex.Message);
                return;
            }

            try
            {
                TaskScheduler.TriggerItemCollection items = TaskScheduler.TriggerItemCollection.FromXML(xmlString);
                _taskScheduler.TriggerItems.AddRange(items, new TaskScheduler.TriggerItem.OnTriggerEventHandler(OnTrigger));
                writeInfoLogEntry("Trigger items loaded: " + items.Count.ToString());
            }
            catch (Exception ex)
            {
                writeErrorLogEntry("Can't parse config file: " + configFile + ": " + ex.Message);
                return;
            }
        }

        void OnTrigger(object sender, TaskScheduler.OnTriggerEventArgs e)
        {
            if (e.Item.GetNextTriggerDateTime() != DateTime.MaxValue)
                writeInfoLogEntry("OnTrigger: Tag: " + e.Item.Tag.ToString() + Environment.NewLine + "Next trigger: " + e.Item.GetNextTriggerDateTime().ToString());
            else
                writeInfoLogEntry("OnTrigger: Tag: " + e.Item.Tag.ToString() + Environment.NewLine + "Next trigger: Never");
        }

        protected override void OnStart(string[] args)
        {
            writeInfoLogEntry("OnStart");
            RunService();
            base.OnStart(args);
        }

        protected override void OnStop()
        {
            writeInfoLogEntry("OnStop");
            ShutdownService();
            base.OnStop();
        }

        protected override void OnPause()
        {
            writeInfoLogEntry("OnPause");
            _taskScheduler.Enabled = false;
            base.OnPause();
        }

        protected override void OnContinue()
        {
            writeInfoLogEntry("OnContinue");
            loadItems(); // refresh config on continue
            _taskScheduler.Enabled = true;
            base.OnContinue();
        }
    }
}
