namespace ProjModel

{
    public class Customer{
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        
        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        
        // private List<string> _orders;
        // public List<string> Orders
        // {
        //     get { return _orders; }
        //     set { _orders = value; }
        // }
        
        public override string ToString()
        {
            return $"Name: {Name}\nAddress: {Address}\nEmail: {Email}\nPhone Number: {PhoneNumber}";
        }

    }

    
}