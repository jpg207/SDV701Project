using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp
{
    [DataContract]
    public class clsCruiser : clsShip
    {

        public delegate void LoadCruiserFormDelegate(clsCruiser prCruiser);
        public static LoadCruiserFormDelegate LoadCruiserForm;

        [DataMember]
        public string PlaneType { get; set; }
        [DataMember]
        public string TorpedoTubeCount { get; set; }

        public override void EditDetails() {
            LoadCruiserForm(this);
        }

        public override string ToString() {
            return Name + "\t" + Price.ToString() + "\t" + DateOfModification + "\t" + StockQuanitiy;
        }
    }
}
