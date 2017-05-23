using System;
using System.Windows.Forms;
using System.Collections.Generic;
using AdminApp.ServiceReference1;
using System.Linq;
using Gallery3WinForm;

namespace AdminApp
{
    public partial class frmNation : Form
    {
        private clsArtist _Artist;
//        private clsWorksList _WorksList;

        private static Dictionary<string, frmNation> _ArtistFormList =
            new Dictionary<string, frmNation>();

        private frmNation()
        {
            InitializeComponent();
        }

        public static void Run(string prArtistName)
        {
            frmNation lcArtistForm;
            if(string.IsNullOrEmpty(prArtistName) || !_ArtistFormList.TryGetValue(prArtistName, out lcArtistForm))
            {
                lcArtistForm = new frmNation();
                if (string.IsNullOrEmpty(prArtistName))
                    lcArtistForm.SetDetails(new clsArtist());
                else
                {
                    _ArtistFormList.Add(prArtistName, lcArtistForm);
                    lcArtistForm.refreshFormFromDB(prArtistName);

                }
            }
            else
            {
                lcArtistForm.Show();
                lcArtistForm.Activate();
            }
        }

        private void refreshFormFromDB(string prArtistName)
        {
            SetDetails(Program.SvcClient.GetArtist(prArtistName));
        }

        private void updateTitle(string prGalleryName)
        {
            if (!string.IsNullOrEmpty(prGalleryName))
                Text = "Artist Details - " + prGalleryName;
        }

        private void UpdateDisplay()
        {
            lstWorks.DataSource = null;
            if (_Artist.Works != null)
                lstWorks.DataSource = _Artist.Works.ToList();

        }

        public void UpdateForm()
        {
            txtName.Text = _Artist.Name;
            txtSpeciality.Text = _Artist.Speciality;
            txtPhone.Text = _Artist.Phone;
   //         _WorksList = _Artist.WorksList;

        }

        public void SetDetails(clsArtist prArtist)
        {
            _Artist = prArtist;
            txtName.Enabled = string.IsNullOrEmpty(_Artist.Name);
            UpdateForm();
            UpdateDisplay();
            frmNations.Instance.GalleryNameChanged += new frmNations.Notify(updateTitle);
//            updateTitle(_Artist.ArtistList.GalleryName);
            Show();
        }

        private void pushData()
        {
            _Artist.Name = txtName.Text;
            _Artist.Speciality = txtSpeciality.Text;
            _Artist.Phone = txtPhone.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string lcReply = new InputBox(clsWork.FACTORY_PROMPT).Answer;
            if (!string.IsNullOrEmpty(lcReply))
            {
                clsWork lcWork = clsWork.NewWork(lcReply[0]);
                if(lcWork != null)
                {
                    if (txtName.Enabled)
                    {
                        pushData();
                        Program.SvcClient.InsertArtist(_Artist);
                        txtName.Enabled = false;
                    }
                    lcWork.ArtistName = _Artist.Name;
                    lcWork.EditDetails();
                    if (!string.IsNullOrEmpty(lcWork.Name))
                    {
                        refreshFormFromDB(_Artist.Name);
                        frmNations.Instance.UpdateDisplay();
                    }

                }
            }

        }

        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //             _WorksList.EditWork(lstWorks.SelectedIndex);
                (lstWorks.SelectedValue as clsWork).EditDetails();
                UpdateDisplay();
                frmNations.Instance.UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int lcIndex = lstWorks.SelectedIndex;

            if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Program.SvcClient.DeleteWork(lstWorks.SelectedItem as clsWork);
                refreshFormFromDB(_Artist.Name);
                frmNations.Instance.UpdateDisplay();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
                    pushData();
                    if (txtName.Enabled)
                    {
                       if (!string.IsNullOrEmpty(txtName.Text))
                        {
                            Program.SvcClient.InsertArtist(_Artist);
                            frmNations.Instance.UpdateDisplay();
                            txtName.Enabled = false;
                        }
                    }
                    else
                        Program.SvcClient.UpdateArtist(_Artist);
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