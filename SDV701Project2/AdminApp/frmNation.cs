using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

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
                lcNationForm.SetDetails(Nation);
                lcNationForm.Show();
                lcNationForm.Activate();
            }
        }

        private void UpdateDisplay() {
            lstShips.DataSource = null;
            lstShips.DataSource = _Nation.NationShips;

        }

        private void refreshDB() {
            clsNations.NationList = clsJSONConnection.GetAllNations();
        }

        public void UpdateForm()
        {
            lblNation.Text = "Name: " + _Nation.Name;
            lblBuildCapacity.Text = "Build Capacity: " + _Nation.BuildingCapacity;

        }

        public void SetDetails(clsNation prNation)
        {
            refreshDB();
            _Nation = clsNations.NationList.First(clsNation => clsNation.NationID == prNation.NationID);
            lblNation.Text = _Nation.Name;
            UpdateForm();
            UpdateDisplay();
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
                (lstShips.SelectedValue as clsShip).EditDetails();
                SetDetails(_Nation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e) {
            int lcIndex = lstShips.SelectedIndex;

            if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting Ship", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await clsJSONConnection.DeleteShip((lstShips.SelectedItem as clsShip).ShipID.ToString());

                SetDetails(_Nation);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pushData();
            Hide();
        }
    }
}