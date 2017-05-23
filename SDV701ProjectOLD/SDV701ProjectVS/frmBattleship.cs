

namespace SDV701ProjectVS
{
    public partial class frmBattleship : frmShip
    {
        private static readonly frmBattleship Instance = new frmBattleship();

        private frmBattleship() {
            InitializeComponent();
        }

        public static void Run(clsBattleShip prBattleShip) {
            Instance.SetDetails(prBattleShip);
        }

        protected override void updateForm() {
            base.updateForm();
            clsBattleShip lcShip = (clsBattleShip)_Ship;
            txtWidth.Text = lcShip.Width.ToString();
            txtHeight.Text = lcShip.Height.ToString();
            txtType.Text = lcShip.Type;
        }

        protected override void pushData() {
            base.pushData();
            clsBattleShip lcShip = (clsBattleShip)_Ship;
            lcShip.Width = float.Parse(txtWidth.Text);
            lcShip.Height = float.Parse(txtHeight.Text);
            lcShip.Type = txtType.Text;
        }
    }
}
