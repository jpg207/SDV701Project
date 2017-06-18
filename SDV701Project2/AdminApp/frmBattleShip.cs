namespace AdminApp
{
    public partial class frmBattleShip : frmShip
    {
        public static readonly frmBattleShip Instance = new frmBattleShip();

        private frmBattleShip() {
            InitializeComponent();
        }

        public static void Run(clsBattleShip prBattleShip) {
            Instance.SetDetails(prBattleShip);
        }

        protected override void updateForm() {
            base.updateForm();
            clsBattleShip lcShip = (clsBattleShip)this._Ship;
            txtTorpedoBulge.Text = lcShip.TorpedoBulge.ToString();
            txtHealAmount.Text = lcShip.HealAmount.ToString();
        }

        protected override void pushData() {
            base.pushData();
            clsBattleShip lcShip = (clsBattleShip)_Ship;
            lcShip.TorpedoBulge = int.Parse(txtTorpedoBulge.Text);
            lcShip.HealAmount = int.Parse(txtHealAmount.Text);
            lcShip.Type = "AdminApp.clsBattleShip, AdminApp";
        }
    }
}
