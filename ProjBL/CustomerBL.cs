using ProjModel;
using ProjDL;

namespace ProjBL
{
    
    public class CustomerBL : ICustomerBL
    {
        private readonly IRepository _repo;
        /// <summary>
        /// Constructor - Dependency Injection
        /// </summary>
        /// <param name="p_repo"></param>
        public CustomerBL(IRepository p_repo)
        {
            _repo = p_repo;
        }

/// <summary>
/// Will take in a Customer object, retreive all the current customers stored as a list, and add this object to that list
/// </summary>
/// <param name="p_customer"></param>
/// <returns></returns>
        public Customer AddCustomer(Customer p_customer)
        {
            return _repo.AddCustomer(p_customer);
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> listOfCust = _repo.GetAllCustomers();                                  
            
            return listOfCust;
        }

        public List<Customer> SearchCustomerByName(string p_name)
        {
            List<Customer> listOfCust = _repo.GetAllCustomers();

            return listOfCust.Where(cust => cust.Name.Contains(p_name)).ToList();

            
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
            
            return listOfCust.Where(cust => cust.Email.Equals(p_email)).ToList();
        }

    }
}