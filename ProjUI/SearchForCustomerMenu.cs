using ProjBL;
using ProjModel;

namespace ProjUI
{
    public class SearchForCustomerMenu : IMenu
    {

        private ICustomerBL _customerBL;
        public SearchForCustomerMenu(ICustomerBL p_custBL)
        {
            _customerBL = p_custBL;
        }
        public void Display()
        {
            Console.WriteLine("Please select an option to search for a customer");
            Console.WriteLine("[1] By Name");
            Console.WriteLine("[0] Go Back");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    Console.WriteLine("Please enter the name to search by");
                    string name = Console.ReadLine();

                    List<Customer> listOfCust = _customerBL.SearchCustomer(name);
                    foreach (var item in listOfCust)
                    {
                        Console.WriteLine("======================");
                        Console.WriteLine(item);
                    }
                    // Logic to choose a customer to modify later with orders and stuff needs to be added
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "MainMenu"; //This should change to the menu where we add orders, view orders, or view storefronts.
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "SearchCustomer";
            }
        }
    }
}