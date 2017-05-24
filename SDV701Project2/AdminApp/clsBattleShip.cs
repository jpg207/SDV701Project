using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp
{
    public class clsBattleShip : clsShip
    {
        private int _TorpedoBulge;
        private int _HealAmount;

        public delegate void LoadBattleShipFormDelegate(clsBattleShip prbattleship);
        public static LoadBattleShipFormDelegate LoadBattleShipForm;

        public int TorpedoBulge
        {
            get{return _TorpedoBulge;}

            set{_TorpedoBulge = value;}
        }

        public int HealAmount
        {
            get{return _HealAmount;}

            set{_HealAmount = value;}
        }

        public override void EditDetails() {
            LoadBattleShipForm(this);
        }
    }
}
