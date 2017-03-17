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
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtJsonPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnJsonBroswe = new System.Windows.Forms.Button();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.ofgJsonFile = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fbdDirToUpload = new System.Windows.Forms.FolderBrowserDialog();
            this.dgvFilesFromDrive = new System.Windows.Forms.DataGridView();
            this.btnDownload = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlDragAndDrop.SuspendLayout();
            this.pnlConnection.SuspendLayout();
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
            this.btnConnect.Location = new System.Drawing.Point(5, 131);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(106, 23);
            this.btnConnect.TabIndex = 15;
            this.btnConnect.Text = "Connect to drive";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtConnect
            // 
            this.txtConnect.Location = new System.Drawing.Point(117, 131);
            this.txtConnect.Name = "txtConnect";
            this.txtConnect.ReadOnly = true;
            this.txtConnect.Size = new System.Drawing.Size(147, 20);
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
            this.pnlDragAndDrop.Location = new System.Drawing.Point(7, 232);
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
            this.pnlConnection.Controls.Add(this.label8);
            this.pnlConnection.Controls.Add(this.label7);
            this.pnlConnection.Controls.Add(this.txtJsonPath);
            this.pnlConnection.Controls.Add(this.label2);
            this.pnlConnection.Controls.Add(this.btnJsonBroswe);
            this.pnlConnection.Controls.Add(this.btnConnect);
            this.pnlConnection.Controls.Add(this.txtAppName);
            this.pnlConnection.Controls.Add(this.txtConnect);
            this.pnlConnection.Location = new System.Drawing.Point(7, 32);
            this.pnlConnection.Name = "pnlConnection";
            this.pnlConnection.Size = new System.Drawing.Size(271, 179);
            this.pnlConnection.TabIndex = 18;
            this.pnlConnection.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlConnection_DragDrop);
            this.pnlConnection.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlConnection_DragDragEnter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Json File path";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Select client_secret.Json : ";
            // 
            // txtJsonPath
            // 
            this.txtJsonPath.Location = new System.Drawing.Point(5, 54);
            this.txtJsonPath.Name = "txtJsonPath";
            this.txtJsonPath.ReadOnly = true;
            this.txtJsonPath.Size = new System.Drawing.Size(259, 20);
            this.txtJsonPath.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Application Name";
            // 
            // btnJsonBroswe
            // 
            this.btnJsonBroswe.Location = new System.Drawing.Point(171, 15);
            this.btnJsonBroswe.Name = "btnJsonBroswe";
            this.btnJsonBroswe.Size = new System.Drawing.Size(93, 23);
            this.btnJsonBroswe.TabIndex = 15;
            this.btnJsonBroswe.Text = "Browse";
            this.btnJsonBroswe.UseVisualStyleBackColor = true;
            this.btnJsonBroswe.Click += new System.EventHandler(this.btnJsonBroswe_Click);
            // 
            // txtAppName
            // 
            this.txtAppName.Location = new System.Drawing.Point(5, 93);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(260, 20);
            this.txtAppName.TabIndex = 13;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Upload Files to Google Drive";
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
            this.dgvFilesFromDrive.Size = new System.Drawing.Size(517, 368);
            this.dgvFilesFromDrive.TabIndex = 20;
            this.dgvFilesFromDrive.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFilesFromDrive_CellDoubleClick);
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.Location = new System.Drawing.Point(737, 406);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 21;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(295, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 448);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.dgvFilesFromDrive);
            this.Controls.Add(this.label6);
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDirToUpload;
        private System.Windows.Forms.FolderBrowserDialog fbdDirToUpload;
        private System.Windows.Forms.DataGridView dgvFilesFromDrive;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button button1;
    }
}

