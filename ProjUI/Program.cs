global using Serilog;
using ProjBL;
using ProjDL;
using ProjUI;


// See https://aka.ms/new-console-template for more information


Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt")
    .CreateLogger();


bool repeat = true;
IMenu menu = new MainMenu();

while (repeat)
{
    Console.Clear();
    menu.Display();
    string ans = menu.UserChoice();
    
    switch (ans)
    {
        case "SearchCustomer":
            Log.Information("Displaying SearchCustomer Menu to user");
            menu = new SearchForCustomerMenu(new CustomerBL(new Repository()));
            break;
        case "AddCustomer":
            Log.Information("Displaying AddCustomer Menu to user");
            menu = new AddCustomerMenu(new CustomerBL(new Repository()));
            break;
        case "MainMenu":
            Log.Information("Displaying MainMenu to user");
            menu = new MainMenu();
            break;
        case "Exit":
            Log.Information("Exiting Application");
            Log.CloseAndFlush(); // closes out the logger resource
            repeat = false;
            break;
        default:
            Console.WriteLine("Page does not exist!");
            Console.WriteLine("Please press Enter to continue");
            Console.ReadLine();
            break;
    }
}