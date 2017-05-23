using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDV701ProjectVS
{
    public partial class frmMain : Form
    {
        private static readonly frmMain _Instance = new frmMain();

        public frmMain() {
            InitializeComponent();
        }


        public static frmMain Instance
        {
            get { return frmMain._Instance; }
        }

        private void btnNations_Click(object sender, EventArgs e)
        {
            frmNation.Instance();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            frmOrders _frmOrders = new frmOrders();
            _frmOrders.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}