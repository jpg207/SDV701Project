using System.Runtime.Serialization;

namespace AdminApp
{
    [DataContract]
    public class clsBattleShip : clsShip
    {

        public delegate void LoadBattleShipFormDelegate(clsBattleShip prbattleship);
        public static LoadBattleShipFormDelegate LoadBattleShipForm;

        [DataMember]
        public int TorpedoBulge { get; set; }
        [DataMember]
        public int HealAmount { get; set; }

        public override void EditDetails() {
            LoadBattleShipForm(this);
        }

        public override string ToString() {
            return Name + "\t" + Price.ToString() + "\t" + DateOfModification + "\t" + StockQuanitiy + "\t" + Type;
        }
    }
}
