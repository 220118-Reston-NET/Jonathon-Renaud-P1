using ProjModel;
using ProjDL;

namespace ProjBL
{
    
    public class CustomerBL : ICustomerBL
    {
        // This is dependency injection... but I don't understand it
        private IRepository _repo;
        public CustomerBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        // Random rand = new Random();
        // add some functionality here to manipulate the incoming objects
        // some return here... check file.
    }
}