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
        public string CustName { get; set; }
        public int ShipID { get; set; }
        public string Name { get; set; }

        public override string ToString() {
            return OrderID.ToString().PadRight(20) + CustName.PadRight(25 - CustName.Length) + CustomerEmail.PadRight(25 - CustomerEmail.Length) + Price.ToString().PadRight(10) + Name.ToString().PadRight(10) + Quantity.ToString().PadRight(20);
        }
    }
}
