namespace ProjUI
{
 
//  Interface makes everything you write in it, "abstract" -- best way to implement abstraction
// Every Method we put inside, is implicitly abstract so you won't need to write anything -- needs to be public as well.
    public interface IMenu 
    {
        // public and abstract are implicit and don't need to be written. 
        /// <summary>
        /// Will display the menu and user choices in the terminal
        /// </summary>
        void Display();
        /// <summary>
        /// Will record the user's choice and change/route your menu based on that choice. 
        /// </summary>
        /// <returns>Return the menu that will change your screen</returns>
        string UserChoice();

    }
}