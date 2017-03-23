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

using Ionic.Zip;

using System.Windows.Forms;
using Newtonsoft.Json;

namespace GoogleDriveManager
{
    public partial class frmMain : Form
    {
        public static List<User> UserList = new List<User>();
        static List<ListId> cbList = new List<ListId>();
        static string savePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BackUpManager";
        static string saveFile = savePath + "\\GDASaves.json";

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

        private void cbTypeInit()
        {
            cbList.Add(new ListId("All", null));
            cbList.Add(new ListId("folder", "application/vnd.google-apps.folder"));
            cbList.Add(new ListId("document", "application/vnd.google-apps.document"));
            cbList.Add(new ListId("msword", "application/msword"));
            cbList.Add(new ListId("spreadsheet", "application/vnd.google-apps.spreadsheet"));
            cbList.Add(new ListId("pdf", "application/pdf"));
            cbList.Add(new ListId("video", "video/"));
            cbList.Add(new ListId("image", "image/"));
            cbList.Add(new ListId("music", "audio/"));
            cbList.Add(new ListId("html", "application/vnd.jgraph.mxfile.realtime"));
            cbList.Add(new ListId("text", "text/"));
            cbList.Add(new ListId("epub", "application/epub+zip"));
            cbList.Add(new ListId("zip", "application/zip"));
            cbList.Add(new ListId("ZIP", "application/x-zip-compressed"));
            cbList.Add(new ListId("rar", "application/x-rar"));
            cbList.Add(new ListId("code", "application/octet-stream"));
            cbList.Add(new ListId("bat", "application/x-msdos-program"));
            cbList.Add(new ListId("exe", "application/x-dosexec"));
            cbList.Add(new ListId("unknown", "document/unknown"));

            cbFileType.DataSource = null;
            cbFileType.Items.Clear();
            cbFileType.DataSource = cbList;
            cbFileType.DisplayMember = "name";
            cbFileType.ValueMember = "type";
            cbFileType.SelectedIndex = 0;
            cbFileType.Text = "Select Type...";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewInit();
            loadUsers(savePath, saveFile);
            UIinit();
            cbUserInit();
            cbTypeInit();
            txtJsonPath.Text = "Resources\\client_secret.json" ;
            //Properties.Resources.client_secret
        }

        private void updateDataGridView()
        {
            dgvFilesFromDrive.Rows.Clear();
            foreach(string[] array in GoogleDriveAPIV3.listDriveFiles())
            {
                dgvFilesFromDrive.Rows.Add(array);
            }
        }

        private void updateDataGridView(string name, string type)
        {
            dgvFilesFromDrive.Rows.Clear();
            foreach (string[] array in GoogleDriveAPIV3.listDriveFiles(name, type))
            {
                dgvFilesFromDrive.Rows.Add(array);
            }
        }

        private void UIinit()
        {
            if (chbAddUser.Checked)
            {
                this.MinimumSize = new Size(900, 660);
                pnlConnection.Height = 290;
                pnlUser.Visible = true;
                this.Height = 660;
            }
            else
            {
                this.MinimumSize = new Size(900, 470);
                pnlConnection.Height = 100;
                pnlUser.Visible = false;
                this.Height =  470;
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
                    Gtools.createFile(saveFile, "[ ]");
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
            if(cbUser.SelectedIndex == -1)
            {
                MessageBox.Show("You have to:" + Environment.NewLine +
                    "Select A User in order to connect", "Attention!!",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (GoogleDriveAPIV3.GoogleDriveConnection(
                    UserList[cbUser.SelectedIndex].clientSecretPath, 
                    UserList[cbUser.SelectedIndex].userName))
                {
                    btnConnect.BackColor = Color.Green;
                    
                    updateDataGridView();
                }
                else
                {
                    btnConnect.BackColor = Color.Red;
                    MessageBox.Show("Connection Error", "Attention!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            
        }

        private void textBox_path_TextChanged(object sender, EventArgs e)
        {
            txtFileName.Text = Path.GetFileName(txtFilePath.Text);
            lblMd5Checksum.Text = Gtools.md5ChecksumGenerator(txtFilePath.Text);
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
        private void downloadFile(string fileName, string fileID, string mimeType)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    txtJsonPath.Text = ofgJsonFile.FileName;
                    GoogleDriveAPIV3.downloadFromDrive(fileName, fileID, fbd.SelectedPath, mimeType);
                    break;
                default:
                    break;
            }
        }

        

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string filePath = (chbCompress.Checked) ? Gtools.compressFile(txtFilePath.Text) : txtFilePath.Text;
            string fileName = (chbCompress.Checked) ? txtFileName.Text.Split('.').First() + ".zip" : txtFileName.Text;
            string parentID = (txtParentID.Text != string.Empty) ? txtParentID.Text : null;
            if (!GoogleDriveAPIV3.GoogleDriveConnection(
                UserList[cbUser.SelectedIndex].clientSecretPath,
                UserList[cbUser.SelectedIndex].userName))
            {
                MessageBox.Show("You have to Connect First in order to upload Files");
            }
            else
            {
                if (Gtools.compareHash(lblMd5Checksum.Text))
                {
                    DialogResult result = MessageBox.Show("The file : \"" + fileName +
                        "\" \nAlready exists on Google Drive!! \nDo you want to uploaded anyway?", 
                        "File already exist on Google Drive",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            GoogleDriveAPIV3.uploadToDrive(filePath, fileName, parentID);
                            updateDataGridView();
                            break;
                        default:
                            updateDataGridView();
                            break;
                    }
                }
                else
                {
                    GoogleDriveAPIV3.uploadToDrive(filePath, fileName, parentID);
                    updateDataGridView();
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string fileName, fileId, mimeType;
            if (dgvFilesFromDrive.SelectedRows.Count <= 0)
            {
                MessageBox.Show("You have to select a row  in order to download");

            }
            else
            {
                foreach (DataGridViewRow row in dgvFilesFromDrive.SelectedRows)
                {
                    fileName = dgvFilesFromDrive.Rows[row.Index].Cells[0].Value.ToString();
                    mimeType = dgvFilesFromDrive.Rows[row.Index].Cells[3].Value.ToString();
                    fileId = dgvFilesFromDrive.Rows[row.Index].Cells[4].Value.ToString();
                    downloadFile(fileName, fileId, mimeType);
                }
            }
        }

        private void dgvFilesFromDrive_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string fileID = dgvFilesFromDrive.Rows[e.RowIndex].Cells[4].Value.ToString();
           // string fileName = dgvFilesFromDrive.Rows[e.RowIndex].Cells[0].Value.ToString();
            //string mimeType = dgvFilesFromDrive.Rows[e.RowIndex].Cells[3].Value.ToString();
            Clipboard.SetText(fileID);
            //downloadFile(fileName, fileID, mimeType);
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
                    fileId = dgvFilesFromDrive.Rows[row.Index].Cells[4].Value.ToString();
                    DialogResult result = MessageBox.Show("Do you want to delete the File: " + fileName, "Confirm",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            GoogleDriveAPIV3.removeFile(fileId);
                            break;
                        default:
                            break;
                    }
                }
                updateDataGridView();
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserList.Add(new User(txtUserName.Text, txtJsonPath.Text));
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
                        Gtools.deleteCredFile(savePath, UserList[cbUser.SelectedIndex].userName);
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

        private void btnCreateBatch_Click(object sender, EventArgs e)
        {

            int compressing = (chbCompress.Checked) ? 1 : 0;
            string contentToWrite = "cls" + Environment.NewLine +
                "@ECHO OFF" + Environment.NewLine +
                "set param1=\"" + cbUser.SelectedIndex + "\"" + Environment.NewLine +
                "set param2=\"" + txtFilePath.Text + "\"" + Environment.NewLine +
                "set param3=\"" + txtFileName.Text + "\"" + Environment.NewLine +
                "set param4=\"" + compressing + "\"" + Environment.NewLine;
            if (txtParentID.Text != string.Empty)
            {
                contentToWrite += "set param5=\"" + txtParentID.Text + "\"" + Environment.NewLine;
            }

            //string appPath ="\""+ Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) +
            //    "\\Obrelix\\Google Drive Manager\\GoogleDriveManager.exe\"";

            string appPath = "\"" + Path.GetFullPath(Application.ExecutablePath)+"\"";
            contentToWrite += appPath + " %param1% %param2% %param3% %param4%";

            if (txtParentID.Text != string.Empty)
            {
                contentToWrite += " %param5%";
            }

            if (cbUser.SelectedIndex != -1)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                DialogResult result = fbd.ShowDialog();
                switch (result)
                {
                    case DialogResult.OK:

                        Gtools.createFile( Path.Combine(fbd.SelectedPath,
                            UserList[cbUser.SelectedIndex].userName + "_File_" + txtFileName.Text.Split('.').First() + ".bat")
                            , contentToWrite);

                        break;
                    default:
                        break;
                }

            }
        }


        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            
            if(txtFileName.Text != "" && txtFilePath.Text != "")
            {
                btnCreateBatch.Enabled = true;
                btnUpload.Enabled = true;
                chbCompress.Enabled = true;
            }
            else
            {
                btnCreateBatch.Enabled = false;
                btnUpload.Enabled = false;
                chbCompress.Enabled = false;
            }

            if(cbUser.SelectedIndex >= 0)
            {
                btnConnect.Enabled = true;
            }
            else
            {
                btnConnect.Enabled = false;
            }

            if(dgvFilesFromDrive.SelectedRows.Count < 1)
            {
                btnDownload.Enabled = false;
                btnRemove.Enabled = false;
            }
            else
            {
                btnDownload.Enabled = true;
                btnRemove.Enabled = true;
            }
            if(txtJsonPath.Text != null && txtUserName.Text != null)
            {
                btnAddUser.Enabled = true;
            }
            else
            {
                btnAddUser.Enabled = false;
            }
            if(cbUser.SelectedIndex >= 0)
            {
                btnConnect.Enabled = true;
                btnRemUser.Enabled = true;
            }
            else
            {
                btnConnect.Enabled = false;
                btnRemUser.Enabled = false;
            }
            if (txtSearchFile.Text != string.Empty || cbFileType.SelectedIndex != 0) btnSearch.Enabled = true;
            else btnSearch.Enabled = false;
            if(txtCreateFolder.Text != string.Empty) btnCreate.Enabled = true;
            else btnCreate.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateDataGridView();
        }

        private void chbCompress_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            GoogleDriveAPIV3.createFolderToDrive(txtCreateFolder.Text, null);
            updateDataGridView();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            updateDataGridView(txtSearchFile.Text, cbList[cbFileType.SelectedIndex].type);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
        }

        
    }
}
