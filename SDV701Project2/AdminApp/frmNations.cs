using AdminApp.ServiceReference1;
using System;
using System.Windows.Forms;

namespace AdminApp
{
    public sealed partial class frmNations : Form
    {
        private static readonly frmNations _Instance = new frmNations();


        public delegate void Notify(string prGalleryName);

        public event Notify GalleryNameChanged;

        private frmNations()
        {
            InitializeComponent();
        }

        public static frmNations Instance
        {
            get { return frmNations._Instance; }
        }

        private void updateTitle(string prGalleryName)
        {
            if (!string.IsNullOrEmpty(prGalleryName))
                Text = "Gallery (v3 C) - " + prGalleryName;
        }

        public void UpdateDisplay()
        {
            try
            {
                lstArtists.DataSource = null;
                lstArtists.DataSource = Program.SvcClient.GetArtistNames();
            }
            catch(Exception e)
            {
                MessageBox.Show("Error connecting to host service. Program will now close \n" + e);
                Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmNation.Run(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error adding new artist");
            }
        }

        private void lstArtists_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
                try
                {
                    frmNation.Run(lstArtists.SelectedItem as string);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "This should never occur");
                }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null && MessageBox.Show("Are you sure?", "Deleting artist", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    clsArtist lcArtist = Program.SvcClient.GetArtist(lcKey);
                    Program.SvcClient.DeleteArtist(lcArtist);
                    lstArtists.ClearSelected();
                    UpdateDisplay();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error deleting artist");
                }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
            GalleryNameChanged += new Notify(updateTitle);
        }

        private void btnGalName_Click(object sender, EventArgs e)
        {
 //           _ArtistList.GalleryName = new InputBox("Enter Gallery Name:").Answer;
 //           GalleryNameChanged(_ArtistList.GalleryName);
        }

        private void lstArtists_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}