using System.Collections.Generic;

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
