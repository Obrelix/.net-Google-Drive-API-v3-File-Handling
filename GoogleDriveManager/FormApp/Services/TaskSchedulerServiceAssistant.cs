using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.ServiceProcess;
using System.Configuration.Install;
using System.Collections;

namespace GoogleDriveManager
{

    [RunInstaller(true)]
    public sealed class TaskSchedulerServiceInstallerProcess : ServiceProcessInstaller
    {
        public TaskSchedulerServiceInstallerProcess()
        {
            this.Account = ServiceAccount.NetworkService;
        }

        private string AppendPathParameter(string path, string parameter)
        {
            path += " " + parameter;
            return path;
        }

        protected override void OnBeforeInstall(System.Collections.IDictionary savedState)
        {
            Context.Parameters["assemblypath"] = AppendPathParameter(Context.Parameters["assemblypath"], " \" --service\"");
            base.OnBeforeInstall(savedState);
        }

    }

    [RunInstaller(true)]
    public sealed class TaskSchedulerServiceInstaller : ServiceInstaller
    {
        public TaskSchedulerServiceInstaller()
        {
            this.ServiceName = "TaskSchedulerDemoService";
            this.DisplayName = "Task scheduler demo";
            this.Description = "Demo service description";
            this.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
        }
    }

    public class TaskSchedulerServiceAssistant
    {
        /// <summary>
        /// Install the new service
        /// </summary>
        public static void Install()
        {
            using (AssemblyInstaller inst = new AssemblyInstaller(typeof(Program).Assembly, null))
            {
                IDictionary state = new Hashtable();
                inst.UseNewContext = true;
                try
                {
                    inst.Install(state);
                    inst.Commit(state);
                }
                catch
                {
                    try
                    {
                        inst.Rollback(state);
                    }
                    catch { }
                    throw;
                }
            }
        }

        /// <summary>
        /// Uninstall the service
        /// </summary>
        public static void Uninstall()
        {
            using (AssemblyInstaller inst = new AssemblyInstaller(typeof(Program).Assembly, null))
            {
                IDictionary state = new Hashtable();
                inst.UseNewContext = true;
                try
                {
                    inst.Uninstall(state);
                }
                catch
                {
                    try
                    {
                        inst.Rollback(state);
                    }
                    catch { }
                    throw;
                }
            }
        }


        /// <summary>
        /// Start task scheduler service
        /// </summary>
        public static void StartService()
        {
            ServiceController service = new ServiceController("TaskSchedulerDemoService");
            TimeSpan timeout = TimeSpan.FromMilliseconds(5000);

            service.Start();
            service.WaitForStatus(ServiceControllerStatus.Running, timeout);
        }

        /// <summary>
        /// Stop task scheduler service
        /// </summary>
        public static void StopService()
        {
            ServiceController service = new ServiceController("TaskSchedulerDemoService");
            TimeSpan timeout = TimeSpan.FromMilliseconds(5000);

            service.Stop();
            service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
        }
    }
}
