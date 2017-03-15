using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GDUploaderForm;

using System.Windows.Forms;

namespace GDUploaderForm
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
            pnlDragAndDrop.AllowDrop = true;
            pnlDragAndDrop.DragEnter += new DragEventHandler(pnlDragAndDrop_DragEnter);
            pnlDragAndDrop.DragDrop += new DragEventHandler(pnlDragAndDrop_DragDrop);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            txtConnect.BackColor = Color.Red;
            txtConnect.Text = "Disconnected";
            txtAppName.Text = "Google Drive Uploader";
        }

        void pnlDragAndDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void pnlDragAndDrop_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                txtFilePath.Text = file;
                System.Diagnostics.Debug.WriteLine("File: {0}", file);
            } 
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(txtJsonPath.Text == string.Empty)
            {
                MessageBox.Show("You have to:" + Environment.NewLine +
                    "A) Select the client_secret.Json file "+ Environment.NewLine+
                    "B) Type your OAuth 2.0 client ID in Application Name TextBox"+Environment.NewLine+
                    "in order to begining connection with your Google Drive");
            }
            else
            {
                if (GoogleDriveAPIV3.GoogleDriveConnection(txtJsonPath.Text, txtAppName.Text))
                {
                    txtConnect.BackColor = Color.Green;
                    txtConnect.Text = "Connected";
                }
                else
                {
                    txtConnect.BackColor = Color.Red;
                    txtConnect.Text = "Disconnected";
                }

            }
            
        }

        private void textBox_path_TextChanged(object sender, EventArgs e)
        {
            txtFileName.Text = Path.GetFileName(txtFilePath.Text);
        }


        private void button_browse_Click(object sender, EventArgs e)
        {
            DialogResult result = ofgFileToUpload.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    txtFilePath.Text = ofgFileToUpload.FileName;
                    //textBox_fileName.Text = ofgFileToUpload.SafeFileName;
                    break;
                default:
                    break;
            }
        }


        private void btnJsonBroswe_Click(object sender, EventArgs e)
        {
            DialogResult result = ofgJsonFile.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    txtJsonPath.Text = ofgJsonFile.FileName;
                    break;
                default:
                    break;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(txtFilePath.Text);
            string filePath = txtFilePath.Text;
            string fileName = txtFileName.Text;
            string fileType = GetFileType(filePath);
            if(txtConnect.Text == "Disconnected")
            {
                MessageBox.Show("You have to Connect First in order to upload Files");
            }
            else
            {
                GoogleDriveAPIV3.uploadToDrive(fileName, filePath, fileType);
            }
            
            
        }

        private String GetFileType(string file)
        {
            string extension = Path.GetExtension(file);
            System.Diagnostics.Debug.WriteLine("extension: " + extension);
            string mime;
            switch (extension.ToLower())
            {
                case ".jpg":
                    mime = "image/jpeg";
                    break;
                case ".jpeg":
                    mime = "image/jpeg";
                    break;
                case ".png":
                    mime = "image/png";
                    break;
                case ".doc":
                    mime = "application/msword";
                    break;
                case ".pdf":
                    mime = "application/pdf";
                    break;
                default:
                    mime = "text/plain";
                    break;
            }
            return mime;
        }

        
    }
}
