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

        public void SetDetails(clsShip prShip)
        {
            _Ship = prShip;
            updateForm();
            ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();
                if (txtName.Enabled == true)
                {
                    clsJSONConnection.AddShip(_Ship);
                }
                else
                {
                    clsJSONConnection.UpdateShip(_Ship);
                }
                
                //frmNation.Instance.();
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
            lblDateOfMod.Text = _Ship.DateOfModification;
            txtPrice.Text = _Ship.Price.ToString();
            txtStock.Text = _Ship.StockQuanitiy.ToString();
            txtName.Enabled = string.IsNullOrEmpty(_Ship.Name);
        }

        protected virtual void pushData()
        {
            _Ship.Name = txtName.Text;
            _Ship.DateOfModification = lblDateOfMod.Text;
            _Ship.Price = int.Parse(txtPrice.Text);
            _Ship.StockQuanitiy = int.Parse(txtStock.Text);
        }

    }
}