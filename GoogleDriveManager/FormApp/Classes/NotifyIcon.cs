using System;
using System.Drawing;
using System.Windows.Forms;

namespace GoogleDriveManager
{
    class NotifyIcon : ApplicationContext
    {
        private System.Windows.Forms.NotifyIcon TrayIcon;

        public NotifyIcon(string title, string text)
        {
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
            InitializeComponent();
            TrayIcon.Visible = true;
            TrayIcon.ShowBalloonTip(10000, title, text, ToolTipIcon.Info);
            //Environment.Exit(0);
        }


        private void InitializeComponent()
        {
            TrayIcon = new System.Windows.Forms.NotifyIcon();
            
            TrayIcon.Text = "Google Drive Uploader Notifications";
            
            TrayIcon.Icon = Properties.Resources.TrayIcon;
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            //Cleanup so that the icon will be removed when the application is closed
            TrayIcon.Visible = false;
        }
    }
}
