namespace GDUploaderForm
{
    partial class frmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ofgFileToUpload = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.button_browse = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.pnlDragAndDrop = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDirToUpload = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlConnection = new System.Windows.Forms.Panel();
            this.chbAddUser = new System.Windows.Forms.CheckBox();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.btnRemUser = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.btnJsonBroswe = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJsonPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbUser = new System.Windows.Forms.ComboBox();
            this.ofgJsonFile = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPanel = new System.Windows.Forms.Label();
            this.fbdDirToUpload = new System.Windows.Forms.FolderBrowserDialog();
            this.dgvFilesFromDrive = new System.Windows.Forms.DataGridView();
            this.fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileModifiedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Load = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_StartWithWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_About = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlDragAndDrop.SuspendLayout();
            this.pnlConnection.SuspendLayout();
            this.pnlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilesFromDrive)).BeginInit();
            this.menuMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.Location = new System.Drawing.Point(4, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "File name";
            // 
            // txtFileName
            // 
            this.txtFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtFileName.Location = new System.Drawing.Point(4, 119);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(271, 22);
            this.txtFileName.TabIndex = 11;
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnUpload.ForeColor = System.Drawing.Color.Transparent;
            this.btnUpload.Location = new System.Drawing.Point(4, 145);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(272, 40);
            this.btnUpload.TabIndex = 10;
            this.btnUpload.Text = "Upload to Drive";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // button_browse
            // 
            this.button_browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.button_browse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_browse.Location = new System.Drawing.Point(187, 8);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(88, 23);
            this.button_browse.TabIndex = 9;
            this.button_browse.Text = "Browse";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtFilePath.Location = new System.Drawing.Point(4, 80);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(271, 22);
            this.txtFilePath.TabIndex = 8;
            this.txtFilePath.TextChanged += new System.EventHandler(this.textBox_path_TextChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConnect.BackColor = System.Drawing.Color.Red;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnConnect.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConnect.Location = new System.Drawing.Point(3, 241);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(272, 40);
            this.btnConnect.TabIndex = 15;
            this.btnConnect.Text = "Connect to Drive";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // pnlDragAndDrop
            // 
            this.pnlDragAndDrop.AllowDrop = true;
            this.pnlDragAndDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlDragAndDrop.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pnlDragAndDrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDragAndDrop.Controls.Add(this.label9);
            this.pnlDragAndDrop.Controls.Add(this.btnDirToUpload);
            this.pnlDragAndDrop.Controls.Add(this.label4);
            this.pnlDragAndDrop.Controls.Add(this.label3);
            this.pnlDragAndDrop.Controls.Add(this.txtFilePath);
            this.pnlDragAndDrop.Controls.Add(this.button_browse);
            this.pnlDragAndDrop.Controls.Add(this.label1);
            this.pnlDragAndDrop.Controls.Add(this.btnUpload);
            this.pnlDragAndDrop.Controls.Add(this.txtFileName);
            this.pnlDragAndDrop.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlDragAndDrop.Location = new System.Drawing.Point(7, 361);
            this.pnlDragAndDrop.Name = "pnlDragAndDrop";
            this.pnlDragAndDrop.Size = new System.Drawing.Size(282, 193);
            this.pnlDragAndDrop.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label9.Location = new System.Drawing.Point(4, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Select a Folder:";
            // 
            // btnDirToUpload
            // 
            this.btnDirToUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnDirToUpload.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDirToUpload.Location = new System.Drawing.Point(187, 37);
            this.btnDirToUpload.Name = "btnDirToUpload";
            this.btnDirToUpload.Size = new System.Drawing.Size(88, 23);
            this.btnDirToUpload.TabIndex = 15;
            this.btnDirToUpload.Text = "Browse";
            this.btnDirToUpload.UseVisualStyleBackColor = true;
            this.btnDirToUpload.Click += new System.EventHandler(this.btnDirToUpload_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label4.Location = new System.Drawing.Point(4, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "File path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label3.Location = new System.Drawing.Point(4, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Select a File : ";
            // 
            // pnlConnection
            // 
            this.pnlConnection.AllowDrop = true;
            this.pnlConnection.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pnlConnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConnection.Controls.Add(this.chbAddUser);
            this.pnlConnection.Controls.Add(this.pnlUser);
            this.pnlConnection.Controls.Add(this.label11);
            this.pnlConnection.Controls.Add(this.cbUser);
            this.pnlConnection.Controls.Add(this.btnConnect);
            this.pnlConnection.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlConnection.Location = new System.Drawing.Point(7, 46);
            this.pnlConnection.Name = "pnlConnection";
            this.pnlConnection.Size = new System.Drawing.Size(282, 290);
            this.pnlConnection.TabIndex = 18;
            this.pnlConnection.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlConnection_DragDrop);
            this.pnlConnection.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlConnection_DragDragEnter);
            // 
            // chbAddUser
            // 
            this.chbAddUser.AutoSize = true;
            this.chbAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chbAddUser.Location = new System.Drawing.Point(193, 14);
            this.chbAddUser.Name = "chbAddUser";
            this.chbAddUser.Size = new System.Drawing.Size(84, 20);
            this.chbAddUser.TabIndex = 23;
            this.chbAddUser.Text = "Add User";
            this.chbAddUser.UseVisualStyleBackColor = true;
            this.chbAddUser.CheckedChanged += new System.EventHandler(this.chbAddUser_CheckedChanged);
            // 
            // pnlUser
            // 
            this.pnlUser.Controls.Add(this.btnRemUser);
            this.pnlUser.Controls.Add(this.txtUserName);
            this.pnlUser.Controls.Add(this.btnAddUser);
            this.pnlUser.Controls.Add(this.txtAppName);
            this.pnlUser.Controls.Add(this.btnJsonBroswe);
            this.pnlUser.Controls.Add(this.label10);
            this.pnlUser.Controls.Add(this.label2);
            this.pnlUser.Controls.Add(this.txtJsonPath);
            this.pnlUser.Controls.Add(this.label8);
            this.pnlUser.Controls.Add(this.label7);
            this.pnlUser.Location = new System.Drawing.Point(0, 38);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(277, 197);
            this.pnlUser.TabIndex = 23;
            this.pnlUser.Visible = false;
            // 
            // btnRemUser
            // 
            this.btnRemUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnRemUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRemUser.Location = new System.Drawing.Point(4, 168);
            this.btnRemUser.Name = "btnRemUser";
            this.btnRemUser.Size = new System.Drawing.Size(106, 25);
            this.btnRemUser.TabIndex = 23;
            this.btnRemUser.Text = "Remove User";
            this.btnRemUser.UseVisualStyleBackColor = true;
            this.btnRemUser.Click += new System.EventHandler(this.btnRemUser_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtUserName.Location = new System.Drawing.Point(3, 21);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(272, 22);
            this.txtUserName.TabIndex = 18;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnAddUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddUser.Location = new System.Drawing.Point(187, 168);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(88, 25);
            this.btnAddUser.TabIndex = 22;
            this.btnAddUser.Text = "Save User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // txtAppName
            // 
            this.txtAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtAppName.Location = new System.Drawing.Point(4, 139);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(271, 22);
            this.txtAppName.TabIndex = 13;
            // 
            // btnJsonBroswe
            // 
            this.btnJsonBroswe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnJsonBroswe.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnJsonBroswe.Location = new System.Drawing.Point(187, 48);
            this.btnJsonBroswe.Name = "btnJsonBroswe";
            this.btnJsonBroswe.Size = new System.Drawing.Size(88, 23);
            this.btnJsonBroswe.TabIndex = 15;
            this.btnJsonBroswe.Text = "Browse";
            this.btnJsonBroswe.UseVisualStyleBackColor = true;
            this.btnJsonBroswe.Click += new System.EventHandler(this.btnJsonBroswe_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label10.Location = new System.Drawing.Point(3, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.Location = new System.Drawing.Point(4, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Application Name";
            // 
            // txtJsonPath
            // 
            this.txtJsonPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtJsonPath.Location = new System.Drawing.Point(4, 94);
            this.txtJsonPath.Name = "txtJsonPath";
            this.txtJsonPath.ReadOnly = true;
            this.txtJsonPath.Size = new System.Drawing.Size(271, 22);
            this.txtJsonPath.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label8.Location = new System.Drawing.Point(4, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Json File path";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label7.Location = new System.Drawing.Point(2, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Select client_secret.Json : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label11.Location = new System.Drawing.Point(4, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 16);
            this.label11.TabIndex = 21;
            this.label11.Text = "Select User";
            // 
            // cbUser
            // 
            this.cbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Location = new System.Drawing.Point(83, 12);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(104, 24);
            this.cbUser.TabIndex = 20;
            this.cbUser.SelectedIndexChanged += new System.EventHandler(this.cbUser_SelectedIndexChanged);
            // 
            // ofgJsonFile
            // 
            this.ofgJsonFile.Tag = ".Json";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label5.Location = new System.Drawing.Point(4, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Connect to Google Drive API";
            // 
            // lblPanel
            // 
            this.lblPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPanel.AutoSize = true;
            this.lblPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblPanel.Location = new System.Drawing.Point(4, 352);
            this.lblPanel.Name = "lblPanel";
            this.lblPanel.Size = new System.Drawing.Size(268, 16);
            this.lblPanel.TabIndex = 19;
            this.lblPanel.Text = "Upload Files/Folders to Google Drive";
            // 
            // dgvFilesFromDrive
            // 
            this.dgvFilesFromDrive.AllowUserToAddRows = false;
            this.dgvFilesFromDrive.AllowUserToDeleteRows = false;
            this.dgvFilesFromDrive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFilesFromDrive.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.dgvFilesFromDrive.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFilesFromDrive.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFilesFromDrive.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFilesFromDrive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilesFromDrive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileName,
            this.fileSize,
            this.ID,
            this.fileModifiedTime,
            this.fileType});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFilesFromDrive.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFilesFromDrive.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvFilesFromDrive.Location = new System.Drawing.Point(295, 46);
            this.dgvFilesFromDrive.Name = "dgvFilesFromDrive";
            this.dgvFilesFromDrive.ReadOnly = true;
            this.dgvFilesFromDrive.Size = new System.Drawing.Size(705, 612);
            this.dgvFilesFromDrive.TabIndex = 20;
            this.dgvFilesFromDrive.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFilesFromDrive_CellClick);
            this.dgvFilesFromDrive.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFilesFromDrive_CellDoubleClick);
            // 
            // fileName
            // 
            this.fileName.Frozen = true;
            this.fileName.HeaderText = "Name";
            this.fileName.Name = "fileName";
            this.fileName.ReadOnly = true;
            this.fileName.Width = 300;
            // 
            // fileSize
            // 
            this.fileSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fileSize.HeaderText = "Size";
            this.fileSize.MinimumWidth = 90;
            this.fileSize.Name = "fileSize";
            this.fileSize.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 139;
            // 
            // fileModifiedTime
            // 
            this.fileModifiedTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fileModifiedTime.HeaderText = "Last Modified";
            this.fileModifiedTime.MinimumWidth = 170;
            this.fileModifiedTime.Name = "fileModifiedTime";
            this.fileModifiedTime.ReadOnly = true;
            // 
            // fileType
            // 
            this.fileType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fileType.HeaderText = "Type";
            this.fileType.MinimumWidth = 300;
            this.fileType.Name = "fileType";
            this.fileType.ReadOnly = true;
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnDownload.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDownload.Location = new System.Drawing.Point(6, 6);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(272, 40);
            this.btnDownload.TabIndex = 21;
            this.btnDownload.Text = "Download File";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnRemove.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRemove.Location = new System.Drawing.Point(7, 52);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(272, 40);
            this.btnRemove.TabIndex = 22;
            this.btnRemove.Text = "Remove File";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // menuMain
            // 
            this.menuMain.BackColor = System.Drawing.Color.DarkSlateGray;
            this.menuMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1012, 25);
            this.menuMain.TabIndex = 30;
            this.menuMain.Text = "Menu";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_Load,
            this.mnu_StartWithWindows,
            this.minimizeToTrayToolStripMenuItem});
            this.menuToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(53, 21);
            this.menuToolStripMenuItem.Text = "&Menu";
            // 
            // mnu_Load
            // 
            this.mnu_Load.Name = "mnu_Load";
            this.mnu_Load.Size = new System.Drawing.Size(193, 22);
            this.mnu_Load.Text = "&Load BackUp Profile";
            // 
            // mnu_StartWithWindows
            // 
            this.mnu_StartWithWindows.Checked = true;
            this.mnu_StartWithWindows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnu_StartWithWindows.Name = "mnu_StartWithWindows";
            this.mnu_StartWithWindows.Size = new System.Drawing.Size(193, 22);
            this.mnu_StartWithWindows.Text = "Start with Windows";
            // 
            // minimizeToTrayToolStripMenuItem
            // 
            this.minimizeToTrayToolStripMenuItem.Name = "minimizeToTrayToolStripMenuItem";
            this.minimizeToTrayToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.minimizeToTrayToolStripMenuItem.Text = "Minimize to Tray";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_About,
            this.helpToolStripMenuItem});
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.aboutToolStripMenuItem.Text = "&Help";
            // 
            // mnu_About
            // 
            this.mnu_About.Name = "mnu_About";
            this.mnu_About.Size = new System.Drawing.Size(152, 22);
            this.mnu_About.Text = "A&bout";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.btnDownload);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Location = new System.Drawing.Point(7, 560);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 98);
            this.panel1.TabIndex = 31;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(1012, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuMain);
            this.Controls.Add(this.dgvFilesFromDrive);
            this.Controls.Add(this.lblPanel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pnlConnection);
            this.Controls.Add(this.pnlDragAndDrop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Google Drive Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlDragAndDrop.ResumeLayout(false);
            this.pnlDragAndDrop.PerformLayout();
            this.pnlConnection.ResumeLayout(false);
            this.pnlConnection.PerformLayout();
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilesFromDrive)).EndInit();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofgFileToUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Panel pnlDragAndDrop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlConnection;
        private System.Windows.Forms.TextBox txtJsonPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnJsonBroswe;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.OpenFileDialog ofgJsonFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDirToUpload;
        private System.Windows.Forms.FolderBrowserDialog fbdDirToUpload;
        private System.Windows.Forms.DataGridView dgvFilesFromDrive;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.CheckBox chbAddUser;
        private System.Windows.Forms.Button btnRemUser;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnu_Load;
        private System.Windows.Forms.ToolStripMenuItem mnu_StartWithWindows;
        private System.Windows.Forms.ToolStripMenuItem minimizeToTrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnu_About;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileModifiedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileType;
        private System.Windows.Forms.Panel panel1;
    }
}

