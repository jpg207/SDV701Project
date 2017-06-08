using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            UpdateDisplay();
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

        private void UpdateDisplay()
        {
            try
            {
                lstNation.DataSource = null;
                lstNation.DataSource = clsNations.NationList;
            }
            catch(Exception e)
            {
                MessageBox.Show("Error connecting to host service. Program will now close \n" + e);
                Close();
            }
        }

        private void lstNations_DoubleClick(object sender, EventArgs e)
        {
            clsNation Nation = lstNation.SelectedItem as clsNation;
            frmNation.Run(Nation);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }
    }
}