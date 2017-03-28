namespace GoogleDriveManager
{
    partial class frmCalendar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalendar));
            this.dgvCalendar = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.cbUser = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.summary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.when = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCalendar
            // 
            this.dgvCalendar.AllowUserToAddRows = false;
            this.dgvCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCalendar.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCalendar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalendar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.summary,
            this.when,
            this.updated,
            this.status,
            this.id});
            this.dgvCalendar.Location = new System.Drawing.Point(41, 62);
            this.dgvCalendar.Name = "dgvCalendar";
            this.dgvCalendar.Size = new System.Drawing.Size(541, 308);
            this.dgvCalendar.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label11.Location = new System.Drawing.Point(38, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 16);
            this.label11.TabIndex = 23;
            this.label11.Text = "Select User";
            // 
            // cbUser
            // 
            this.cbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Location = new System.Drawing.Point(117, 19);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(104, 24);
            this.cbUser.TabIndex = 22;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(227, 19);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 24);
            this.btnConnect.TabIndex = 24;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // summary
            // 
            this.summary.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.summary.DataPropertyName = "summary";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.summary.DefaultCellStyle = dataGridViewCellStyle2;
            this.summary.HeaderText = "Summary";
            this.summary.Name = "summary";
            // 
            // when
            // 
            this.when.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.when.DataPropertyName = "when";
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.when.DefaultCellStyle = dataGridViewCellStyle3;
            this.when.HeaderText = "Date";
            this.when.Name = "when";
            // 
            // updated
            // 
            this.updated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.updated.DataPropertyName = "updatedRaw";
            this.updated.HeaderText = "Updated";
            this.updated.Name = "updated";
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            // 
            // frmCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(627, 426);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbUser);
            this.Controls.Add(this.dgvCalendar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCalendar";
            this.Text = "frmCalendar";
            this.Load += new System.EventHandler(this.frmCalendar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCalendar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbUser;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.DataGridViewTextBoxColumn summary;
        private System.Windows.Forms.DataGridViewTextBoxColumn when;
        private System.Windows.Forms.DataGridViewTextBoxColumn updated;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}