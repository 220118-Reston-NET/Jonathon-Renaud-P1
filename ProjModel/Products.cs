namespace ProjModel
{
    public class Products
    {

        public int ProdID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        private double _price;
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private string _storeFront;
        public string StoreFront
        {
            get { return _storeFront; }
            set { _storeFront = value; }
        }
        
        
        public string Description { get; set; }

        public override string ToString()
        {   
            return $"========================\nID: {ProdID}\nName: {Name}\nPrice: ${Price.ToString("0.00")}\nDescription: {Description}\nQuantity: {Quantity}";    
        }
        // possibly add Categories later. 
    }
}