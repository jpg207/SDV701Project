using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDV701ProjectVS
{
    class clsNationList : List<clsShip>
    {
        //private byte _SortOrder;

        public void AddShip(char prChoice) {
            clsShip lcShip = clsShip.NewShip(prChoice);
            if (lcShip != null)
            {
                Add(lcShip);
            }
        }

        public void EditAdd(int prIndex) {
            if (prIndex >= 0 && prIndex < this.Count)
            {
                clsShip lcShip = (clsShip)this[prIndex];
                lcShip.EditDetails();
            }
            else
                throw new Exception("Sorry no ship selected #" + Convert.ToString(prIndex));
        }

        public decimal GetTotalValue() {
            decimal lcTotal = 0;
            foreach (clsShip lcShip in this)
            {
                lcTotal += lcShip.Value;
            }
            return lcTotal;
        }
    }
}
