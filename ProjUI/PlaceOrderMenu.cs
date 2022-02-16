using ProjBL;
using ProjModel;

namespace ProjUI
{
    
    public class PlaceOrderMenu : IMenu
    {

        private static Customer _newCustomer = new Customer();
        private static Orders _newOrder = new Orders();
        private static StoreFront _newStoreFront = new StoreFront();
        private LineItems _newLinesItem = new LineItems();

        private ICustomerBL _customerBL;
        private IStoreBL _storeBL;

        public PlaceOrderMenu(ICustomerBL p_customerBL, IStoreBL p_storeBL)
        {
            _customerBL = p_customerBL;
            _storeBL = p_storeBL;
        }  
        public void Display()
        {
            Console.WriteLine("Welcome to Le Magasin de Renaud!");
            Console.WriteLine("Please select from one of the following options:");
            Console.WriteLine("[1] Place order");
            Console.WriteLine("[2] Review previous orders");
            Console.WriteLine("[3] Display all items in a specific past order");
            Console.WriteLine("[4] Display all store locations");
            Console.WriteLine("[0] Return to previous menu");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "1":
                Log.Information("User chose to place order: asking for email");
                Console.WriteLine("Enter customer email");
                string userEmail = Console.ReadLine();

                try 
                {
                    List<Customer> listOfCustomers = _customerBL.SearchCustomerByEmail(userEmail);
                    Console.WriteLine("Welcome back, "+ listOfCustomers[0].Name + "!");
                }
                catch(SystemException exc)
                {
                    Console.WriteLine(exc +"\n Email was most likely incorrect. Going back to menu.");
                    IMenu.PressEnter();
                    return "PlaceOrder";
                }
                Log.Information("Found the corresponding customer: asking user for store address");
                Console.WriteLine("Which store location do you wish to shop at today? (enter address)");

                string userStoreChoice = Console.ReadLine();
                
                

                try 
                {
                    List<StoreFront> listOfStores = _storeBL.ViewStoreInventory(userStoreChoice);
                    Console.WriteLine("Displaying products at: "+listOfStores[0].Name+" Store");
                    List<Products> listOfStoreProducts = _storeBL.GetProductsByStore(listOfStores[0].Address);

                    foreach (var item in listOfStoreProducts)
                    {
                        if (item.Quantity > 0)
                    {
                        Console.WriteLine(item);
                    }
                    else
                    {
                        Console.WriteLine("============================\n " + item.Name + " is not in stock right now. UNAVAILABLE."); 
                    }
                    }
                }
                catch(System.Exception exc)
                {
                    Log.Warning("Something went wrong while trying to display items at specific location");
                    Console.WriteLine(exc +"\n Something happened, going back to previous menu.");
                    IMenu.PressEnter();
                    return "PlaceOrder";

                }
                Log.Information("Displayed items at the selected store to customer, asking for next option");
                List<LineItems> itemsInCart = new List<LineItems>();
                bool userWantsToShop = true;
                while(userWantsToShop)
                {
                    Console.WriteLine("\nPlease select one:");
                    Console.WriteLine("[1] Add an item to cart");
                    Console.WriteLine("[2] View current cart");
                    Console.WriteLine("[3] Finish shopping and check out");
                    string shoppingChoice = Console.ReadLine();
                    List<StoreFront> listOfStores2 = _storeBL.ViewStoreInventory(userStoreChoice);


                    switch(shoppingChoice)
                    {
                        case "1":
                            try
                            {
                                List<StoreFront> listOfStores3 = _storeBL.ViewStoreInventory(userStoreChoice);
                                int storeID = listOfStores3[0].StoreID;

                                Log.Information("User chose to add an item to cart: asking for product id");
                                Console.WriteLine("Please select an item ID to add to cart");
                                int choiceID = Convert.ToInt32(Console.ReadLine());

                                Log.Information("Asking user for amount to purchase");
                                Console.WriteLine("Please enter how many you wish to purchase:");
                                int quantitySelected = Convert.ToInt32(Console.ReadLine());

                                if(_storeBL.StoreQuantityIsLessThanOrdered(choiceID, quantitySelected, storeID)){

                                LineItems _newLineItem = new LineItems();
                                _newLineItem.ProductID = choiceID;
                                _newLineItem.ProductQuantity = quantitySelected;

                                itemsInCart.Add(_newLineItem);
                                }
                                else
                                {
                                    Log.Warning("User tried to order more than was available.");
                                    Console.WriteLine("The quantity you are trying to order is more than available");
                                    IMenu.PressEnter();
                                }
                            }
                            catch (System.Exception exc)
                            {
                                Log.Warning("Something wrong happened.");
                                Console.WriteLine(exc.Message + "Something went wrong...");
                                IMenu.PressEnter();
                            }
                        break;

                        case "2":
                                try
                                {Console.WriteLine("Please look over your current cart");

                                int keyValueID = 0;
                                double totalSpent = 0;
                                Log.Information("User chose to review cart: displaying cart to user");
                                List<StoreFront> listOfStores = _storeBL.ViewStoreInventory(userStoreChoice);
                                List<Products> listOfStoreProducts = _storeBL.GetProductsByStore(listOfStores[0].Address);

                                foreach(var itemInOrder in itemsInCart)
                                {
                                    List<Products> listOfItemsOrdered = _storeBL.ViewCurrentOrder(itemInOrder.ProductID, listOfStores[0].Address);
                                        foreach(var items in listOfItemsOrdered)
                                        {
                                            int itemNumber = keyValueID + 1;
                                            Console.WriteLine("\nItem " + itemNumber + "\nName: " + items.Name + "\nPrice: $" + items.Price.ToString("0.00") + "\nAmount in your cart: " + itemInOrder.ProductQuantity);
                                            
                                            keyValueID ++;
                                            totalSpent = totalSpent + (items.Price * itemInOrder.ProductQuantity);
                                            
                                        }              
                                }
                                Console.WriteLine("$"+totalSpent.ToString("0.00") + " is your current total.");
                                IMenu.PressEnter();
                                }
                                catch(System.Exception exc)
                                {
                                    Log.Warning("Something went wrong.");
                                    Console.WriteLine(exc.Message);
                                    IMenu.PressEnter();
                                }
                                break;
                        
                        case "3":
                                userWantsToShop = false;
                                List<Customer> listOfCustomers = _customerBL.SearchCustomerByEmail(userEmail);
                                List<StoreFront> listOfStores4 = _storeBL.ViewStoreInventory(userStoreChoice);
                                List<Products> listOfStoreProducts2 = _storeBL.GetProductsByStore(listOfStores4[0].Address);
                                Log.Information("User chose to check out: finalizing order");
                                    try
                                    {Console.WriteLine("Finalizing order...\n");

                                    int keyValueID = 0;
                                    double totalSpent = 0;

                                    

                                    foreach(var itemInOrder in itemsInCart)
                                    {
                                        List<Products> listOfItemsOrdered = _storeBL.ViewCurrentOrder(itemInOrder.ProductID, listOfStores2[0].Address);
                                            foreach(var items in listOfItemsOrdered)
                                            {
                                                int itemNumber = keyValueID + 1;
                                                Console.WriteLine("\nItem " + itemNumber + "\nName: " + items.Name + "\nPrice: $" + items.Price.ToString("0.00") + "\nAmount in your cart: " + itemInOrder.ProductQuantity);
                                                
                                                keyValueID ++;
                                                totalSpent = totalSpent + (items.Price * itemInOrder.ProductQuantity);
                                                
                                            }              
                                    }
                                    Console.WriteLine("$"+totalSpent.ToString("0.00") + " is your final total.");
                                    
                                    _newOrder.CustomerID = listOfCustomers[0].CustID;
                                    _newOrder.StoreID = listOfStores2[0].StoreID;
                                    _newOrder.TotalPrice = totalSpent;
                                    _newOrder.LineItems = itemsInCart;
                                    
                                    _storeBL.InitializeOrder(_newOrder);

                                    foreach (var item in itemsInCart)
                                    {
                                        _storeBL.MakeOrder(item, _newOrder.OrderID, listOfStores2[0].StoreID);
                                    }
                                    Log.Information("Order "+_newOrder.OrderID+" was made successfully");
                                    }
                                    catch(System.Exception exc)
                                    {
                                        Log.Warning("Something went wrong finalizing the order");
                                        Console.WriteLine(exc.Message);
                                        IMenu.PressEnter();
                                    }

                                

                                break;


                        default:
                                userWantsToShop = false;
                                Log.Warning("Something went wrong...on the place order menu");
                                Console.WriteLine("Invalid choice, returning to previous menu");
                                break;
                                
                    }}
                IMenu.PressEnter();
                return "PlaceOrder";

                case "2": 
                try
                {
                    Log.Information("User chose to view previous orders: asking for email.");
                    Console.WriteLine("Please enter the email to search by:");
                    string userEmail2 = Console.ReadLine();
                    List<Customer> listOfCustomers = _customerBL.SearchCustomerByEmail(userEmail2);
                    Console.Clear();
                    
                    Console.WriteLine("All of "+listOfCustomers[0].Name+"'s orders can be found below:");
                    List<Orders> listOfCustomerOrders = _storeBL.GetOrdersByCustomerEmail(userEmail2);
                    foreach(var item in listOfCustomerOrders)
                            {
                                Console.WriteLine(item);
                            }
                    Log.Information("Previous orders by email search are displayed to user");
                    IMenu.PressEnter();
                    
                }
                catch (System.Exception exc)
                {
                    Log.Warning("Something went wrong.. on the view previous orders option");
                    Console.WriteLine(exc.Message, "Unable to retreive customer, most likely email is incorrect.");
                    IMenu.PressEnter();

                }
                return "PlaceOrder";

                case "3":
                try
                {
                Log.Information("User wants to see specific items in an order: asking for order number");
                Console.WriteLine("Please enter the order number you wish to see line items for:");
                int userOrder = Convert.ToInt32(Console.ReadLine());
                List<Products> listOfProducts = _storeBL.GetProductsInOrder(userOrder);
                foreach (var item in listOfProducts)
                {
                    Console.WriteLine(item);                    
                }
                IMenu.PressEnter();
                }
                catch(System.Exception exc)
                {
                    Log.Warning("Something went wrong on the view products in an order option");
                    Console.WriteLine(exc);
                    IMenu.PressEnter();
                }
                return "PlaceOrder";

                case "4":
                try
                {
                    Log.Information("User wants to view all store locations");
                    List<StoreFront> listOfStores = _storeBL.GetAllStores();

                    foreach (var item in listOfStores)
                    {
                        Console.WriteLine("Name: "+item.Name+"\n"+"Store ID: " +item.StoreID+"\n"+"Address: "+item.Address+"\n===========================\n");
                    }

                }
                catch (System.Exception exc)
                {
                    
                    Log.Warning("User was unable to view the store inventory");
                    Console.WriteLine(exc.Message);
                }

                IMenu.PressEnter();
                return "PlaceOrder";

                case "0":
                Log.Information("User chose to go back to main menu");
                return "MainMenu";
                default:
                Log.Warning("User had a bad input, returned to same menu (Placeordermenu)");
                return "PlaceOrder";
                
                

            
        }
    }
}}