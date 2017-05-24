using System;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class frmShip : Form
    {
        protected clsShip _Ship;

        public frmShip()
        {
            InitializeComponent();
        }

        public void SetDetails(clsShip prWork)
        {
            _Ship = prWork;
            updateForm();
            ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isValid())
            {

                pushData();

                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual bool isValid()
        {
            return true;
        }

        protected virtual void updateForm()
        {
            txtName.Text = _Ship.Name;
            lblDateOfMod.Text = _Ship.DateOfModification.ToShortDateString();
            txtPrice.Text = _Ship.Price.ToString();
            txtStock.Text = _Ship.StockQuanitiy.ToString();
            txtName.Enabled = string.IsNullOrEmpty(_Ship.Name);
        }

        protected virtual void pushData()
        {
            _Ship.Name = txtName.Text;
            _Ship.DateOfModification = DateTime.Parse(lblDateOfMod.Text);
            _Ship.Price = decimal.Parse(txtPrice.Text);
            _Ship.StockQuanitiy = int.Parse(txtStock.Text);
        }

    }
}