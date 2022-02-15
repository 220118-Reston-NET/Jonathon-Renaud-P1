namespace ProjModel
{
    public class Orders
    {
        public int OrderID;
        public int CustomerID;
        public int StoreID;
        public List<LineItems> LineItems { get; set; }
        public string StoreFront { get; set; }
        private double _totalPrice;
        public double TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        public override string ToString()
        {
            return $"=====================\nOrder ID: {OrderID}\nCustomer ID: {CustomerID}\nStore ID: {StoreID}\nTotal Spent: ${_totalPrice.ToString("0.00")}\n=====================\n";
        }
        
        
    }
}