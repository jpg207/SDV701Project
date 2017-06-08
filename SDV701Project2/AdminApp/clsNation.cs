using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp
{
    public class clsNation
    {
        public clsNation() { }

        public int NationID { get; set; }
        public string Name { get; set; }
        public int BuildingCapacity { get; set; }

        public IList<clsShip> NationShips { get; set; }

        public override string ToString() {
            return Name + "\t" + BuildingCapacity.ToString();
        }
    }
}
