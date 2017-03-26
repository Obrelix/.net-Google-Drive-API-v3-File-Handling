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
using System.Data;

namespace GoogleDriveManager
{
    public partial class frmMain : Form
    {
        public static List<User> UserList = new List<User>();
        public List<IOFile> IOFileList = new List<IOFile>();
        static List<ListId> cbList = new List<ListId>();
        DataTable dtDriveFiles;
        static string savePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BackUpManager";
        static string saveFile = savePath + "\\GDASaves.json";
        public static string errorLog = savePath + "\\LogFile.log";

        public frmMain()
        {
            InitializeComponent();
            pnlDragAndDrop.AllowDrop = true;
            //pnlDragAndDrop.DragEnter += new DragEventHandler(pnlDragAndDrop_DragEnter);
            //pnlDragAndDrop.DragDrop += new DragEventHandler(pnlDragAndDrop_DragDrop);
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
            loadUsers(savePath, saveFile);
            UIinit();
            cbUserInit();
            cbTypeInit();
            txtJsonPath.Text = "Resources\\client_secret.json" ;
            //Properties.Resources.client_secret
            dtDriveFiles = new DataTable();
            dgvFilesFromDrive.DataSource = dtDriveFiles;
            createLogFile();
        }

        private void createLogFile()
        {
            if(!System.IO.File.Exists(errorLog))
                Gtools.createFile(errorLog, DateTime.Now.ToString() + Environment.NewLine + "Error Log file Created\n" + Environment.NewLine);
        }

        private void updateDataGridView(string name = null, string type = null)
        {
            dtDriveFiles = null;
            dtDriveFiles = Gtools.ToDataTable<GoogleDriveFile>(GoogleDriveAPIV3.listDriveFiles(name, type));
            dgvFilesFromDrive.DataSource = dtDriveFiles;
        }

        private void UIinit()
        {
            if (chbAddUser.Checked)
            {
                this.MinimumSize = new Size(900, 660);
                pnlConnection.Height = 290;
                pnlUser.Visible = true;
                pnlClient.Visible = true;
                this.Height = 660;
                lblPanel.Location = new Point(4, 351);
                pnlDragAndDrop.Location = new Point(7, 371);
                pnlDragAndDrop.Height -= 190;

            }
            else
            {
                this.MinimumSize = new Size(900, 470);
                pnlConnection.Height = 100;
                pnlUser.Visible = false;
                pnlClient.Visible = false;
                lblPanel.Location = new Point(4, 161);
                pnlDragAndDrop.Location = new Point(7, 181);
                pnlDragAndDrop.Height += 190;
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
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message + " Load User Error.\n");
                Gtools.writeToFile(frmMain.errorLog, Environment.NewLine + DateTime.Now.ToString() +
                    Environment.NewLine + exc.Message + " Load User Error.\n");

            }
        }

        private void saveUsers(string saveFile)
        {
            try
            {
                string contentsToWriteToFile = JsonConvert.SerializeObject(UserList.ToArray(), Newtonsoft.Json.Formatting.Indented);

                System.IO.File.WriteAllText(saveFile, contentsToWriteToFile);

            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message + " Save User Error.\n");
                Gtools.writeToFile(frmMain.errorLog, Environment.NewLine + DateTime.Now.ToString() +
                    Environment.NewLine + exc.Message + " Save User Error.\n");

            }
        }

        private void saveFileLIst(string saveFile)
        {
            try
            {
                string contentsToWriteToFile = JsonConvert.SerializeObject(IOFileList.ToArray(), Newtonsoft.Json.Formatting.Indented);

                System.IO.File.WriteAllText(saveFile, contentsToWriteToFile);

            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message + " Save User Error.\n");
                Gtools.writeToFile(frmMain.errorLog, Environment.NewLine + DateTime.Now.ToString() +
                    Environment.NewLine + exc.Message + " Save User Error.\n");

            }
        }

        private void pnlDragAndDrop_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = (e.Data.GetDataPresent(DataFormats.FileDrop)) ? DragDropEffects.All : DragDropEffects.None;
            //if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
            //if (e.Data.GetDataPresent(DataFormats.FileDrop))
            //    e.Effect = DragDropEffects.All;
            //else
            //    e.Effect = DragDropEffects.None;
        }

        private void pnlDragAndDrop_DragDrop(object sender, DragEventArgs e)
        {

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            
            foreach (string file in files)
            {
                if (chbUploadMultiple.Checked)
                {
                    lbFilesToUpload.Items.Add(file);
                    IOFileList.Add(new IOFile(file));
                }
                else
                {
                    txtFilePath.Text = file;
                    System.Diagnostics.Debug.WriteLine("File: {0}", file);
                    IOFileList.Add(new IOFile(file));
                }
            } 
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lbFilesToUpload.Items.Clear();
            IOFileList.Clear();
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
                MessageBox.Show("You have to Select A User in order to connect", "Attention!!",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            txtMd5.Text = Gtools.hashGenerator(txtFilePath.Text);
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
                    txtMd5.Text = Gtools.hashGenerator(ofgFileToUpload.FileName);
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
            string filePath, fileName;
            string parentID = (txtParentID.Text != string.Empty) ? txtParentID.Text : null;
               bool result;
            if (chbUploadMultiple.Checked)
            {
                result = (MessageBox.Show("Do you want to upload only new/changed files on Google Drive ?",
                       "Upload existing files?",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                lbFilesToUpload.BeginUpdate();
                try
                {
                    for (int i = lbFilesToUpload.Items.Count - 1; i >= 0; i--)
                    {
                       // lbFilesToUpload.Items[i].c
                        filePath = (chbCompress.Checked) ? Gtools.compressFile(lbFilesToUpload.Items[i].ToString()) : lbFilesToUpload.Items[i].ToString();
                        System.Diagnostics.Debug.WriteLine(filePath);
                        fileName = (chbCompress.Checked) ? Path.GetFileName(lbFilesToUpload.Items[i].ToString().Split('.').First()) + ".zip" : Path.GetFileName(lbFilesToUpload.Items[i].ToString());
                        GoogleDriveAPIV3.uploadToDrive(filePath, fileName, parentID, result);
                        string newName = "DONE!  " + lbFilesToUpload.Items[i].ToString();

                        lbFilesToUpload.Items.RemoveAt(i);
                        lbFilesToUpload.Items.Insert(i, newName);
                        updateDataGridView();
                        lbFilesToUpload.EndUpdate();
                    }
                }
                catch(Exception exc)
                {
                    System.Diagnostics.Debug.WriteLine(exc.Message);
                    lbFilesToUpload.EndUpdate();
                }
            }
            else
            {
                filePath = (chbCompress.Checked) ? Gtools.compressFile(txtFilePath.Text) : txtFilePath.Text;
                fileName = (chbCompress.Checked) ? txtFileName.Text.Split('.').First() + ".zip" : txtFileName.Text;
                if (GoogleDriveAPIV3.compareHash(Gtools.hashGenerator(filePath)))
                {
                    result = MessageBox.Show("The file : \"" + fileName +
                        "\" \nAlready exists on Google Drive!! \nDo you want to uploaded anyway?",
                        "File already exist on Google Drive",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                    
                            GoogleDriveAPIV3.uploadToDrive(filePath, fileName, parentID, !result);
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

            txtParentID.Text = dgvFilesFromDrive.Rows[e.RowIndex].Cells[4].Value.ToString();
           // string fileName = dgvFilesFromDrive.Rows[e.RowIndex].Cells[0].Value.ToString();
            //string mimeType = dgvFilesFromDrive.Rows[e.RowIndex].Cells[3].Value.ToString();
           // Clipboard.SetText(fileID);
            //downloadFile(fileName, fileID, mimeType);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string  fileId, fileName;
            DialogResult result = MessageBox.Show("Do you want to delete the " + dgvFilesFromDrive.SelectedRows.Count +" Selected Files?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    foreach (DataGridViewRow row in dgvFilesFromDrive.SelectedRows)
                    {
                        fileName = dgvFilesFromDrive.Rows[row.Index].Cells[0].Value.ToString();
                        fileId = dgvFilesFromDrive.Rows[row.Index].Cells[4].Value.ToString();
                        GoogleDriveAPIV3.removeFile(fileId);

                    }
                    break;
                default:
                    break;
            }
            
            updateDataGridView();
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
            string fileListName = Gtools.getTimeStamp() + "_" + UserList[cbUser.SelectedIndex].userName + "_" + txtBackUpName.Text + ".json";
            string fileListPath = Path.Combine(savePath, fileListName);
            saveFileLIst(fileListPath);
            string param1 = fileListPath;// filelist.json Path parameter
            string param2 = (chbUploadMultiple.Checked)? txtBackUpName.Text : txtFileName.Text;// file Name parameter
            string param3 = (txtParentID.Text != string.Empty) ? txtParentID.Text : "0";// Parent Id parameter
            int param4 = cbUser.SelectedIndex; // user index parameter
            int param5 = (MessageBox.Show("Do you want to Upload only \"new/changed\" files to Google Drive?" +
                        UserList[cbUser.SelectedIndex].userName, "Uploading Arguments",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ? 1 : 0;// Copy Only new parameter
            int param6 = (chbCompress.Checked) ? 1 : 0;// comporess parameter

            string appPath = "\"" + Path.GetFullPath(Application.ExecutablePath) + "\"";


            string contentToWrite = "cls" + Environment.NewLine +
                "@ECHO OFF" + Environment.NewLine +
                "set param1=\"" + param1 + "\"" + Environment.NewLine +
                "set param2=\"" + param2 + "\"" + Environment.NewLine +
                "set param3=\"" + param3 + "\"" + Environment.NewLine +
                "set param4=\"" + param4 + "\"" + Environment.NewLine +
                "set param5=\"" + param5 + "\"" + Environment.NewLine +
                "set param6=\"" + param6 + "\"" + Environment.NewLine +
                appPath + " %param1% %param2% %param3% %param4% %param5% %param6%";
            
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


        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            
            if((txtFileName.Text != "" && txtFilePath.Text != "")|| lbFilesToUpload.Items.Count > 0)
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

        private void chbUploadMultiple_CheckedChanged(object sender, EventArgs e)
        {
            pnlSF.Visible = !chbUploadMultiple.Checked;
            pnlListBox.Visible = chbUploadMultiple.Checked;
            txtBackUpName.Text = "Backup";
        }

        private void mnu_About_Click(object sender, EventArgs e)
        {
            frmAbout form = new frmAbout();
            form.Show();
        }

        private void mnuHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Obrelix/.net-Google-Drive-API-v3-File-Handling/issues");
        }
    }
}
