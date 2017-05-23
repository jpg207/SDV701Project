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
    public sealed partial class frmNation : Form
    {
        private static readonly frmNation _Instance = new frmNation();

        //        private clsShipsList _ShipsList = new clsShipsList();

        public delegate void Notify(string prGalleryName);

        public event Notify GalleryNameChanged;

        private frmNation() {
            InitializeComponent();
        }

        public static frmNation Instance
        {
            get { return frmNation._Instance; }
        }

        private void updateTitle(string prGalleryName) {
            if (!string.IsNullOrEmpty(prGalleryName))
                Text = "Gallery (v3 C) - " + prGalleryName;
        }

        public void UpdateDisplay() {
            lstNations.DataSource = null;
            lstNations.DataSource = Program.SvcClient.GetShipsNames();
            //           string[] lcDisplayList = new string[_ShipsList.Count];
            //           _ShipsList.Keys.CopyTo(lcDisplayList, 0);
            //           lstShipss.DataSource = lcDisplayList;
            //           lblValue.Text = Convert.ToString(_ShipsList.GetTotalValue());
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            try
            {
                frmShipsList.Run(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error adding new Ship");
            }
        }

        private void lstShips_DoubleClick(object sender, EventArgs e) {
            string lcKey;

            lcKey = Convert.ToString(lstNations.SelectedItem);
            if (lcKey != null)
                try
                {
                    frmShipsList.Run(lstNations.SelectedItem as string);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "This should never occur");
                }
        }

        private void btnQuit_Click(object sender, EventArgs e) {
            try
            {
                //               _ShipsList.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File Save Error");
            }
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            string lcKey;

            lcKey = Convert.ToString(lstNations.SelectedItem);
            if (lcKey != null && MessageBox.Show("Are you sure?", "Deleting Ship", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    clsNationList lcShip = Program.SvcClient.GetArtist(lcKey);
                    Program.SvcClient.DeleteArtist(lcArtist);
                    lstNations.ClearSelected();
                    UpdateDisplay();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error deleting Ship");
                }
        }

        private void frmMain_Load(object sender, EventArgs e) {
            try
            {
                //               _ShipsList = clsShipsList.RetrieveShipsList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File retrieve error");
            }
            UpdateDisplay();
            GalleryNameChanged += new Notify(updateTitle);
            //           GalleryNameChanged(_ShipsList.GalleryName);
            //updateTitle(_ShipsList.GalleryName);
        }

        private void btnGalName_Click(object sender, EventArgs e) {
            //           _ShipsList.GalleryName = new InputBox("Enter Gallery Name:").Answer;
            //           GalleryNameChanged(_ShipsList.GalleryName);
        }

        private void lstShipss_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}
