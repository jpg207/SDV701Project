using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Gallery3WinForm;

namespace AdminApp
{
    public partial class frmNation : Form
    {
        private clsNation _Nation;
//        private clsWorksList _WorksList;

        private static Dictionary<string, frmNation> _ArtistFormList =
            new Dictionary<string, frmNation>();

        private frmNation()
        {
            InitializeComponent();
        }

        public static void Run(string prArtistName)
        {
            frmNation lcNationForm;
            if(string.IsNullOrEmpty(prArtistName) || !_ArtistFormList.TryGetValue(prArtistName, out lcNationForm))
            {
                lcNationForm = new frmNation();
                if (string.IsNullOrEmpty(prArtistName))
                    lcNationForm.SetDetails(new clsNation());
                else
                {
                    _ArtistFormList.Add(prArtistName, lcNationForm);
                    lcNationForm.refreshFormFromDB(prArtistName);

                }
            }
            else
            {
                lcNationForm.Show();
                lcNationForm.Activate();
            }
        }

        private void refreshFormFromDB(string prArtistName)
        {
            //REFRESH NATION PAGE FROM DB HERE
            //SetDetails(Program.SvcClient.GetArtist(prArtistName));
        }

        private void updateTitle(string prGalleryName)
        {
            if (!string.IsNullOrEmpty(prGalleryName))
                Text = "Artist Details - " + prGalleryName;
        }

        private void UpdateDisplay()
        {
            lstShips.DataSource = null;
            //GET LIST OF SHIPS HERE
            //if (_Nation.Ships != null)
            //    lstShips.DataSource = _Nation.Ships.ToList();

        }

        public void UpdateForm()
        {
            lblNation.Text = _Nation.Name;

        }

        public void SetDetails(clsNation prArtist)
        {
            _Nation = prArtist;
            lblNation.Text = _Nation.Name;
            UpdateForm();
            UpdateDisplay();
            frmNations.Instance.NationNameChanged += new frmNations.Notify(updateTitle);
//            updateTitle(_Artist.ArtistList.GalleryName);
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
                    lcShip.ArtistName = _Nation.Name;
                    lcShip.EditDetails();
                    if (!string.IsNullOrEmpty(lcShip.Name))
                    {
                        refreshFormFromDB(_Nation.Name);
                        //frmNations.Instance.UpdateDisplay();
                    }

                }
            }

        }

        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //             _WorksList.EditWork(lstWorks.SelectedIndex);
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

            if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //CALL DELETE SHIP HERE
                //Program.SvcClient.DeleteWork(lstShips.SelectedItem as clsShip);
                refreshFormFromDB(_Nation.Name);
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