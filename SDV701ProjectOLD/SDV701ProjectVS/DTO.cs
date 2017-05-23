using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDV701ProjectVS
{
    public abstract partial class clsShip
    {
       public static readonly string FACTORY_PROMPT = "Enter C for Cruiser or B for BattleShip";

        public static clsShip NewShip(char prChoice) {
            switch (char.ToUpper(prChoice))
            {
                case 'C': return new clsCruiser();
                case 'B': return new clsBattleShip();
                default: return null;
            }
        }

        public override string ToString() {
            return Name + "\t" + Date.ToShortDateString();
        }

        public abstract void EditDetails();

        public clsShip MapToEntity() {
            clsShip lcShipDTO = GetEntity();
            lcShipDTO.Name = Name;
            lcShipDTO.Date = Date;
            lcShipDTO.Value = Value;
            lcShipDTO.ArtistName = ArtistName;
            return lcShipDTO;
        }
        protected abstract clsShip GetEntity();

    }

    public partial class clsCruiser : clsShip
    {
        public delegate void LoadCruiserFormDelegate(clsCruiser prCruiser);
        public static LoadCruiserFormDelegate LoadCruiserForm;

        public override void EditDetails() {
            LoadCruiserForm(this);
        }
        protected override clsShip GetEntity() {
            return new clsCruiser
            { Width = this.Width, Height = this.Height, Type = this.Type };
        }
    }

    public partial class clsBattleShip : clsShip
    {
        public delegate void LoadBattleShipFormDelegate(clsBattleShip prBattleShip);
        public static LoadBattleShipFormDelegate LoadBattleShipForm;

        public override void EditDetails() {
            LoadBattleShipForm(this);
        }

        protected override clsShip GetEntity() {
            return new clsBattleShip
            { Material = this.Material, Weight = this.Weight };
        }
    }
}
