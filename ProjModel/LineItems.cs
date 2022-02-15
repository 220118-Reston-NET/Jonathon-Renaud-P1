namespace ProjModel
{
    public class LineItems
    {
        public int ProductID { get; set; }
        private int _productQuantity;
        public int ProductQuantity
        {
            get { return _productQuantity; }
            set { _productQuantity = value; }
        }

         public override string ToString()
        {
            return $"========================\nID: {ProductID}\nQuantity: {ProductQuantity}\n";
        }
        
    }
}