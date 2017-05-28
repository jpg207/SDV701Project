using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp
{
    public class clsOrder
    {
        public clsOrder() { }

        public int OrderID { get; set; }
        public string DateOfOrder { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string CustomerEmail { get; set; }
        public string TransactionType { get; set; }
        public int ShipID { get; set; }

        public override string ToString() {
            return OrderID.ToString() + "\t" + CustomerEmail + "\t" + Quantity.ToString() + "\t" + Price.ToString() + "\t" + DateOfOrder + "\t" + TransactionType + "\t" + ShipID.ToString();
        }
    }
}
