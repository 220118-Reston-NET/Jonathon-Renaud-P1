using ProjModel;

 
namespace ProjBL
{
/// <summary>
/// Business Layer is responsible for the processing of data obtained from either the database or...
/// Based on the functionality that will be done
/// </summary>
public interface ICustomerBL
{
    /// <summary>
    /// Will add a customer to the database
    /// Initial addition of customer will add some other functionality
    /// 
    /// </summary>
    /// <param name="p_customer"></param>
    /// <returns></returns>
    Customer AddCustomer(Customer p_customer);
/// <summary>
/// 
/// Will give a list of Customer objects that are related to the search name
/// </summary>
/// <param name="p_name">Name parameter used to filter customers</param>
/// <returns>Gives a filtered list of customers by name</returns>
    List<Customer> SearchCustomerByName(string p_name);
    List<Customer> SearchCustomerByAddress(string p_address);
    List<Customer> SearchCustomerByPhoneNumber(string p_phoneNumber);
    List<Customer> SearchCustomerByEmail(string p_email);

    List<Customer> GetAllCustomers();

    }
}