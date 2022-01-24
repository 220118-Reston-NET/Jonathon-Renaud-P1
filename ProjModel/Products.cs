namespace ProjModel
{
    public class Products
    {
        public string Name { get; set; }
        private double _price;
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        
        public string Description { get; set; }
        // possibly add Categories later. 
    }
}