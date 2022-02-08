using ProjModel;
using ProjDL;

namespace ProjBL
{
    
    public class CustomerBL : ICustomerBL
    {
        private IRepository _repo;
        public CustomerBL(IRepository p_repo)
        {
            _repo = p_repo;
        }

        public Customer AddCustomer(Customer p_customer)
        {
            // NEED TO: Add functionality to check if customer already exists.
            List<Customer> listOfCust = _repo.GetAllCustomers();
            return _repo.AddCustomer(p_customer);
        }

        
        public List<Customer> SearchCustomerByName(string p_name)
        {
            List<Customer> listOfCust = _repo.GetAllCustomers();

            return listOfCust.Where(cust => cust.Name.Contains(p_name)).ToList();

            // Where looks through the collection and finds specific el or els
            // created a 'delegate' inside leftside = parameter, rightside is implementation
            // string has a method 'contains' which looks for that within the string
            // Since its a list collection -- need to convert to a list instead of an iEnmuerable
            // Using LINQ library.
            //A different way to do the same thing 'sort of', is below...
            // foreach (Customer cust in listOfCust)
            // {
            //     if (cust.Name.Contains(p_name))
            //     {

            //     }
            // }

        }

        public List<Customer> SearchCustomerByAddress(string p_address)
        {
            List<Customer> listOfCust = _repo.GetAllCustomers();

            return listOfCust.Where(cust => cust.Address.Contains(p_address)).ToList();
        }

        public List<Customer> SearchCustomerByPhoneNumber(string p_phoneNumber)
        {
            List<Customer> listOfCust = _repo.GetAllCustomers();

            return listOfCust.Where(cust => cust.PhoneNumber.Contains(p_phoneNumber)).ToList();
        }

        public List<Customer> SearchCustomerByEmail(string p_email)
        {
            List<Customer> listOfCust = _repo.GetAllCustomers();
            
            return listOfCust.Where(cust => cust.Email.Contains(p_email)).ToList();
        }

    }
}