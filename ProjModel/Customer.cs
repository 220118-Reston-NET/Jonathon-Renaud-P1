namespace ProjModel

{
    public class Customer{
        public int CustID { get; set; }
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
        
        // private List<Orders> _orders;
        // public List<Orders> Orders
        // {
        //     get { return _orders; }
        //     set { _orders = value; }
        // }

        public Customer()
        {
            Name = "";
            Address = "";
            Email = "";
            PhoneNumber = "";
            

        }
        
        // public override bool Equals(object o)
        // {
        //     if(this == o) return true;
        //     if (o == null || GetType() != o.GetType()) return false;
        //     Customer customer = new Customer();
        //     return object.Equals(CustID, customer.CustID) && object.Equals(Name, customer.Name) && object.Equals(Address, customer.Address) && object.Equals(Email, customer.Email) && object.Equals(PhoneNumber, customer.PhoneNumber) && object.Equals(Orders, customer.Orders);
        // }

        // public override int GetHashCode()
        // {
        //     return base.GetHashCode(CustID, Name, Address, Email, PhoneNumber, Orders);
        // }

        public override string ToString()
        {
            return $"Name: {Name}\nAddress: {Address}\nEmail: {Email}\nPhone Number: {PhoneNumber}";
        }

        

    }

    
}