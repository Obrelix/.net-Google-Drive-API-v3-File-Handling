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

using System.Windows.Forms;
using Newtonsoft.Json;

namespace GoogleDriveManager
{
    public partial class frmMain : Form
    {
        public static List<User> UserList = new List<User>();
        static string savePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BackUpManager";
        static string saveFile = savePath + "\\GDASaves.json";
        static string appName = ".Net Client";

        public frmMain()
        {
            InitializeComponent();
            pnlDragAndDrop.AllowDrop = true;
            pnlDragAndDrop.DragEnter += new DragEventHandler(pnlDragAndDrop_DragEnter);
            pnlDragAndDrop.DragDrop += new DragEventHandler(pnlDragAndDrop_DragDrop);
        }

        private void dataGridViewInit()
        {
            //dgvFilesFromDrive.ColumnCount = 3;
            //dgvFilesFromDrive.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvFilesFromDrive.Columns[0].Name = "Name";
            //dgvFilesFromDrive.Columns[1].Name = "Type";
            //dgvFilesFromDrive.Columns[2].Name = "ID";
           // dgvFilesFromDrive.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewInit();
            loadUsers(savePath, saveFile);
            UIinit();
            cbUserInit();


        }

        private void updateDataGridView()
        {
            dgvFilesFromDrive.Rows.Clear();
            foreach(string[] array in GoogleDriveAPIV3.updateDriveFiles())
            {
                dgvFilesFromDrive.Rows.Add(array);
            }
        }

        private void UIinit()
        {
            if (chbAddUser.Checked)
            {
                pnlConnection.Height = 290;
                pnlUser.Visible = true;
                this.Height = 720;

            }
            else
            {
                pnlConnection.Height = 100;
                pnlUser.Visible = false;
                this.Height =  530;
            }
        }

        private void loadUsers(string savePath, string saveFile)
        {
            Directory.CreateDirectory(savePath);
            try
            {
                if (System.IO.File.Exists(saveFile))
                {
                    UserList.Clear();
                    UserList = JsonConvert.DeserializeObject<List<User>>(System.IO.File.ReadAllText(saveFile));
                  

                }
                else
                {
                    using (System.IO.FileStream fs = System.IO.File.Create(saveFile))
                    {
                        for (byte i = 0; i < 100; i++)
                        {
                            fs.WriteByte(i);
                        }
                    }

                    System.IO.File.WriteAllText(saveFile, "[ ]");
                    loadUsers(savePath, saveFile);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                
            }
        }

        private void saveUsers(string saveFile)
        {
            try
            {
                string contentsToWriteToFile = JsonConvert.SerializeObject(UserList.ToArray(), Newtonsoft.Json.Formatting.Indented);

                System.IO.File.WriteAllText(saveFile, contentsToWriteToFile);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

            }
        }

        private void pnlDragAndDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void pnlDragAndDrop_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                txtFilePath.Text = file;
                System.Diagnostics.Debug.WriteLine("File: {0}", file);
            } 
        }

        private void pnlConnection_DragDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void pnlConnection_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                txtJsonPath.Text = file;
                System.Diagnostics.Debug.WriteLine("File: {0}", file);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(txtJsonPath.Text == string.Empty)
            {
                MessageBox.Show("You have to:" + Environment.NewLine +
                    "A) Select the client_secret.Json file "+ Environment.NewLine +
                    "B) Type your OAuth 2.0 client ID in Application Name TextBox"+ Environment.NewLine +
                    "in order to begining connection with your Google Drive");
            }
            else
            {
                if (GoogleDriveAPIV3.GoogleDriveConnection(txtJsonPath.Text, appName, txtUserName.Text))
                {
                    btnConnect.BackColor = Color.Green;
                    
                    updateDataGridView();
                }
                else
                {
                    btnConnect.BackColor = Color.Red;
                }

            }
            
        }

        private void textBox_path_TextChanged(object sender, EventArgs e)
        {
            txtFileName.Text = Path.GetFileName(txtFilePath.Text);
        }

        private void btnDirToUpload_Click(object sender, EventArgs e)
        {
            DialogResult result = fbdDirToUpload.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    txtFilePath.Text = fbdDirToUpload.SelectedPath;
                    break;
                default:
                    break;
            }
        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            DialogResult result = ofgFileToUpload.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    txtFilePath.Text = ofgFileToUpload.FileName;
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
                case DialogResult.OK:
                    txtJsonPath.Text = ofgJsonFile.FileName;
                    break;
                default:
                    break;
            }
        }
        private void downloadFile(string fileName, string fileID)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    txtJsonPath.Text = ofgJsonFile.FileName;
                    GoogleDriveAPIV3.downloadFromDrive(fileName, fileID, fbd.SelectedPath);
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
            if(!GoogleDriveAPIV3.GoogleDriveConnection(txtJsonPath.Text, appName, txtUserName.Text))
            {
                MessageBox.Show("You have to Connect First in order to upload Files");
            }
            else
            {
                GoogleDriveAPIV3.uploadToDrive(filePath, fileName, null);
                updateDataGridView();
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string fileName, fileId;
            if (dgvFilesFromDrive.SelectedRows.Count <= 0)
            {
                MessageBox.Show("You have to select a row  in order to download");

            }
            else
            {
                foreach (DataGridViewRow row in dgvFilesFromDrive.SelectedRows)
                {
                    fileName = dgvFilesFromDrive.Rows[row.Index].Cells[0].Value.ToString();
                    fileId = dgvFilesFromDrive.Rows[row.Index].Cells[2].Value.ToString();
                    downloadFile(fileName, fileId);
                }
            }
        }

        private void dgvFilesFromDrive_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string fileID = dgvFilesFromDrive.Rows[e.RowIndex].Cells[2].Value.ToString();
            string fileName = dgvFilesFromDrive.Rows[e.RowIndex].Cells[0].Value.ToString();
            downloadFile(fileName, fileID);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string  fileId, fileName;
            if (dgvFilesFromDrive.SelectedRows.Count <= 0)
            {
                MessageBox.Show("You have to select a row  in order to download");

            }
            else
            {
                foreach (DataGridViewRow row in dgvFilesFromDrive.SelectedRows)
                {
                    fileName = dgvFilesFromDrive.Rows[row.Index].Cells[0].Value.ToString();
                    fileId = dgvFilesFromDrive.Rows[row.Index].Cells[2].Value.ToString();
                    DialogResult result = MessageBox.Show("Do you want to delete the File: " + fileName, "Confirm",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            GoogleDriveAPIV3.removeFile(fileId);
                            updateDataGridView();
                            break;
                        default:
                            updateDataGridView();
                            break;
                    }
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserList.Add(new User(txtUserName.Text, txtJsonPath.Text, appName));
            saveUsers(saveFile);
            cbUserInit();
        }

        private void cbUserInit()
        {
            cbUser.DataSource = null;
            cbUser.Items.Clear();
            cbUser.DataSource = UserList;
            cbUser.DisplayMember = "userName";
            cbUser.ValueMember = "userName";
            cbUser.SelectedIndex = -1;
            cbUser.Text = "Select User...";
        }

        private void chbAddUser_CheckedChanged(object sender, EventArgs e)
        {
            UIinit();
        }

        private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtInit(cbUser.SelectedIndex);
        }

        private void txtInit(int i)
        {
            if (i >= 0)
            {
                txtUserName.Text = UserList[i].userName;
                txtJsonPath.Text = UserList[i].clientSecretPath;
            }
            else
            {
                txtUserName.Text = "";
                txtJsonPath.Text = "";
            }
        }

        private void btnRemUser_Click(object sender, EventArgs e)
        {
            if(cbUser.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Do you want to delete User: " + 
                        UserList[cbUser.SelectedIndex].userName, "Confirm",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        UserList.Remove(UserList[cbUser.SelectedIndex]);
                        saveUsers(saveFile);
                        cbUserInit();
                        break;
                    default:
                        break;
                }
                
            }
        }

        private void dgvFilesFromDrive_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) dgvFilesFromDrive.Rows[e.RowIndex].Selected = true ;
        }
    }
}
