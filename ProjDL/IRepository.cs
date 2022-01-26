using ProjModel;

namespace ProjDL;
/// <summary>
/// Data Layer Project is responsible for interacting with our database and doing CRUD operations
/// C - Create, R- Read, U - Update, D - Delete
/// It must not have any logical operation that will also manipulate the data it is grabbing. So that we have "Pristine, raw, data"
/// Data layer is like delivery man -- we don't want him to touch our food that he's delivering.
/// This is where we are going to serialize and deserialize. 
/// </summary>
public interface IRepository
{
    ///<summary>
    /// <param name="p_customer"> This is the customer object 
    /// </summary>
    // Create new object
    // can also do a boolean below
    Customer AddCustomer(Customer p_customer);

    List<Customer> GetAllCustomers();
}
