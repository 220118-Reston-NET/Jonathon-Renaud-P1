namespace ProjModel
{
    public class LineItems
    {
        public string Product { get; set; }
        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        
    }
}