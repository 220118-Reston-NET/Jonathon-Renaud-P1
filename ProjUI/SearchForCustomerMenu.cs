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
                    Log.Information("User has chosen to go to previous menu- Manager Menu");
                    return "ManagerMenu";

                case "1":
                    try{
                    Log.Information("User has chosen to search for a customer by name");
                    Console.WriteLine("Please enter the name to search by");
                    string name = Console.ReadLine();

                    List<Customer> listOfCustByName = _customerBL.SearchCustomerByName(name);
                    if(listOfCustByName[0].Name != null){
                    foreach (var item in listOfCustByName)
                    {
                        Console.WriteLine("======================");
                        Console.WriteLine(item);
                    }
                    }
                    else{
                        Console.WriteLine("No Customer was found with that criteria");
                    }
                    }
                    catch(System.Exception exc)
                    {
                        Log.Warning("User tried to enter a name that didn't correspond to a customer.");
                        Console.WriteLine("No Customer was found with that criteria", exc);

                    }

                    IMenu.PressEnter();
                    return "SearchCustomer";

                 case "2":
                    try{
                    Log.Information("User has chosen to search for a customer by Address");
                    Console.WriteLine("Please enter the address or part of it to search by");
                    string address = Console.ReadLine();

                    List<Customer> listOfCustByAddress = _customerBL.SearchCustomerByAddress(address);
                    if(listOfCustByAddress[0].Name != null){
                    foreach (var item in listOfCustByAddress)
                    {
                        Console.WriteLine("======================");
                        Console.WriteLine(item);
                    }
                    }
                    else{
                        Console.WriteLine("No Customer was found with that criteria");
                    }
                    }

                    catch(System.Exception exc)
                    {
                        Log.Warning("User tried to enter an address that didn't correspond to a customer.");
                        Console.WriteLine("No Customer was found with that criteria", exc);

                    }

                    IMenu.PressEnter();;
                    return "SearchCustomer";

                case "3":
                    try{
                    Log.Information("User has chosen to search for a customer by Phone Number");
                    Console.WriteLine("Please enter the phone number or part of it to search by");
                    string phoneNumber = Console.ReadLine();

                    List<Customer> listOfCustByPhoneNumber = _customerBL.SearchCustomerByPhoneNumber(phoneNumber);
                    if(listOfCustByPhoneNumber[0].Name != null){
                    foreach (var item in listOfCustByPhoneNumber)
                    {
                        Console.WriteLine("======================");
                        Console.WriteLine(item);
                    }
                    }
                                       
                    else{
                        Console.WriteLine("No Customer was found with that criteria");
                    }}
                    catch(System.Exception exc)
                    {
                        Log.Warning("User tried to enter a phone number that didn't correspond to a customer.");
                        Console.WriteLine("No Customer was found with that criteria", exc);

                    }
                    IMenu.PressEnter();
                    return "SearchCustomer";

                case "4":
                    try{
                    Log.Information("User has chosen to search for a customer by email ");
                    Console.WriteLine("Please enter the unique email to search by");
                    string email = Console.ReadLine().ToLower();

                    List<Customer> listOfCustByEmail = _customerBL.SearchCustomerByEmail(email);
                    if(listOfCustByEmail[0].Name != null){
                    foreach (var item in listOfCustByEmail)
                    {
                        Console.WriteLine("======================");
                        Console.WriteLine(item);
                    }
                    }
                    
                    else{
                        Console.WriteLine("No Customer was found with that criteria");
                    }
                    }
                    catch(System.Exception exc)
                    {
                        Log.Warning("User tried to enter an email that didn't correspond to a customer.");
                        Console.WriteLine("No Customer was found with that criteria - check spelling or completeness", exc);

                    }
                    IMenu.PressEnter();
                    return "SearchCustomer";

                default:
                    Log.Warning("User has provided an invalid input - going to current menu - search customer");
                    Console.WriteLine("Please input a valid response");
                    IMenu.PressEnter();
                    return "SearchCustomer";
            }
        }
    }
}