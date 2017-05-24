using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp
{
    public abstract class clsShip
    {
        private string _Name;
        private DateTime _DateOfModification = DateTime.Now;
        private decimal _Price;
        private int _StockQuanitiy;
        private string _Type;
        private string _ArtistName;


        public clsShip() {
            EditDetails();
        }

        public static readonly string FACTORY_PROMPT = "Enter B for BattleShip or C for Cruiser";

        public static clsShip NewShip(char prChoice) {
            switch (char.ToUpper(prChoice))
            {
                case 'B': return new clsBattleShip();
                case 'C': return new clsCruiser();
                default: return null;
            }
        }

        public abstract void EditDetails();

        public override string ToString() {
            return _Name + "\t" + DateOfModification.ToShortDateString();
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public DateTime DateOfModification
        {
            get{return _DateOfModification;}
            set{_DateOfModification = value;}
        }

        public decimal Price
        {
            get{return _Price;}
            set{_Price = value;}
        }

        public int StockQuanitiy
        {
            get{return _StockQuanitiy;}
            set{_StockQuanitiy = value;}
        }

        public string Type
        {
            get{return _Type;}
            set{_Type = value;}
        }

        public string ArtistName
        {
            get{return _ArtistName;}
            set{_ArtistName = value;}
        }
    }
}
