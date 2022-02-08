namespace ProjUI
{
    public class ManagerMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("--------Manager Functions--------");
            Console.WriteLine("Please select from one of the following options:");
            Console.WriteLine("[1] Check inventory at a specific store");
            Console.WriteLine("[2] Replenish inventory at a specific store");
            Console.WriteLine("[3] View orders to be fulfilled at a specific store");
            Console.WriteLine("[4] Add a new storefront");
            Console.WriteLine("[0] Back to Main Menu");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "MainMenu";
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
                    // Will return a create 
                    return null;

                default:
                    Console.WriteLine("Please input a valid response");
                    IMenu.PressEnter();
                    
                    return "MainMenu";
            }
        }
    }
}