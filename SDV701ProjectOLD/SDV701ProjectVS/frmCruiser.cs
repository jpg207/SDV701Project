

namespace SDV701ProjectVS
{
    public partial class frmCruiser : frmShip
    {
        public static readonly frmCruiser Instance = new frmCruiser();

        private frmCruiser()
        {
            InitializeComponent();
        }

        public static void Run(clsCruiser prCruiser)
        {
            Instance.SetDetails(prCruiser);
        }

        protected override void updateForm()
        {
            base.updateForm();
            clsCruiser lcShip = (clsCruiser)_Ship;
            txtWeight.Text = lcShip.Weight.ToString();
            txtMaterial.Text = lcShip.Material;
        }

        protected override void pushData()
        {
            base.pushData();
            clsSculpture lcShip = (clsCruiser)_Ship;
            lcShip.Weight = float.Parse(txtWeight.Text);
            lcShip.Material = txtMaterial.Text;
        }
    }
}
