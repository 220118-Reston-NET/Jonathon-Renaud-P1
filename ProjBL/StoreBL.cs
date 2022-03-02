
using ProjDL;
using ProjModel;

namespace ProjBL
{
    public class StoreBL : IStoreBL
    {
    private readonly IRepository _repo;

    public StoreBL(IRepository p_repo)
    {
        _repo = p_repo;
    }

        public List<Orders> GetOrdersByCustomerEmail(string p_searchCriteria)
        {
            List<Customer> listOfCustomer = _repo.GetAllCustomers();
            

            var found = listOfCustomer.Find(p => p.Email == p_searchCriteria);
            List<Orders> listOfOrders = _repo.GetAllOrdersByCustomer(found.CustID);
                    if(found != null)
                    {
                        //validation process using LINQ Library
                        return listOfOrders
                                .Where(customer => customer.CustomerID.Equals(found.CustID))
                                .ToList();
                        
                    }
                    else
                    {
                        throw new Exception("A customer with this email has not been found.");
                    }
        }

        public List<StoreFront> SearchStoreByAddress(string p_address)
        {
            List<StoreFront> listOfStores = _repo.GetStoreFronts();

            return listOfStores.Where(p => p.Address.Contains(p_address)).ToList();
        }

        public List<Orders> GetOrdersByStoreAddress(string p_searchCriteria)
        {
            List<StoreFront> listOfStores = _repo.GetStoreFronts();
            

            var found = listOfStores.Find(StoreFront => StoreFront.Address == p_searchCriteria);
            List<Orders> listOfOrders = _repo.GetAllOrdersByStoreAddress(found.StoreID);
                    if(found != null)
                    {
                        //validation process using LINQ Library
                        return listOfOrders
                                .Where(StoreFront => StoreFront.StoreID.Equals(found.StoreID))
                                .ToList();
                    }
                    else
                    {
                        throw new Exception("A customer with this email has not been found.");
                    }
        }

        public List<Products> GetProductsByStore(string p_address)
        {
            return _repo.GetProductsByStore(p_address);

        }

        public LineItems MakeOrder(LineItems p_lineItems, int quantity, int p_storeID)
        {
            return _repo.MakeOrder(p_lineItems, quantity, p_storeID);
        }

        public Orders InitializeOrder(Orders p_order)
        {
            return _repo.InitializeOrder(p_order);
        }

        public void UpdateInventory(int p_productID, int p_quantity, int p_storeID)
        {
            _repo.UpdateInventory(p_productID, p_quantity, p_storeID);
        }

        

        public List<Products> ViewCurrentOrder(int p_productID, string p_address)
        {
            List<Products> listOfItemsInOrder = _repo.GetProductsByStore(p_address);
            
            return listOfItemsInOrder
                    .Where(product => product.ProdID.Equals(p_productID))
                    .ToList();
        }

        public List<StoreFront> ViewStoreInventory(string p_address)
        {
            List<StoreFront> listOfStores = _repo.GetStoreFronts();
            var found = listOfStores.Find(p => p.Address.Contains(p_address));
            if(found != null)
            {
                return listOfStores
                    .Where(p => p.Address.Contains(p_address))
                    .ToList();
            }
            else
            {
                throw new Exception("No store has been found.");
            }
        }

        public List<Products> GetProductsInOrder(int p_orderID)
        {
            return _repo.GetLineItemDetails(p_orderID);
        }

        public bool StoreQuantityIsLessThanOrdered(int p_id, int p_quantity, int p_storeID)
        {
            return _repo.StoreQuantityIsLessThanOrdered(p_id, p_quantity, p_storeID);
        }

        public List<StoreFront> GetAllStores()
        {
            return _repo.GetStoreFronts();
        }

        

        public bool IsAdmin(string p_email, string p_pass)
        {
            
            try
            {
                Employee emp = new Employee();
                emp = _repo.GetAllEmployees().Where(emp => emp.Email.Equals(p_email) && emp.Password.Equals(p_pass)).FirstOrDefault();
                if(emp != null){
                return emp.IsAdmin;
                }
                else{
                
                    throw new Exception("USER IS NOT AUTHORIZED!! Email and password combination were incorrect.");
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }

            
        }

        public Orders AddOrder(Orders p_order)
        {
            return _repo.AddOrder(p_order);
        }




    }
}