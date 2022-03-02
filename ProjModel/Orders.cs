namespace ProjModel
{
    public class Orders
    {
        private int _orderID;

        public int OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }
        
        
        private int _customerID;
        public int CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }
        
        private int _storeID;
        public int StoreID
        {
            get { return _storeID; }
            set { _storeID = value; }
        }
              
        private List<Products> _LineItems;
        public List<Products> LineItems
        {
            get { return _LineItems; }
            set { _LineItems = value; }
        }
        
        private string _storeFront;
        public string StoreFront
        {
            get { return _storeFront; }
            set { _storeFront = value; }
        }
        
        private double _totalPrice;
        public double TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

      
        
        
    }
}