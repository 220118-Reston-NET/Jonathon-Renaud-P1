using System.Text.Json;

namespace ProjDL
{
    public class Repository : IRepository
    {

        private string _filepath = "../ProjDL/Database/";
        private string _jsonString;

        // public Customer AddCustomer(Customer p_customer)
        // {
        //     string path = _filepath + "Customer.json";
        //     _jsonString = JsonSerializer.Serialize(p_customer);
        //     File.WriteAllText(path, _jsonString);
        //     return p_customer;

        // }
    }
}