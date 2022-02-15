using ProjBL;
using ProjModel;

namespace ProjUI
{
    public class ViewOrderHistoryMenu : IMenu
    {
        private static Customer _newCustomer = new Customer();
        private static StoreFront _newStore = new StoreFront();
        private static Orders _newOrder = new Orders();

        private ICustomerBL _customerBL;
        private IStoreBL _storeBL;

        public ViewOrderHistoryMenu(ICustomerBL p_customerBL, IStoreBL p_storeBL)
        {
            _customerBL = p_customerBL;
            _storeBL = p_storeBL;
        } 
        public void Display()
        {
            Console.WriteLine("Order History Menu");
            Console.WriteLine("Please select from one of the following options:");
            Console.WriteLine("[1] Display all orders by customer email");
            Console.WriteLine("[2] Display all orders by store address");
            Console.WriteLine("[3] Display all items in a specific order");
            Console.WriteLine("[0] Return to previous menu");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "1":
                
                

                try
                {
                    Console.WriteLine("Please enter the email to search by:");
                    string userEmail = Console.ReadLine();
                    List<Customer> listOfCustomers = _customerBL.SearchCustomerByEmail(userEmail);
                    Console.Clear();
                    
                    Console.WriteLine("All of "+listOfCustomers[0].Name+"'s orders can be found below:");
                    List<Orders> listOfCustomerOrders = _storeBL.GetOrdersByCustomerEmail(userEmail);
                    foreach(var item in listOfCustomerOrders)
                            {
                                Console.WriteLine(item);
                            }
                    IMenu.PressEnter();
                    
                }
                catch (System.Exception exc)
                {
                    
                    Console.WriteLine(exc.Message, "Unable to retreive customer, most likely email is incorrect.");
                    IMenu.PressEnter();

                }
                return "ViewOrderHistoryMenu";
                
                case "2":
                
                

                try
                {   
                    Console.WriteLine("Please enter the address to search by:");
                    string userAddress = Console.ReadLine();
                    List<StoreFront> listOfStores = _storeBL.SearchStoreByAddress(userAddress);
                    Console.Clear();

                    Console.WriteLine("All of "+listOfStores[0].Name+"'s orders can be found below:");
                    List<Orders> listOfStoreOrders = _storeBL.GetOrdersByStoreAddress(userAddress);
                    foreach(var item in listOfStoreOrders)
                            {
                                Console.WriteLine(item);
                            }
                    IMenu.PressEnter();
                    
                }
                catch (System.Exception exc)
                {
                    
                    Console.WriteLine(exc.Message, "Unable to retreive storefront, most likely address is incorrect.");
                    IMenu.PressEnter();

                }                return "ViewOrderHistoryMenu";

                case "3":
                Console.WriteLine("Please enter the order number you wish to see line items for:");
                int userOrder = Convert.ToInt32(Console.ReadLine());
                List<Products> listOfProducts = _storeBL.GetProductsInOrder(userOrder);
                foreach (var item in listOfProducts)
                {
                    Console.WriteLine(item);                    
                }
                IMenu.PressEnter();
                return "ViewOrderHistoryMenu";

                case "0":
                return "ManagerMenu";
                
                default:
                Console.WriteLine("Please enter a valid selection");
                IMenu.PressEnter();
                return "ViewOrderHistoryMenu";
            }
        }
    }
}