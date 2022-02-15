namespace ProjModel
{
    public class StoreFront
    {
        public int StoreID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        private List<Products> _products;

        public List<Products> Products
        {
            get { return _products; }
            set { _products = value; }
        }
        private List<Orders> _orders;

        public List<Orders> Orders
        {
            get {return _orders;}
            set { _orders = value; }
        }
        

        public override string ToString()
        {   
            string items = "=================\n";
            foreach(Products item in _products)
            {  
                items +=  item + "\n=================\n";
            }

            return items;
                
        }
    }
}