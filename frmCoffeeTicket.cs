using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using coffee_ticket.Models;
using System.Threading;
using System.Timers;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;

namespace coffee_ticket
{
    public partial class frmCoffeeTicket : Form
    {
        private static readonly string DB_PATH = ConfigurationManager.AppSettings["DB-PATH"].ToString();
        private static readonly string DB_CONN = @"data source=" + DB_PATH;
        private static readonly string SOURCE = ConfigurationManager.AppSettings["SOURCE"].ToString();
        private static readonly string DESTINATION = ConfigurationManager.AppSettings["DESTINATION"].ToString();
        private static readonly string SYNC_SITE = new ConfigCipher().Verify("SYNC-SITE");
        private DataTable SITES_INSERT = new DataTable();
        private DataTable SITES_QUERY = new DataTable();

        private System.Timers.Timer SYNC_TIMER = new System.Timers.Timer();
        private System.Timers.Timer RUN_TIMER = new System.Timers.Timer();
        private System.Timers.Timer NOW_TIMER = new System.Timers.Timer();

        public frmCoffeeTicket()
        {
            InitializeComponent();
            InitSQLiteDb();
            //SyncSite();
            InitSitesList();         
            GetCoffeeData();   
        }

        private void InitSQLiteDb()
        {
            if (File.Exists(DB_PATH)) return;
            using (IDbConnection cn = new SQLiteConnection(DB_CONN))
            {
                cn.Execute(@"
                        CREATE TABLE Coffee (
                            site_id       VARCHAR(10),
                            site_type     VARCHAR(20),
                            setup_time    DATETIME,
                            download_time DATETIME,
                            status        VARCHAR(20),
                            memo          VARCHAR(100),
                            crt_time      DATETIME,
                            CONSTRAINT Coffee_PK PRIMARY KEY (site_id)
                        )");
                cn.Execute(@"
                        CREATE TABLE Site (
                            id   VARCHAR(10),
                            name VARCHAR(50),
                            ip   VARCHAR(15),
                            CONSTRAINT Site_PK PRIMARY KEY (id)
                        )");
            }

            SyncSite();
        }

        private void InitSitesList()
        {
            using (IDbConnection cn = new SQLiteConnection(DB_CONN))
            {
                var insert_sites = cn.ExecuteReader("SELECT id, name FROM Site ORDER BY id");
                SITES_INSERT.Load(insert_sites);

                var query_sites = cn.ExecuteReader("SELECT id, name FROM Site ORDER BY id");
                SITES_QUERY.Load(query_sites);
            }

            cbxSite.DataSource = SITES_INSERT;
            cbxSite.DisplayMember = "id";
            cbxSite.ValueMember = "name";

            cbxQuerySite.DataSource = SITES_QUERY;
            cbxQuerySite.DisplayMember = "id";
            cbxQuerySite.ValueMember = "name";


        }

        private void SyncSite()
        {
            new Thread (() =>
            {
                DataTable sites = new DataTable();

                using (IDbConnection cn = new SqlConnection(SYNC_SITE))
                {
                    var rows = cn.ExecuteReader("SELECT [ID] ,[NAME] ,[IP] FROM [PXMSDE].[dbo].[POP_LABEL_STORE] ORDER BY [ID]");
                    sites.Load(rows);
                }

                using (IDbConnection cn = new SQLiteConnection(DB_CONN))
                {
                    cn.Execute(@"DELETE FROM Site");
                    try
                    {                     
                        foreach (DataRow dr in sites.Rows)
                        {
                            var cmd = @"INSERT INTO Site VALUES (@id, @name, @ip)";
                            cn.Execute(cmd, new Site(dr["ID"].ToString(), dr["NAME"].ToString(), dr["IP"].ToString()));
                        }          
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                InitSitesList();

            }).Start();
           
        }

        private void frmCoffeeTicket_Load(object sender, EventArgs e)
        {
            dateSetup.Format = DateTimePickerFormat.Custom;
            dateSetup.CustomFormat = "yyyy/MM/dd";

            dateDownload.Format = DateTimePickerFormat.Custom;
            dateDownload.CustomFormat = "yyyy/MM/dd";
            dateDownload.Value = dateSetup.Value.AddDays(-1);

            dateQueryStart.Format = DateTimePickerFormat.Custom;
            dateQueryStart.CustomFormat = "yyyy/MM/dd";

            dateQueryEnd.Format = DateTimePickerFormat.Custom;
            dateQueryEnd.CustomFormat = "yyyy/MM/dd";

            dgvQuery.Columns["cSetup_time"].DefaultCellStyle.Format = "yyyy/MM/dd";
            dgvQuery.Columns["cDownload_time"].DefaultCellStyle.Format = "yyyy/MM/dd";
            cbxType.SelectedIndex = 0;
            cbxQuerySite.Text = string.Empty;

            SYNC_TIMER.Interval = 60000;  //60秒執行一次
            SYNC_TIMER.AutoReset = true;
            SYNC_TIMER.Enabled = true;
            SYNC_TIMER.Elapsed += new System.Timers.ElapsedEventHandler(SYNC_TIMER_tick);
            SYNC_TIMER.Start();

            RUN_TIMER.Interval = 600000; //10分鐘執行一次
            RUN_TIMER.AutoReset = true;
            RUN_TIMER.Enabled = true;
            RUN_TIMER.Elapsed += new System.Timers.ElapsedEventHandler(RUN_TIMER_tick);
            RUN_TIMER.Start();

            NOW_TIMER.Interval = 1000; //一秒行執一次
            NOW_TIMER.AutoReset = true;
            NOW_TIMER.Enabled = true;
            NOW_TIMER.Elapsed += new System.Timers.ElapsedEventHandler(NOW_TIMER_tick);
            NOW_TIMER.Start();

            notifyIcon.Visible = false;
            this.KeyPreview = true;

            if (!File.Exists(SOURCE))
            {
                MessageBox.Show("路徑：" + SOURCE + " 找不到檔案，程式關閉，請重新設定。");
                Environment.Exit(0);
            }

            Refresh_Display();
            //string ip = "172.31.4.3";

            //MessageBox.Show(@"net use p: \\" + ip.Trim() + @"\" + DESTINATION.Trim().Replace(@":", @"$") + " px1812 /user:administrator");
            //MessageBox.Show(@"XCOPY " + SOURCE + @" p: /S /D /Y");

        }

        private void NOW_TIMER_tick(object sender, ElapsedEventArgs e)
        {
            this.BeginInvoke(new EventHandler(delegate {
                this.Text = "下傳咖啡券 - (" + DateTime.Now.ToString("HH:mm:ss") + ")";
            }));
        }

        private void RUN_TIMER_tick(object sender, ElapsedEventArgs e)
        {
            //每天16點開始，10分鐘執行一次，最少執行5次
            if (DateTime.Now.Hour == 16)
            {
                DataTable coffee_data = new DataTable();

                using (IDbConnection cn = new SQLiteConnection(DB_CONN))
                {
                    var coffee_row = cn.ExecuteReader(@"SELECT c.site_id, s.ip as ip, c.download_time, c.status
                                                        FROM Coffee c LEFT JOIN Site s ON c.site_id = s.id 
                                                        WHERE date('now') = date(c.download_time)
                                                        --AND (c.status <> '已完成' OR c.status is NULL);");
                    coffee_data.Load(coffee_row);
                }

                try
                {
                    foreach (DataRow dr in coffee_data.Rows)
                    {
                        string site_id = dr["site_id"].ToString().Trim();
                        string site_ip = dr["ip"].ToString().Trim();

                        if (PingIP(site_ip))
                        {
                            if (CopyCoffeeTicket(site_ip))
                            {
                                UpdateCoffeeStatus(site_id, "已完成", "完成時間：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            }
                            else
                            {
                                UpdateCoffeeStatus(site_id, "失敗", "失敗時間：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            }
                        }
                        else
                        {
                            UpdateCoffeeStatus(site_id, "失敗", "找不到電腦：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        this.BeginInvoke(new Action(GetCoffeeData));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void UpdateCoffeeStatus(string site_id, string status, string message)
        {
            try
            {
                using (IDbConnection cn = new SQLiteConnection(DB_CONN))
                {
                    cn.Execute(@"UPDATE Coffee
                            SET status = '" + status.Trim() + "' ,memo = '" + message.Trim() +
                                @"'  WHERE site_id = '" + site_id + "';");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool PingIP(string IPv4Address)
        {
            IPAddress ip = IPAddress.Parse(IPv4Address);
            Ping pingControl = new Ping();
            PingReply reply = pingControl.Send(ip);
            pingControl.Dispose();
            if (reply.Status != IPStatus.Success)
                return false;
            else
                return true;
        }

        private bool CopyCoffeeTicket(string ip)
        {
            bool isSuccess = false;
            Process proc = new Process();
            proc.StartInfo.FileName = @"cmd.exe";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.CreateNoWindow = true;

            
            try
            {
                OpenNetworkDrive(ip);

                proc.Start();                
                proc.StandardInput.WriteLine(@"XCOPY " + SOURCE + @" z:rsl\day_log\download /S /D /Y");

                if (File.Exists(@"z:\\rsl\day_log\download\COFFEE_TICKET.FLG"))
                    isSuccess = true;
                else
                    isSuccess = false;

                proc.StandardInput.WriteLine(@"net use z: /del /y");
                proc.StandardInput.WriteLine(@"exit");
                string POutput = proc.StandardOutput.ReadToEnd();

                proc.WaitForExit();
                proc.Close();
                
            }
            catch
            {
                isSuccess = false;
            }

            return isSuccess;
        }

        private void OpenNetworkDrive(string ip)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = @"cmd.exe";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.CreateNoWindow = true;

            try
            {
                proc.Start();
                proc.StandardInput.WriteLine(@"net use z: /del /y");
                proc.StandardInput.WriteLine(@"net use z: \\" + ip + @"\" + DESTINATION.Trim().Substring(0,1) + @"$" + " px1812 /user:administrator");
                proc.StandardInput.WriteLine(@"exit");
                proc.WaitForExit();
                proc.Close();
            }
            catch
            { }

            DirectoryInfo info = new DirectoryInfo(@"z:\");
            if (info.Exists)
            {
                //MessageBox.Show("YES");
                return;
            }
            else
            {
                //MessageBox.Show("NO");
                OpenNetworkDrive(ip);
            }
        }

        private void SYNC_TIMER_tick(object sender, ElapsedEventArgs e)
        {
            //23:55 同步門市主檔：id, name, ip
            if (DateTime.Now.Hour == 23 && DateTime.Now.Minute == 55)
            {
                SyncSite();                
            }
        }

        private void btnAddSite_Click(object sender, EventArgs e)
        {
            if (dateDownload.Value > dateSetup.Value)
            {
                MessageBox.Show("下傳日期不可大於東元裝機日期！", "錯誤");
                return;
            }

            using (IDbConnection cn = new SQLiteConnection(DB_CONN))
            {
                DataTable coffee_data = new DataTable();
                var coffee_row = cn.ExecuteReader(@"SELECT * FROM Coffee WHERE site_id = '" + cbxSite.Text.Trim() + "';");
                coffee_data.Load(coffee_row);

                try
                {
                    string site_id = cbxSite.Text.Trim();
                    string site_type = cbxType.Text;
                    DateTime setup_time = dateSetup.Value.Date;
                    DateTime download_time = dateDownload.Value.Date;
                    string memo = txtMemo.Text.Trim();

                    if (coffee_data.Rows.Count == 0)
                    {
                        var cmd = @"INSERT INTO Coffee 
                                (site_id, site_type, setup_time, download_time, memo, crt_time)
                            VALUES 
                                (@site_id, @site_type, @setup_time, @download_time, @memo, datetime('now', 'localtime'))";
                        cn.Execute(cmd, new Coffee(site_id, site_type, setup_time, download_time, memo));
                    }
                    else
                    {
                        cn.Execute(@"UPDATE Coffee SET " +
                            @"site_type = '" + site_type + "', " +
                            @"setup_time = '" + setup_time.ToString("yyyy-MM-dd 00:00:00") + "', " +
                            @"download_time = '" + download_time.ToString("yyyy-MM-dd 00:00:00") + "', " +
                            @"memo = '" + memo + "' " +
                            @"WHERE site_id = '" + site_id + "';");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            cbxSite.Text = string.Empty;
            cbxType.SelectedIndex = 0;
            dateSetup.Value = DateTime.Now;
            dateDownload.Value = DateTime.Now.AddDays(-1);
            txtMemo.Text = string.Empty;

            GetCoffeeData();
        }

        private void dateDownload_ValueChanged(object sender, EventArgs e)
        {
            if(dateDownload.Value > dateSetup.Value)
            {
                MessageBox.Show("下傳日期不可大於東元裝機日期！", "錯誤");
            }
        }

        private void GetCoffeeData()
        {
            DataTable coffee_data = new DataTable();

            using (IDbConnection cn = new SQLiteConnection(DB_CONN))
            {
                var coffee_row = cn.ExecuteReader(@"SELECT c.site_id, s.name as site_name, s.ip as ip, c.site_type, c.setup_time,
                                                    c.download_time, c.status, c.memo
                                                    FROM Coffee c left join Site s on c.site_id = s.id ORDER BY c.site_id");
                coffee_data.Load(coffee_row); 
            }

            dgvQuery.DataSource = coffee_data;
            dgvQuery.Refresh();
        }

        private void GetCoffeeDate(DateTime start, DateTime end, string site_id)
        {
            DataTable coffee_data = new DataTable();

            using (IDbConnection cn = new SQLiteConnection(DB_CONN))
            {
                var coffee_row = cn.ExecuteReader(@"SELECT c.site_id, s.name as site_name, s.ip as ip, c.site_type, c.setup_time,
                                                    c.download_time, c.status, c.memo
                                                    FROM Coffee c left join Site s on c.site_id = s.id 
                                                    WHERE c.setup_time BETWEEN '" + start.ToString("yyyy-MM-dd 00:00:00") + @"' AND '" + end.ToString("yyyy-MM-dd 23:59:59") + @"' " +
                                                    @" AND (c.site_id = '" + site_id.Trim() + @"' OR '999999' = '" + site_id.Trim() + @"')" +
                                                    @" ORDER BY c.site_id ");
                coffee_data.Load(coffee_row);
            }

            dgvQuery.DataSource = coffee_data;
            dgvQuery.Refresh();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh_Display();

            GetCoffeeData();
        }

        private void Refresh_Display()
        {
            dateQueryStart.Value = DateTime.Now;
            dateQueryEnd.Value = DateTime.Now;
            cbxQuerySite.Text = string.Empty;

            cbxSite.Text = string.Empty;
            cbxType.SelectedIndex = 0;
            dateSetup.Value = DateTime.Now;
            dateDownload.Value = DateTime.Now.AddDays(-1);
            txtMemo.Text = string.Empty;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            GetCoffeeDate(dateQueryStart.Value, dateQueryEnd.Value, 
                (cbxQuerySite.Text.Trim() == string.Empty) ? "999999": cbxQuerySite.Text.Trim());
        }

        private void dateSetup_ValueChanged(object sender, EventArgs e)
        {
            dateDownload.Value = dateSetup.Value.AddDays(-1);
        }

        private void frmCoffeeTicket_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;
                notifyIcon.Tag = string.Empty;
                notifyIcon.ShowBalloonTip(3000, this.Text, "下傳咖啡券-排程中！", ToolTipIcon.Info);
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            SYNC_TIMER.Stop();
            RUN_TIMER.Stop();
            NOW_TIMER.Stop();
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                Refresh_Display();
            }
        }

        private void dgvQuery_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvQuery.CurrentCell = dgvQuery.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cbxSite.Text = dgvQuery.Rows[e.RowIndex].Cells["cSite_id"].Value.ToString();
                cbxType.Text = dgvQuery.Rows[e.RowIndex].Cells["cSite_type"].Value.ToString();
                dateSetup.Value = DateTime.Parse(dgvQuery.Rows[e.RowIndex].Cells["cSetup_time"].Value.ToString());
                dateDownload.Value = DateTime.Parse(dgvQuery.Rows[e.RowIndex].Cells["cDownload_time"].Value.ToString());
                txtMemo.Text = dgvQuery.Rows[e.RowIndex].Cells["cMemo"].Value.ToString();
            }

        }
    }
}
