namespace ProjModel
{
    public class Orders
    {
        public List<string> LineItems { get; set; }
        public string StoreFront { get; set; }
        private double _totalPrice;
        public double TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }
        
    }
}