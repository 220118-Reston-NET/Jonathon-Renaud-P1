using ProjBL;
using ProjDL;
using ProjUI;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


bool repeat = true;
IMenu menu = new MainMenu();

while (repeat)
{
    Console.Clear();
    menu.Display();
    string ans = menu.UserChoice();
    
    switch (ans)
    {
        case "AddCustomer":
            menu = new AddCustomerMenu(new CustomerBL(new Repository()));
            break;
        case "MainMenu":
            menu = new MainMenu();
            break;
        case "Exit":
            repeat = false;
            break;
        default:
            Console.WriteLine("Page does not exist!");
            break;
    }
}