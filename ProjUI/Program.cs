global using Serilog;
using Microsoft.Extensions.Configuration;
using ProjBL;
using ProjDL;
using ProjUI;


// See https://aka.ms/new-console-template for more information


Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt")
    .CreateLogger();


var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

string _connectionString = configuration.GetConnectionString("KeyValue1");


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
            menu = new SearchForCustomerMenu(new CustomerBL(new SQLRepository(_connectionString)));
            break;

        case "AddCustomer":
            Log.Information("Displaying AddCustomer Menu to user");
            menu = new AddCustomerMenu(new CustomerBL(new SQLRepository(_connectionString)));
            break;
        case "PlaceOrder":
            Log.Information("Displaying order menu to user");
            menu = new PlaceOrderMenu(new CustomerBL(new SQLRepository(_connectionString)), new StoreBL(new SQLRepository(_connectionString)));
            break;
        case "ViewOrderHistoryMenu":
            Log.Information("Displaying view order history menu to user");
            menu = new ViewOrderHistoryMenu(new CustomerBL(new SQLRepository(_connectionString)), new StoreBL(new SQLRepository(_connectionString)));
            break;
        case "MainMenu":
            Log.Information("Displaying MainMenu to user");
            menu = new MainMenu();
            break;

        case "Manager":
            Log.Information("Asking for manager password from user");
            Console.WriteLine("Please enter Manager access password");
            string passwordEntered = Console.ReadLine();
            // This is simply a placeholder while setting up -- obviously something as sensitive as a password would not be set to a value inside of code. It would be stored somewhere else, and hashed or protected in some way
            string passwordPlaceholder = "admin";

            if (passwordEntered != passwordPlaceholder)
            {
                Log.Information("Wrong password was entered by user");
                Console.WriteLine("Password was incorrect.");
                IMenu.PressEnter();
                Log.Information("Displaying MainMenu to user");

                menu = new MainMenu();
                break;
            }
            Log.Information("Correct password was entered -- Displaying Manager Menu to user");
            menu = new ManagerMenu();
            break;

        case "ManagerMenu":
            Log.Information("Displaying Manager Menu to user");
            menu = new ManagerMenu();
            break;

        case "ReplenishInvMenu":
            Log.Information("Displaying Replenish Inventory Menu to user");
            menu = new ReplenishInvMenu(new StoreBL(new SQLRepository(_connectionString)));
            break;

        case "Exit":
            Log.Information("Exiting Application");
            Log.CloseAndFlush(); // closes out the logger resource
            repeat = false;
            break;

        default:
            Log.Warning("User tried to input a wrong input");
            Console.WriteLine("Page does not exist!");
            IMenu.PressEnter();
            break;
    }
}