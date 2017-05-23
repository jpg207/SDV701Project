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
    public partial class frmShip : Form
    {
        protected clsShip _Ship;

        public frmShip() {
            InitializeComponent();
        }

        public void SetDetails(clsShip prShip) {
            _Ship = prShip;
            updateForm();
            ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e) {
            if (isValid())
            {

                pushData();
                if (txtName.Enabled)
                    Program.SvcClient.InsertWork(_Ship);
                else
                    Program.SvcClient.UpdateWork(_Ship);

                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        protected virtual bool isValid() {
            return true;
        }

        protected virtual void updateForm() {
            txtName.Text = _Ship.Name;
            txtCreation.Text = _Ship.Date.ToShortDateString();
            txtValue.Text = _Ship.Value.ToString();
            txtName.Enabled = string.IsNullOrEmpty(_Ship.Name);
        }

        protected virtual void pushData() {
            _Ship.Name = txtName.Text;
            _Ship.Date = DateTime.Parse(txtCreation.Text);
            _Ship.Value = decimal.Parse(txtValue.Text);
        }
    }
}
