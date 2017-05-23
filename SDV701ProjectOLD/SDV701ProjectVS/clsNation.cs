using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDV701ProjectVS
{
    class clsNation
    {
        private string _Name;

        private clsShipsList _ShipsList;
        private clsNationList _NationList;

        public clsNation() { }

        public clsNation(clsNationList prNationList)
        {
            _ShipsList = new clsShipsList();
            _NationList = prNationList;
        }

        public bool IsDuplicate(string prNationList)
        {
            return _NationList.ContainsKey(prNationList);
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public decimal TotalValue
        {
            get { return _ShipsList.GetTotalValue(); /* was: _TotalValue;*/ }
        }

        public clsNationList NationList
        {
            get { return _NationList; }
        }

        public clsShipsList ShipsList
        {
            get { return _ShipsList; }
        }
    }
}
