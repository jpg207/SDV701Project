using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class frmCruiser : frmShip
    {
        public static readonly frmCruiser Instance = new frmCruiser();

        private frmCruiser() {
            InitializeComponent();
        }

        public static void Run(clsCruiser prCruiser) {
            Instance.SetDetails(prCruiser);
        }

        protected override void updateForm() {
            base.updateForm();
            clsCruiser lcShip = (clsCruiser)this._Ship;
            txtPlaneType.Text = lcShip.PlaneType;
            txtTorpTubes.Text = lcShip.TorpedoTubeCount;
        }

        protected override void pushData() {
            base.pushData();
            clsCruiser lcShip = (clsCruiser)_Ship;
            lcShip.PlaneType = txtPlaneType.Text;
            lcShip.TorpedoTubeCount = txtTorpTubes.Text;
        }
    }
}
