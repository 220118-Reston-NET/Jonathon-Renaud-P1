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
        
    }
}