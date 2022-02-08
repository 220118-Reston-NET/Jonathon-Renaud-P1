namespace ProjUI
{
    public class ViewStoreFrontMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("-----Storefront Manager Functions-----");
            Console.WriteLine("Please select from one of the following options:");
            Console.WriteLine("[1] Check inventory at a specific store");
            Console.WriteLine("[2] Replenish inventory at a specific store");
            Console.WriteLine("[3] View orders to be fulfilled at a specific store");
            Console.WriteLine("[4] Update storefront information");
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
                    // Will take in store number
                    // Method to return all inventory levels at a specific store
                    return null;
    
                case "2":
                    return "ReplenishInvMenu";

                case "3":
                    // Will take in store number
                    // Method to return all orders associated with a specific store
                    return null;

                case "4":
                    // Will take to an update storefront menu 
                    return null;
                default:
                    Console.WriteLine("Please input a valid response");
                    IMenu.PressEnter();
                    
                    return "MainMenu";
            }
        }
    }
}