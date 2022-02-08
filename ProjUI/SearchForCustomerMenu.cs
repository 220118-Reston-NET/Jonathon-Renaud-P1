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
            Console.WriteLine("[2] By Address");
            Console.WriteLine("[3] By Phone Number");
            Console.WriteLine("[4] By Email");
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

                    List<Customer> listOfCustByName = _customerBL.SearchCustomerByName(name);
                    foreach (var item in listOfCustByName)
                    {
                        Console.WriteLine("======================");
                        Console.WriteLine(item);
                    }
                    // Logic to choose a customer to modify later with orders and stuff needs to be added
                    IMenu.PressEnter();
                    return "MainMenu";
                    //This should change to the menu where we add orders, view orders, or view storefronts.

                 case "2":
                    Console.WriteLine("Please enter the address or part of it to search by");
                    string address = Console.ReadLine();

                    List<Customer> listOfCustByAddress = _customerBL.SearchCustomerByAddress(address);
                    foreach (var item in listOfCustByAddress)
                    {
                        Console.WriteLine("======================");
                        Console.WriteLine(item);
                    }
                    IMenu.PressEnter();;
                    return "MainMenu";

                case "3":
                    Console.WriteLine("Please enter the phone number or part of it to search by");
                    string phoneNumber = Console.ReadLine();

                    List<Customer> listOfCustByPhoneNumber = _customerBL.SearchCustomerByPhoneNumber(phoneNumber);
                    foreach (var item in listOfCustByPhoneNumber)
                    {
                        Console.WriteLine("======================");
                        Console.WriteLine(item);
                    }
                    IMenu.PressEnter();
                    return "MainMenu";

                case "4":
                    Console.WriteLine("Please enter the phone number or part of it to search by");
                    string email = Console.ReadLine();

                    List<Customer> listOfCustByEmail = _customerBL.SearchCustomerByEmail(email);
                    foreach (var item in listOfCustByEmail)
                    {
                        Console.WriteLine("======================");
                        Console.WriteLine(item);
                    }
                    IMenu.PressEnter();
                    return "MainMenu";

                default:
                    Console.WriteLine("Please input a valid response");
                    IMenu.PressEnter();
                    return "SearchCustomer";
            }
        }
    }
}