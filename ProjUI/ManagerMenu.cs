namespace ProjUI
{
    public class ManagerMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("--------Manager Functions--------");
            Console.WriteLine("Please select from one of the following options:");
            Console.WriteLine("[1] Replenish or check inventory at a specific store");
            Console.WriteLine("[2] View orders by customer or store");
            Console.WriteLine("[3] Search for a customer");
            Console.WriteLine("[0] Back to Main Menu");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    Log.Information("Navigating back to MainMenu");
                    return "MainMenu";
                case "1":
                    Log.Information("Navigating to the inventory control menu");
                    return "ReplenishInvMenu";
                case "2":
                    Log.Information("Navigating to the order history menu");
                    return "ViewOrderHistoryMenu";
                case "3":
                    Log.Information("Navigating to the search for customer menu");
                    return "SearchCustomer";
                default:
                    Log.Information("An invalid input was received. Navigating back to this menu");
                    Console.WriteLine("Please input a valid response");
                    IMenu.PressEnter();
                    return "ManagerMenu";
            }
        }
    }
}