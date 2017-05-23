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
    public partial class frmShipsList : Form
    {
        private clsNationList _Artist;
        //private clsWorksList _ShipsList;

        private static Dictionary<string, frmShipsList> _ShipsList = new Dictionary<string, frmShipsList>();

        private frmShipsList() {
            InitializeComponent();
        }

        public static void Run(string prNationName) {
            frmShipsList lcShipsListForm;
            if (string.IsNullOrEmpty(prNationName) || !_ShipsList.TryGetValue(prNationName, out lcShipsListForm))
            {
                lcShipsListForm = new frmShipsList();
                if (string.IsNullOrEmpty(prNationName))
                    lcShipsListForm.SetDetails(new clsNation());
                else
                {
                    _ShipsList.Add(prNationName, lcShipsListForm);
                    lcShipsListForm.refreshFormFromDB(prNationName);

                }
            }
            else
            {
                lcShipsListForm.Show();
                lcShipsListForm.Activate();
            }
        }

        private void refreshFormFromDB(string prNationName) {
            SetDetails(Program.SvcClient.GetNation(prNationName));
        }

        private void updateTitle(string prNationName) {
            if (!string.IsNullOrEmpty(prNationName))
                Text = "Nation Details - " + prNationName;
        }

        private void UpdateDisplay() {
            lstShips.DataSource = null;
            if (_Nation.Ships != null)
                lstShips.DataSource = _Nation.Ships.ToList();

        }

        public void UpdateForm() {
            txtName.Text = _Nation.Name;
            txtSpeciality.Text = _Nation.Speciality;
            txtPhone.Text = _Nation.Phone;
            //         _ShipsList = _Artist.WorksList;

        }

        public void SetDetails(clsNation prNation) {
            _Nation = prNation;
            txtName.Enabled = string.IsNullOrEmpty(_Nation.Name);
            UpdateForm();
            UpdateDisplay();
            frmMain.Instance.NationNameChanged += new frmMain.Notify(updateTitle);
            //            updateTitle(_Artist.ArtistList.GalleryName);
            Show();
        }

        private void pushData() {
            _Nation.Name = txtName.Text;
            _Nation.Speciality = txtSpeciality.Text;
            _Nation.Phone = txtPhone.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            string lcReply = new frmInputBox(clsShip.FACTORY_PROMPT).Answer;
            if (!string.IsNullOrEmpty(lcReply))
            {
                clsShip lcShip = clsShip.NewShip(lcReply[0]);
                if (lcShip != null)
                {
                    if (txtName.Enabled)
                    {
                        pushData();
                        Program.SvcClient.InsertArtist(_Artist);
                        txtName.Enabled = false;
                    }
                    lcShip.NationName = _Nation.Name;
                    lcShip.EditDetails();
                    if (!string.IsNullOrEmpty(lcShip.Name))
                    {
                        refreshFormFromDB(_Nation.Name);
                        frmNation.Instance.UpdateDisplay();
                    }
                }
            }
        }

        private void lstWorks_DoubleClick(object sender, EventArgs e) {
            try
            {
                //             _ShipsList.EditWork(lstWorks.SelectedIndex);
                (lstShips.SelectedValue as clsShip).EditDetails();
                UpdateDisplay();
                frmNation.Instance.UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            int lcIndex = lstShips.SelectedIndex;

            if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting ship", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Program.SvcClient.DeleteWork(lstShips.SelectedItem as clsShip);
                refreshFormFromDB(_Artist.Name);
                frmNation.Instance.UpdateDisplay();
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            pushData();
            if (txtName.Enabled)
            {
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    Program.SvcClient.InsertArtist(_Artist);
                    frmNation.Instance.UpdateDisplay();
                    txtName.Enabled = false;
                }
            }
            else
                Program.SvcClient.UpdateArtist(_Artist);
            Hide();
        }

        private Boolean isValid() {

            //if (txtName.Enabled && txtName.Text != "")
            //    if (_Artist.IsDuplicate(txtName.Text))
            //    {
            //        MessageBox.Show("Artist with that name already exists!", "Error adding artist");
            //        return false;
            //    }
            //    else
            //        return true;
            //else
            return true;
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e) {
            //            _ShipsList.SortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
        }
    }
}
