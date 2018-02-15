using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class PurchaseMenu : MainMenu
    {
        public void Display(VendingMachine vendingMachine, List<VendingMachineItem> customer, MainMenu mainmenu, PurchaseMenu purchaseMenu, VendingMachineLogger logger)
        {
            try
            {
                // variables for keeping track of various user inputs and interaction
                string input;
                ConsoleKeyInfo key;
                int addedMoney = 0;
                decimal startingBalance = 0.00m;
                decimal moneyFed = 0.00m;
                decimal price = 0.00m;
                bool stayInSubMenu = true;
                string item;

                while (stayInSubMenu)
                {
                    MenuMusic();
                    Console.WriteLine();
                    Console.WriteLine("Purchase Menu".PadLeft(18));
                    Console.WriteLine("  ________________________");
                    Console.WriteLine("1] >> Insert Money");
                    Console.WriteLine("2] >> Purchase Items");
                    Console.WriteLine("3] >> Return To Main Menu");
                    Console.WriteLine();
                    Console.WriteLine($"Current Balance: ${vendingMachine.Balance}");
                    Console.WriteLine();
                    Console.Write("Select Your Option: ");

                    // prompt user to select an option

                    key = Console.ReadKey();
                    ButtonClick();

                    if (key.KeyChar == '1')
                    {
                        Console.Clear();
                        Console.Write("Insert $1 Or $5 Bills: $ ");

                        // prompt user to insert bills of various denominations

                        key = Console.ReadKey(); 
                        int.TryParse(key.KeyChar.ToString(), out addedMoney);// storing users input to a variable to pass in to the purchasing methods                                       
                        ButtonClick();

                        if (addedMoney <= 5 && addedMoney > 0)
                        {
                            stayInSubMenu = false;
                            Console.WriteLine();

                            // add the money to the balance and also pass the various information in to the logger
                            // TO DO - turn this in to a method to clean up clutter in the menu classes
                            
                            startingBalance = vendingMachine.Balance;
                            moneyFed = addedMoney + 0.00m;
                            vendingMachine.FeedMoney(addedMoney);
                            logger.RecordTransaction("FEED MONEY : ", startingBalance, moneyFed, vendingMachine.Balance);
                            Console.Clear();
                            
                            // return to purchase menu

                            DisplaySubMenu(vendingMachine, customer, mainmenu, logger);
                            break;
                        }
                        else
                        {
                            // error message to limit accepted bill denominations ,
                            //  and make it a pain in the ass to add unrealistic amounts of money in to the machine
                            Console.WriteLine();
                            Console.WriteLine("Machine Only Accepts $1 And $5 Bills ");
                            Console.WriteLine();
                        }
                    }
                    else if (key.KeyChar == '2')
                    {
                        Console.Clear();

                        // display machine inventory
                        DisplayMachineItems(vendingMachine);
                        Console.WriteLine();
                        Console.Write("Which item would you like to purchase(press Q to leave)? ");

                        // prompt user to select an inventory item

                        input = Console.ReadLine();
                        ButtonClick();

                        if (input.ToLower() == "q")
                        {
                            // lets user quit menu without making a selection
                            Console.Clear();
                            Console.WriteLine("Returning To Purchase Menu");
                        }
                        else
                        {
                            // if balance is enough AND item is in stock, this will perform the necessary purchase functions
                            // and dispense items from the vending machine to the customers bin ( list )
                            Console.Clear();
                            price = vendingMachine.GetItemAtSlot(input).Price;
                            startingBalance = vendingMachine.Balance;
                            item = vendingMachine.GetItemAtSlot(input).ItemName;
                            MakePurchase(input, item, startingBalance, price, vendingMachine.Balance, vendingMachine, customer, logger, mainmenu);
                        }
                    }
                    else if (key.KeyChar == '3')
                    {
                        // return to main menu
                        stayInSubMenu = false;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Returning To Main Menu");
                        mainmenu.Display(vendingMachine, customer, mainmenu, logger);
                        Console.Clear();
                    }
                    else
                    {
                        // prevents user from entering invalid inputs
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Please Select A Valid Menu Option");
                        ErrorBuzz();
                        Console.Clear();
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                // prevents user from selecting an invalid product code
                Console.WriteLine();
                Console.WriteLine("Invalid Product Code");
                ErrorBuzz();
                DisplaySubMenu(vendingMachine, customer, mainmenu, logger);
            }
            catch (IndexOutOfRangeException)
            {
                // prevents the unlikely case of an index out of bounds error being thrown
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Please Make Your Selection Again");
                ErrorBuzz();
                DisplaySubMenu(vendingMachine, customer, mainmenu, logger);
            }
            catch (NullReferenceException)
            {
                // prevents the unlikely case of a nullref being thrown
                Console.WriteLine();
                Console.WriteLine("Please Select Another Product");
                ErrorBuzz();
                DisplaySubMenu(vendingMachine, customer, mainmenu, logger);
            }
            catch (FormatException)
            {
                // prevents invalid input error in the feed money function
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Please Enter $1 Or $5 Dollar Bills");
                ErrorBuzz();
                DisplaySubMenu(vendingMachine, customer, mainmenu, logger);
            }
        }
    }
}



