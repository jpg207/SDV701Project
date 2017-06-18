using System.Runtime.Serialization;

namespace AdminApp
{
    [DataContract]
    [KnownType(typeof(clsCruiser))]
    [KnownType(typeof(clsBattleShip))]
    public abstract class clsShip
    {
        public clsShip() {}

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
        [DataMember]
        public int ShipID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public string DateOfModification { get; set; }
        [DataMember]
        public int StockQuanitiy { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public int NationID { get; set; }

    }
}
