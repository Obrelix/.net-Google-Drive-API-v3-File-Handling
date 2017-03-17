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
            this.ofgFileToUpload = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.button_browse = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtConnect = new System.Windows.Forms.TextBox();
            this.pnlDragAndDrop = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDirToUpload = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlConnection = new System.Windows.Forms.Panel();
            this.chbAddUser = new System.Windows.Forms.CheckBox();
            this.pnlUser = new System.Windows.Forms.Panel();
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
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRemUser = new System.Windows.Forms.Button();
            this.pnlDragAndDrop.SuspendLayout();
            this.pnlConnection.SuspendLayout();
            this.pnlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilesFromDrive)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "File name";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(4, 119);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(260, 20);
            this.txtFileName.TabIndex = 11;
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnUpload.Location = new System.Drawing.Point(83, 145);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(113, 55);
            this.btnUpload.TabIndex = 10;
            this.btnUpload.Text = "Upload File to Google Drive";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // button_browse
            // 
            this.button_browse.Location = new System.Drawing.Point(93, 7);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(88, 23);
            this.button_browse.TabIndex = 9;
            this.button_browse.Text = "Browse";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(3, 80);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(261, 20);
            this.txtFilePath.TabIndex = 8;
            this.txtFilePath.TextChanged += new System.EventHandler(this.textBox_path_TextChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnConnect.Location = new System.Drawing.Point(4, 222);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(106, 51);
            this.btnConnect.TabIndex = 15;
            this.btnConnect.Text = "Connect to drive";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtConnect
            // 
            this.txtConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtConnect.Location = new System.Drawing.Point(116, 222);
            this.txtConnect.MinimumSize = new System.Drawing.Size(147, 51);
            this.txtConnect.Name = "txtConnect";
            this.txtConnect.ReadOnly = true;
            this.txtConnect.Size = new System.Drawing.Size(147, 51);
            this.txtConnect.TabIndex = 16;
            this.txtConnect.Text = "Disconnected";
            this.txtConnect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlDragAndDrop
            // 
            this.pnlDragAndDrop.AllowDrop = true;
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
            this.pnlDragAndDrop.Location = new System.Drawing.Point(7, 335);
            this.pnlDragAndDrop.Name = "pnlDragAndDrop";
            this.pnlDragAndDrop.Size = new System.Drawing.Size(271, 209);
            this.pnlDragAndDrop.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Select a Folder:";
            // 
            // btnDirToUpload
            // 
            this.btnDirToUpload.Location = new System.Drawing.Point(93, 36);
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
            this.label4.Location = new System.Drawing.Point(4, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "File path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Select a File : ";
            // 
            // pnlConnection
            // 
            this.pnlConnection.AllowDrop = true;
            this.pnlConnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConnection.Controls.Add(this.chbAddUser);
            this.pnlConnection.Controls.Add(this.pnlUser);
            this.pnlConnection.Controls.Add(this.label11);
            this.pnlConnection.Controls.Add(this.cbUser);
            this.pnlConnection.Controls.Add(this.btnConnect);
            this.pnlConnection.Controls.Add(this.txtConnect);
            this.pnlConnection.Location = new System.Drawing.Point(7, 32);
            this.pnlConnection.Name = "pnlConnection";
            this.pnlConnection.Size = new System.Drawing.Size(271, 279);
            this.pnlConnection.TabIndex = 18;
            this.pnlConnection.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlConnection_DragDrop);
            this.pnlConnection.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlConnection_DragDragEnter);
            // 
            // chbAddUser
            // 
            this.chbAddUser.AutoSize = true;
            this.chbAddUser.Location = new System.Drawing.Point(193, 14);
            this.chbAddUser.Name = "chbAddUser";
            this.chbAddUser.Size = new System.Drawing.Size(70, 17);
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
            this.pnlUser.Size = new System.Drawing.Size(266, 178);
            this.pnlUser.TabIndex = 23;
            this.pnlUser.Visible = false;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(3, 21);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(260, 20);
            this.txtUserName.TabIndex = 18;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(186, 151);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(77, 23);
            this.btnAddUser.TabIndex = 22;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // txtAppName
            // 
            this.txtAppName.Location = new System.Drawing.Point(4, 125);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(260, 20);
            this.txtAppName.TabIndex = 13;
            // 
            // btnJsonBroswe
            // 
            this.btnJsonBroswe.Location = new System.Drawing.Point(186, 47);
            this.btnJsonBroswe.Name = "btnJsonBroswe";
            this.btnJsonBroswe.Size = new System.Drawing.Size(77, 23);
            this.btnJsonBroswe.TabIndex = 15;
            this.btnJsonBroswe.Text = "Browse";
            this.btnJsonBroswe.UseVisualStyleBackColor = true;
            this.btnJsonBroswe.Click += new System.EventHandler(this.btnJsonBroswe_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Application Name";
            // 
            // txtJsonPath
            // 
            this.txtJsonPath.Location = new System.Drawing.Point(4, 86);
            this.txtJsonPath.Name = "txtJsonPath";
            this.txtJsonPath.ReadOnly = true;
            this.txtJsonPath.Size = new System.Drawing.Size(259, 20);
            this.txtJsonPath.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Json File path";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Select client_secret.Json : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Select User";
            // 
            // cbUser
            // 
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Location = new System.Drawing.Point(72, 12);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(109, 21);
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
            this.label5.Location = new System.Drawing.Point(4, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Connect to Google Drive API";
            // 
            // lblPanel
            // 
            this.lblPanel.AutoSize = true;
            this.lblPanel.Location = new System.Drawing.Point(4, 326);
            this.lblPanel.Name = "lblPanel";
            this.lblPanel.Size = new System.Drawing.Size(142, 13);
            this.lblPanel.TabIndex = 19;
            this.lblPanel.Text = "Upload Files to Google Drive";
            // 
            // dgvFilesFromDrive
            // 
            this.dgvFilesFromDrive.AllowUserToAddRows = false;
            this.dgvFilesFromDrive.AllowUserToDeleteRows = false;
            this.dgvFilesFromDrive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFilesFromDrive.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvFilesFromDrive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilesFromDrive.Location = new System.Drawing.Point(295, 32);
            this.dgvFilesFromDrive.Name = "dgvFilesFromDrive";
            this.dgvFilesFromDrive.ReadOnly = true;
            this.dgvFilesFromDrive.Size = new System.Drawing.Size(632, 517);
            this.dgvFilesFromDrive.TabIndex = 20;
            this.dgvFilesFromDrive.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFilesFromDrive_CellDoubleClick);
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.Location = new System.Drawing.Point(852, 555);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 21;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Location = new System.Drawing.Point(295, 555);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 22;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnRemUser
            // 
            this.btnRemUser.Location = new System.Drawing.Point(4, 151);
            this.btnRemUser.Name = "btnRemUser";
            this.btnRemUser.Size = new System.Drawing.Size(77, 23);
            this.btnRemUser.TabIndex = 23;
            this.btnRemUser.Text = "Remove";
            this.btnRemUser.UseVisualStyleBackColor = true;
            this.btnRemUser.Click += new System.EventHandler(this.btnRemUser_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 597);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.dgvFilesFromDrive);
            this.Controls.Add(this.lblPanel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pnlConnection);
            this.Controls.Add(this.pnlDragAndDrop);
            this.Name = "frmMain";
            this.Text = "Google Drive Uploader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlDragAndDrop.ResumeLayout(false);
            this.pnlDragAndDrop.PerformLayout();
            this.pnlConnection.ResumeLayout(false);
            this.pnlConnection.PerformLayout();
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilesFromDrive)).EndInit();
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
        private System.Windows.Forms.TextBox txtConnect;
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
    }
}

