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
        
        

       
    }
}