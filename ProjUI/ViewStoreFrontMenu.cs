using ProjBL;
using ProjModel;

namespace ProjUI
{
    public class ViewStoreFrontMenu : IMenu
    {
        private static StoreFront _newStore = new StoreFront();
        private IStoreBL _storeBL;
        public ViewStoreFrontMenu(IStoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        public void Display()
        {
            Console.WriteLine("-----Storefront Manager Functions-----");
            Console.WriteLine("Please select from one of the following options:");
            Console.WriteLine("[1] Check inventory at a specific store");
            Console.WriteLine("[2] Replenish inventory at a specific store");
            Console.WriteLine("[0] Back to Previous Menu");

        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "ManagerMenu";

                case "1":
                    try
                {
                Console.WriteLine("Enter the store's address of which you wish to view inventory:");
                string userStoreChoice = Console.ReadLine();
                List<StoreFront> listOfStores = _storeBL.ViewStoreInventory(userStoreChoice);
                Console.WriteLine("Below are the products at the " + listOfStores[0].Name  +" store:" );
                List<Products> listOfProducts = _storeBL.GetProductsByStore(listOfStores[0].Address);
                
                foreach(var item in listOfProducts)
                {
                    if (item.Quantity > 0)
                    {
                        Console.WriteLine(item);
                    }
                    else
                    {
                        Console.WriteLine("============================\n " + item.Name + " is not in stock right now. Consider replenishing it."); 
                    }
                    
                }

                }
                catch(System.Exception exc)
                {
                        Console.WriteLine(exc.Message);
                        IMenu.PressEnter();
                }
                IMenu.PressEnter();
                return "ManagerMenu";
    
                case "2":
                    return "ReplenishInvMenu";
              
                default:
                    Console.WriteLine("Please input a valid response");
                    IMenu.PressEnter();
                    
                    return "MainMenu";
            }
        }
    }
}