
namespace coffee_ticket
{
    partial class frmCoffeeTicket
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCoffeeTicket));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddSite = new System.Windows.Forms.Button();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateDownload = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateSetup = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dgvQuery = new System.Windows.Forms.DataGridView();
            this.cId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSite_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSite_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSite_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSite_ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSetup_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDownload_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.dateQueryEnd = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dateQueryStart = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.cbxQuerySite = new MultiColumnComboBoxDemo.MultiColumnComboBox();
            this.cbxSite = new MultiColumnComboBoxDemo.MultiColumnComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuery)).BeginInit();
            this.notifyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxSite);
            this.groupBox1.Controls.Add(this.btnAddSite);
            this.groupBox1.Controls.Add(this.txtMemo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateDownload);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateSetup);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbxType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新增下傳門市";
            // 
            // btnAddSite
            // 
            this.btnAddSite.Location = new System.Drawing.Point(633, 48);
            this.btnAddSite.Name = "btnAddSite";
            this.btnAddSite.Size = new System.Drawing.Size(133, 23);
            this.btnAddSite.TabIndex = 10;
            this.btnAddSite.Text = "更  新  門  市";
            this.btnAddSite.UseVisualStyleBackColor = true;
            this.btnAddSite.Click += new System.EventHandler(this.btnAddSite_Click);
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(80, 48);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(546, 23);
            this.txtMemo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "備        註：";
            // 
            // dateDownload
            // 
            this.dateDownload.Location = new System.Drawing.Point(632, 18);
            this.dateDownload.Name = "dateDownload";
            this.dateDownload.Size = new System.Drawing.Size(134, 23);
            this.dateDownload.TabIndex = 7;
            this.dateDownload.ValueChanged += new System.EventHandler(this.dateDownload_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(558, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "下傳時間：";
            // 
            // dateSetup
            // 
            this.dateSetup.Location = new System.Drawing.Point(418, 19);
            this.dateSetup.Name = "dateSetup";
            this.dateSetup.Size = new System.Drawing.Size(134, 23);
            this.dateSetup.TabIndex = 5;
            this.dateSetup.ValueChanged += new System.EventHandler(this.dateSetup_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "東元裝機日：";
            // 
            // cbxType
            // 
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Items.AddRange(new object[] {
            "新開",
            "停改",
            "專案"});
            this.cbxType.Location = new System.Drawing.Point(244, 18);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(82, 24);
            this.cbxType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "類型：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "門市代碼：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.btnQuery);
            this.groupBox2.Controls.Add(this.cbxQuerySite);
            this.groupBox2.Controls.Add(this.dgvQuery);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dateQueryEnd);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dateQueryStart);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(13, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(775, 448);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查詢";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(688, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Text = "重新整理";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(551, 14);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 14;
            this.btnQuery.Text = "查    詢";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dgvQuery
            // 
            this.dgvQuery.AllowUserToAddRows = false;
            this.dgvQuery.AllowUserToDeleteRows = false;
            this.dgvQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cId,
            this.cSite_id,
            this.cSite_name,
            this.cSite_type,
            this.cSite_ip,
            this.cSetup_time,
            this.cDownload_time,
            this.cStatus,
            this.cMemo});
            this.dgvQuery.Location = new System.Drawing.Point(10, 43);
            this.dgvQuery.Name = "dgvQuery";
            this.dgvQuery.ReadOnly = true;
            this.dgvQuery.RowTemplate.Height = 24;
            this.dgvQuery.Size = new System.Drawing.Size(756, 399);
            this.dgvQuery.TabIndex = 12;
            this.dgvQuery.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvQuery_CellMouseDoubleClick);
            // 
            // cId
            // 
            this.cId.DataPropertyName = "id";
            this.cId.HeaderText = "id";
            this.cId.Name = "cId";
            this.cId.ReadOnly = true;
            this.cId.Visible = false;
            // 
            // cSite_id
            // 
            this.cSite_id.DataPropertyName = "site_id";
            this.cSite_id.HeaderText = "門市代碼";
            this.cSite_id.Name = "cSite_id";
            this.cSite_id.ReadOnly = true;
            // 
            // cSite_name
            // 
            this.cSite_name.DataPropertyName = "site_name";
            this.cSite_name.HeaderText = "門市名稱";
            this.cSite_name.Name = "cSite_name";
            this.cSite_name.ReadOnly = true;
            // 
            // cSite_type
            // 
            this.cSite_type.DataPropertyName = "site_type";
            this.cSite_type.HeaderText = "類型";
            this.cSite_type.Name = "cSite_type";
            this.cSite_type.ReadOnly = true;
            // 
            // cSite_ip
            // 
            this.cSite_ip.DataPropertyName = "IP";
            this.cSite_ip.HeaderText = "IP";
            this.cSite_ip.Name = "cSite_ip";
            this.cSite_ip.ReadOnly = true;
            this.cSite_ip.Visible = false;
            // 
            // cSetup_time
            // 
            this.cSetup_time.DataPropertyName = "setup_time";
            this.cSetup_time.HeaderText = "東元裝機日";
            this.cSetup_time.Name = "cSetup_time";
            this.cSetup_time.ReadOnly = true;
            // 
            // cDownload_time
            // 
            this.cDownload_time.DataPropertyName = "download_time";
            this.cDownload_time.HeaderText = "下傳時間";
            this.cDownload_time.Name = "cDownload_time";
            this.cDownload_time.ReadOnly = true;
            // 
            // cStatus
            // 
            this.cStatus.DataPropertyName = "status";
            this.cStatus.HeaderText = "下傳狀況";
            this.cStatus.Name = "cStatus";
            this.cStatus.ReadOnly = true;
            // 
            // cMemo
            // 
            this.cMemo.DataPropertyName = "memo";
            this.cMemo.HeaderText = "備註";
            this.cMemo.Name = "cMemo";
            this.cMemo.ReadOnly = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(360, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "門市代碼：";
            // 
            // dateQueryEnd
            // 
            this.dateQueryEnd.Location = new System.Drawing.Point(220, 14);
            this.dateQueryEnd.Name = "dateQueryEnd";
            this.dateQueryEnd.Size = new System.Drawing.Size(134, 23);
            this.dateQueryEnd.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "~";
            // 
            // dateQueryStart
            // 
            this.dateQueryStart.Location = new System.Drawing.Point(57, 14);
            this.dateQueryStart.Name = "dateQueryStart";
            this.dateQueryStart.Size = new System.Drawing.Size(134, 23);
            this.dateQueryStart.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "日期：";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "下傳咖啡券";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // notifyMenu
            // 
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.notifyMenu.Name = "notifyMenu";
            this.notifyMenu.Size = new System.Drawing.Size(101, 26);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(100, 22);
            this.menuExit.Text = "離開";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // cbxQuerySite
            // 
            this.cbxQuerySite.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbxQuerySite.FormattingEnabled = true;
            this.cbxQuerySite.Location = new System.Drawing.Point(434, 14);
            this.cbxQuerySite.Name = "cbxQuerySite";
            this.cbxQuerySite.Size = new System.Drawing.Size(108, 24);
            this.cbxQuerySite.TabIndex = 13;
            // 
            // cbxSite
            // 
            this.cbxSite.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbxSite.FormattingEnabled = true;
            this.cbxSite.Location = new System.Drawing.Point(80, 18);
            this.cbxSite.Name = "cbxSite";
            this.cbxSite.Size = new System.Drawing.Size(108, 24);
            this.cbxSite.TabIndex = 11;
            // 
            // frmCoffeeTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCoffeeTicket";
            this.Text = "下傳咖啡券";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCoffeeTicket_FormClosing);
            this.Load += new System.EventHandler(this.frmCoffeeTicket_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuery)).EndInit();
            this.notifyMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateDownload;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateSetup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvQuery;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateQueryEnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateQueryStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddSite;
        private MultiColumnComboBoxDemo.MultiColumnComboBox cbxSite;
        private MultiColumnComboBoxDemo.MultiColumnComboBox cbxQuerySite;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn cId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSite_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSite_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSite_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSite_ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSetup_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDownload_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMemo;
    }
}

