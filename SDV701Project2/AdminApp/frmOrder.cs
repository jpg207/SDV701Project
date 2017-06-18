using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class frmOrder : Form
    {
        public frmOrder() {
            InitializeComponent();
        }

        private static readonly frmOrder _Instance = new frmOrder();

        public static frmOrder Instance
        {
            get { return _Instance; }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            string lcKey;
            DialogResult result = MessageBox.Show("Are you sure you want to delete this order?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                lcKey = Convert.ToString(lstOrders.SelectedItem);
                lcKey = Regex.Match(lcKey, @"\d*").Value;
                clsJSONConnection.DeleteOrder(lcKey);
            }
            UpdateDisplay();
        }

        private void frmOrder_Load(object sender, EventArgs e) {
            UpdateDisplay();
        }

        async void UpdateDisplay() {
            try
            {
                lstOrders.DataSource = null;
                lstOrders.DataSource = await clsJSONConnection.GetAllOrders();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error connecting to host service. Program will now close \n" + e);
            }
        }
    }
}
