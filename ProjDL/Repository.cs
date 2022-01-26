using System.Text.Json;
using ProjModel;

namespace ProjDL
{
    public class Repository : IRepository
    {

        private string _filepath = "../ProjDL/Database/";
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

        public List<Customer> GetAllCustomers()
        {
            _jsonString = File.ReadAllText(_filepath + "Customer.json");
            // need to handle if there is no .json created yet. try/catch block creating new object if not found. 
            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
        }
    }
}