using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Gallery3WinForm;
using System.Threading.Tasks;

namespace AdminApp
{
    public partial class frmNation : Form
    {
        private static readonly frmNation _Instance = new frmNation();

        public static frmNation Instance
        {
            get{return _Instance;}
        }

        private clsNation _Nation;
    //private clsWorksList _WorksList;

        private static Dictionary<int, frmNation> _NationFormList = new Dictionary<int, frmNation>();

        private frmNation()
        {
            InitializeComponent();
        }

        public static void Run(clsNation Nation)
        {
            frmNation lcNationForm;
            if(Nation.NationID == 0 || !_NationFormList.TryGetValue(Nation.NationID, out lcNationForm))
            {
                lcNationForm = new frmNation();
                _NationFormList.Add(Nation.NationID, lcNationForm);
                lcNationForm.SetDetails(Nation);
            }
            else
            {
                lcNationForm.Show();
                lcNationForm.Activate();
            }
        }

        private void UpdateDisplay()
        {
            lstShips.DataSource = null;
            //GET LIST OF SHIPS HERE
            //if (_Nation.Ships != null)
            lstShips.DataSource = _Nation.NationShips;

        }

        public void UpdateForm()
        {
            lblNation.Text = "Name: " + _Nation.Name;
            lblBuildCapacity.Text = "Build Capacity: " + _Nation.BuildingCapacity;

        }

        public void SetDetails(clsNation prNation)
        {
            _Nation = prNation;
            lblNation.Text = _Nation.Name;
            UpdateForm();
            UpdateDisplay();
            //updateTitle(_Artist.ArtistList.GalleryName);
            Show();
        }

        private void pushData()
        {
            _Nation.Name = lblNation.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string lcReply = new InputBox(clsShip.FACTORY_PROMPT).Answer;
            if (!string.IsNullOrEmpty(lcReply))
            {
                clsShip lcShip = clsShip.NewShip(lcReply[0]);
                if(lcShip != null)
                {
                    lcShip.NationID = _Nation.NationID;
                    lcShip.EditDetails();
                    if (!string.IsNullOrEmpty(lcShip.Name))
                    {
                        SetDetails(_Nation);
                    }

                }
            }

        }

        private void lstShip_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //_WorksList.EditWork(lstWorks.SelectedIndex);
                (lstShips.SelectedValue as clsShip).EditDetails();
                UpdateDisplay();
                //frmNations.Instance.UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int lcIndex = lstShips.SelectedIndex;

            if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting Ship", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //CALL DELETE SHIP HERE
                //Program.SvcClient.DeleteWork(lstShips.SelectedItem as clsShip);
                //clsShip Ship = lstShips.SelectedItem;
                clsJSONConnection.DeleteShip((lstShips.SelectedItem as clsShip).ShipID.ToString());

                System.Threading.Thread.Sleep(500);

                SetDetails(_Nation);
                //frmNations.Instance.UpdateDisplay();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pushData();
            Hide();
        }

        private Boolean isValid()
        {
            
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

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
//            _WorksList.SortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
        }

    }
}