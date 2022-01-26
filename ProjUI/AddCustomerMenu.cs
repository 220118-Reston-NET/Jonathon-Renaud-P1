using ProjBL;
using ProjModel;

namespace ProjUI
{
    public class AddCustomerMenu : IMenu
    {
        
         private static Customer _newCustomer = new Customer();

        //Dependency Injection
        //==========================
        private ICustomerBL _customerBL;
        public AddCustomerMenu(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        //==========================
        // stuff in code needs here

        public void Display()
        {
            Console.WriteLine("Please use the menu to enter all new fields to create a customer account. \n Once finished and data entered is correct, use the appropriate number to save your information.  Your customer account will then be complete.");
            Console.WriteLine("[1] Name - " + _newCustomer.Name);
            Console.WriteLine("[2] Address - " + _newCustomer.Address);
            Console.WriteLine("[3] Email - " + _newCustomer.Email);
            Console.WriteLine("[4] Phone Number - " + _newCustomer.PhoneNumber);
            Console.WriteLine("[5] Save this information");
            Console.WriteLine("[0] Go back to main menu");

            // Should ask the customer information about the new customer they are creating.
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                   Console.WriteLine("Please enter your full name!");
                   _newCustomer.Name = Console.ReadLine();
                   return "AddCustomer";
                case "2":
                    Console.WriteLine("Please enter your address!");
                    _newCustomer.Address = Console.ReadLine();
                    return "AddCustomer";
                case "3":
                    Console.WriteLine("Please enter your email!");
                    _newCustomer.Email = Console.ReadLine();
                    return "AddCustomer";
                case "4":
                    Console.WriteLine("Please enter your phone number!");
                    _newCustomer.PhoneNumber = Console.ReadLine();
                    return "AddCustomer";
                case "5":
                     _customerBL.AddCustomer(_newCustomer);
                    return "MainMenu";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "AddCustomer";
            }
        }
    }
}

