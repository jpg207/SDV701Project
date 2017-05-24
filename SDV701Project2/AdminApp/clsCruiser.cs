using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp
{
    public class clsCruiser : clsShip
    {
        private int _TorpTubes;
        private int _PlaneType;

        public delegate void LoadCruiserFormDelegate(clsCruiser prCruiser);
        public static LoadCruiserFormDelegate LoadCruiserForm;

        public int TorpTubes
        {
            get { return _TorpTubes; }

            set { _TorpTubes = value; }
        }

        public int PlaneType
        {
            get { return _PlaneType; }

            set { _PlaneType = value; }
        }

        public override void EditDetails() {
            LoadCruiserForm(this);
        }
    }
}
