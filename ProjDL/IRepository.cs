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
    Orders InitializeOrder(Orders p_order);
    List<Customer> GetAllCustomers();
    List<Products> GetProductsByStore(string p_address);
    List<StoreFront> GetStoreFronts();
    void UpdateInventory(int p_productID, int p_quantity, int p_storeID);
    LineItems MakeOrder(LineItems p_lineItems, int quantity, int p_storeID);
    List<Orders> GetAllOrders();
    List<Orders> GetAllOrdersByCustomer(int p_custID);
    List<Orders> GetAllOrdersByStoreAddress(int storeID);

    List<Products> GetLineItemDetails(int orderID);
    Boolean StoreQuantityIsLessThanOrdered(int choiceID, int itemOrdered, int storeID);

}
