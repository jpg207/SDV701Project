using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class frmMain : Form
    {

        private static List<clsNation> _NationList = new List<clsNation>();

        public static List<clsNation> NationList
        {
            get { return _NationList; }
            set { _NationList = value; }
        }

        public frmMain() {
            InitializeComponent();
        }

        private static readonly frmMain _Instance = new frmMain();

        public static frmMain Instance
        {
            get { return frmMain._Instance; }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnNations_Click(object sender, EventArgs e) {
            frmNations.Instance.Show();
        }

        private void btnOrders_Click(object sender, EventArgs e) {
            frmOrder.Instance.Show();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            checkConnection();
        }

        private void checkConnection() {
            string Status;
            btnNations.Enabled = false;
            btnOrders.Enabled = false;
            lblStatus.Text = "Status: Establishing Connection";
            try
            {
                NationList = clsJSONConnection.GetAllNations();
                Status = "Status: Connected";
                btnNations.Enabled = true;
                btnOrders.Enabled = true;
            }
            catch
            {
                Status = "Status: Connection Failed";
            }
            lblStatus.Text = Status;
        }

        private void btnCheckConnection_Click(object sender, EventArgs e) {
            checkConnection();
        }
    }
}
