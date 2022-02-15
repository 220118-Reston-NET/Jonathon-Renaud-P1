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
                    return "Exit";
                case "1":
                    return "AddCustomer";
                case "2":
                    return "PlaceOrder";
                case "3":
                    return "Manager";
                case "4":
                    return "PlaceOrder";
                default:
                    Console.WriteLine("Please input a valid response");
                    IMenu.PressEnter();
                    
                    return "MainMenu";
            }
        }
    }
}