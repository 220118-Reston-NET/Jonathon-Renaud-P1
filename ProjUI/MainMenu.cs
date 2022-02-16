namespace ProjUI
{
    public class MainMenu : IMenu
    {
        public void Display()
        {
           Console.WriteLine("Welcome to Le Magasin de Renaud!");
           Console.WriteLine("Please select from one of the following options:");
           Console.WriteLine("[1] I'm a new customer and need to add my information.");
           Console.WriteLine("[2] I'm an existing customer and need to order or browse items at stores.");
           Console.WriteLine("[3] Manager Functions");
           Console.WriteLine("[0] Exit");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    Log.Information("Exiting the application");
                    return "Exit";
                case "1":
                    Log.Information("Navigating to the add a new Customer menu");
                    return "AddCustomer";
                case "2":
                    Log.Information("Navigating back to the customer order menu");
                    return "PlaceOrder";
                case "3":
                    Log.Information("User has selected Manager menu and will be asked to confirm password");
                    return "Manager";
                default:
                    Log.Information("An invalid input was put in - navigating back to this menu");
                    Console.WriteLine("Please input a valid response");
                    IMenu.PressEnter();
                    
                    return "MainMenu";
            }
        }
    }
}