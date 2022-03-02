using System.Text.Json;
using ProjModel;

namespace ProjDL
{
    public class Repository : IRepository
    {

        private readonly string _filepath = "../ProjDL/Database/";
        private string _jsonString;

        public Customer AddCustomer(Customer p_customer)
        {
            string path = _filepath + "Customer.json";

            List<Customer> listOfCust = GetAllCustomers();
            listOfCust.Add(p_customer);

            _jsonString = JsonSerializer.Serialize(listOfCust, new JsonSerializerOptions {WriteIndented = true});

            File.WriteAllText(path, _jsonString);
            
            return p_customer;

        }

        public Orders AddOrder(Orders p_order)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            _jsonString = File.ReadAllText(_filepath + "Customer.json");
            // need to handle if there is no .json created yet. try/catch block creating new object if not found. 
            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
        }

        public List<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public List<Orders> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public List<Orders> GetAllOrdersByCustomer(int p_custID)
        {
            throw new NotImplementedException();
        }

        public List<Orders> GetAllOrdersByStoreAddress(int storeID)
        {
            throw new NotImplementedException();
        }

        public List<Products> GetLineItemDetails(int orderID)
        {
            throw new NotImplementedException();
        }

        public List<Products> GetProductsByStore(string p_address)
        {
            throw new NotImplementedException();
        }

        public List<StoreFront> GetStoreFronts()
        {
            throw new NotImplementedException();
        }

        public Orders InitializeOrder(Orders p_order)
        {
            throw new NotImplementedException();
        }

        public LineItems MakeOrder(LineItems p_lineItems, int quantity, int p_storeID)
        {
            throw new NotImplementedException();
        }

        public bool StoreQuantityIsLessThanOrdered(int choiceID, int itemOrdered, int storeID)
        {
            throw new NotImplementedException();
        }

    

        public void UpdateInventory(int p_productID, int p_quantity, int p_storeID)
        {
            throw new NotImplementedException();
        }
    }
}