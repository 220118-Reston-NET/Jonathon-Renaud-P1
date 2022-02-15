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
                    return "MainMenu";
                case "1":
                    return "ReplenishInvMenu";

                case "2":
                    return "ViewOrderHistoryMenu";
                case "3":
                    return "SearchCustomer";
                default:
                    Console.WriteLine("Please input a valid response");
                    IMenu.PressEnter();
                    return "ManagerMenu";
            }
        }
    }
}