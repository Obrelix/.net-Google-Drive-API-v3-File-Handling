using Google.Apis.Calendar.v3.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleDriveManager
{
    public partial class frmCalendar : Form
    {

        static string savePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BackUpManager";
        static string saveFile = savePath + "\\GDASaves.json";
        public static List<User> UserList = new List<User>();
        DataTable dtCalendar = new DataTable();

        public frmCalendar()
        {
            InitializeComponent();
        }

        private void frmCalendar_Load(object sender, EventArgs e)
        {
            loadUsers(savePath, saveFile);
            cbUserInit();
            dgvCalendar.DataSource = dtCalendar;
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

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cbUser.SelectedIndex == -1)
            {
                MessageBox.Show("You have to Select A User in order to connect", "Attention!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (GoogleCalendarAPIV3.GoogleCalendarConnection(
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

        private void updateDataGridView(string name = null, string type = null)
        {
            dtCalendar = null;
            dtCalendar = Gtools.ToDataTable<GoogleCaledar>(GoogleCalendarAPIV3.listCalendar());
            dgvCalendar.DataSource = dtCalendar;
            //dgvCalendar.Rows.Clear();
            //foreach(GoogleCaledar item in GoogleCalendarAPIV3.listCalendar())
            //{
            //    dgvCalendar.Rows.Add(new string[] { item.})
            //}
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            updateDataGridView();
        }
    }
}
