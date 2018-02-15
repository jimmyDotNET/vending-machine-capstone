using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Capstone.Classes
{
    public class MainMenu : MenuCLI
    {
        public void Display(VendingMachine vendingMachine, List<VendingMachineItem> customer, MainMenu mainmenu, VendingMachineLogger logger)
        {
            try
            {
                // variables for keeping track of user inputs
                bool stayInMenu = true;
                ConsoleKeyInfo key;

                while (stayInMenu)
                {
                    MenuMusic();
                    // Main Menu
                    Console.WriteLine();
                    Console.WriteLine("Main Menu".PadLeft(15));
                    Console.WriteLine("  ________________________");
                    Console.WriteLine("1] >> Display Items");
                    Console.WriteLine("2] >> Purchase Menu");
                    Console.WriteLine("3] >> Complete Transaction");
                    Console.WriteLine("Q] >> Quit");
                    Console.WriteLine();

                    // prompt user to select an option 

                    Console.Write("Select Your Option: ");

                    key = Console.ReadKey();
                    ButtonClick();

                   
                    if (key.KeyChar == '1')
                    {
                        // displays all items in the inventory
                        Console.Clear();
                        DisplayMachineItems(vendingMachine);
                    }
                    
                    else if (key.KeyChar == '2')
                    {
                        // display purchase menu
                        stayInMenu = false;
                        Console.Clear();
                        DisplaySubMenu(vendingMachine, customer, mainmenu, logger);
                        break;
                    }
                    else if (key.KeyChar == '3')
                    {
                        // return any due change and consume items, then terminate the program
                        Console.Clear();
                        stayInMenu = false;
                        CompleteTransaction(vendingMachine.Balance, vendingMachine, customer, logger, mainmenu);
                        break;
                    }
                    else if (key.KeyChar.ToString().ToLower() == "q" && customer.Count == 0 && vendingMachine.Balance == 0)
                    {
                        // quits the program IF the user isn't due any change AND no items to consume
                        stayInMenu = false;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Thank You Come Again");
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        // error catch to prevent invalid input or leaving without returning change and taking items
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Please Select A Valid Menu Option");
                        Console.WriteLine();
                        Console.WriteLine("Or".PadLeft(15));
                        Console.WriteLine();
                        Console.WriteLine("Select Complete Transaction To Return Your Money");
                        ErrorBuzz();
                        Delay();
                        Console.Clear();
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Please Make Another Selection");
                ErrorBuzz();
                Console.Clear();
            }
        }
    }
}


