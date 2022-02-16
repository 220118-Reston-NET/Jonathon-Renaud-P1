using ProjBL;
using ProjModel;

namespace ProjUI
{
    public class ReplenishInvMenu : IMenu
    {
        private static StoreFront _newStore = new StoreFront();
        private IStoreBL _storeBL;
        
        public ReplenishInvMenu(IStoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }

        public void Display()
        {
           Console.WriteLine("Inventory Menu at Le Magasin de Renaud! \n ===================================");
            Console.WriteLine("Please select from one of the following options:");
            Console.WriteLine("[1] Update inventory at a store");
            Console.WriteLine("[2] View current inventory levels at a store");
            Console.WriteLine("[3] Show all current store locations");
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
                Log.Information("User wants to update/replenish inventory and is being asked for store address");
                Console.WriteLine("Enter the store location address you wish to replenish:");
                string userStoreChoice = Console.ReadLine();
                List<StoreFront> listOfStores = _storeBL.ViewStoreInventory(userStoreChoice);
                List<Products> listOfProducts = _storeBL.GetProductsByStore(listOfStores[0].Address);
                foreach(var item in listOfProducts)
                {
                    Console.WriteLine(item);
                    
                }
                Log.Information("Store was successfully found, items are being displayed to user and user is being asked which product to replenish");
                Console.WriteLine("Above are the products at this store "+ listOfStores[0].Name  + ", which do you wish to replenish? ( Enter ID) ");
            
                int productReplenishID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("How many units do you want to add to the quantity?");
                int amountToAddToInventory = Convert.ToInt32(Console.ReadLine());
                _storeBL.UpdateInventory(productReplenishID, amountToAddToInventory, listOfStores[0].StoreID);
                Log.Information("User has updated inventory successfully.");
                }

                catch(System.Exception exc)
                {
                        Log.Warning("User was unable to update inventory successfully");
                        Console.WriteLine(exc.Message);
                        IMenu.PressEnter();
                }

                return "ReplenishInvMenu";

                case "2":
                try
                {
                Log.Information("User has chosen to view inventory at a specific store and is being asked for store address.");
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
                Log.Information("User is viewing product inventory at a specific store");
                }
                catch(System.Exception exc)
                {
                        Log.Warning("User was unable to view the store inventory");
                        Console.WriteLine(exc.Message);
                }
                IMenu.PressEnter();
                return "ReplenishInvMenu";

                case "3":
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
                return "ManagerMenu";
                
                
                case "0":
                Log.Information("User has chosen to go back to previous menu- Manager Menu");
                return "ManagerMenu";

                default:
                Log.Warning("User has provided an input that does not exist, going back to current menu- replenishinv");
                Console.WriteLine("Please input a valid response");
                IMenu.PressEnter();
                return "ReplenishInvMenu";
            }

        }
    }
}