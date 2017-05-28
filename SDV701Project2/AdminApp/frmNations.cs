using Newtonsoft.Json;
using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class frmNations : Form
    {
        private static readonly frmNations _Instance = new frmNations();


        public delegate void Notify(string prNationName);

        private frmNations()
        {
            InitializeComponent();
        }

        public static frmNations Instance
        {
            get { return _Instance; }
        }

        private void updateTitle(string prNationName)
        {
            if (!string.IsNullOrEmpty(prNationName))
                Text = "Nation - " + prNationName;
        }

        private async void UpdateDisplay()
        {
            //var json_data = string.Empty;
            //using (var w = new WebClient())
            //        json_data = w.DownloadString("http://localhost/SDV701Project/Server/SelectAllNations");
            //    MessageBox.Show(json_data);
            try
            {
                lstNation.DataSource = null;
                //SET DATASORCE HERE FOR NATIONS
                lstNation.DataSource = await clsJSONConnection.GetAllNations();
                //clsJSONConnection.GetNationNamesAsync();
            }
            catch(Exception e)
            {
                MessageBox.Show("Error connecting to host service. Program will now close \n" + e);
                Close();
            }
        }

        private void lstNations_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstNation.SelectedItem);
            if (lcKey != null)
                try
                {
                    lcKey = Regex.Match(lcKey, @"^[^0-9]*").Value;
                    frmNation.Run(lcKey);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "This should never occur");
                }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
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