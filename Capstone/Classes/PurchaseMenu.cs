using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
                bool stillShopping = true;
                bool stayInMenu = true;
                string item;
                while (stayInMenu)
                {
                    MenuMusic();
                    Console.WriteLine();
                    Console.WriteLine("Purchase Menu".PadLeft(15));
                    Console.WriteLine();
                    Console.WriteLine("1] >> Insert Money");
                    Console.WriteLine("2] >> Purchase Items");
                    Console.WriteLine("3] >> Return To Main Menu");
                    Console.WriteLine();
                    Console.WriteLine($"Current Balance: ${vendingMachine.Balance}");
                    Console.WriteLine();
                    Console.Write("Select Your Option: ");

                    key = Console.ReadKey();
                    ButtonClick();

                    if (key.KeyChar == '1')
                    {
                        Console.Clear();
                        Console.Write("Insert $1 Or $5 Bills: $ ");

                        key = Console.ReadKey(); // prompt user to insert bills of various denominations

                        int.TryParse(key.KeyChar.ToString(), out addedMoney);

                        ButtonClick();
                        if (addedMoney <= 5 && addedMoney > 0)
                        {
                            stayInMenu = false;
                            Console.WriteLine();
                            startingBalance = vendingMachine.Balance;
                            moneyFed = addedMoney + 0.00m;
                            vendingMachine.FeedMoney(addedMoney);// add the users money in to the machine's balance 
                            logger.RecordTransaction("FEED MONEY: ", startingBalance, moneyFed, vendingMachine.Balance);
                            Console.Clear();
                            DisplaySubMenu(vendingMachine, customer, mainmenu, logger);
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Machine Only Accepts $1 And $5 Bills ");
                            Console.WriteLine();
                        }
                    }
                    else if (key.KeyChar == '2')
                    {
                        Console.Clear();
                        while (stillShopping)
                        {
                            DisplayMachineItems(vendingMachine);
                            Console.WriteLine();
                            Console.Write("Which item would you like to purchase(press Q to leave)? ");

                            input = Console.ReadLine();
                            ButtonClick();

                            if (input.ToLower() == "q")
                            {
                                stillShopping = false;
                                Console.Clear();
                                Console.WriteLine("Returning To Purchase Menu");
                                DisplaySubMenu(vendingMachine, customer, mainmenu, logger);
                                break;
                            }
                            else
                            {
                                stillShopping = false;
                                Console.Clear();
                                price = vendingMachine.GetItemAtSlot(input).Price;
                                startingBalance = vendingMachine.Balance;
                                item = vendingMachine.GetItemAtSlot(input).ItemName;
                                //vendingMachine.Purchase(input, vendingMachine, customer, mainmenu); // perform purchase
                                MakePurchase(input, item, startingBalance, price, vendingMachine.Balance, vendingMachine, customer, logger);
                                //logger.RecordTransaction($"{item} {input.ToUpper()}", startingBalance, price, vendingMachine.Balance); // log the transactions
                                DisplaySubMenu(vendingMachine, customer, mainmenu, logger);
                                break;
                            }
                        }
                    }
                    else if (key.KeyChar == '3')
                    {
                        stayInMenu = false;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Returning To Main Menu");
                        mainmenu.Display(vendingMachine, customer, mainmenu, logger);
                        break;
                    }
                    else
                    {
                        ErrorBuzz();
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Please Select A Valid Menu Option");
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                ErrorBuzz();
                Console.WriteLine();
                Console.WriteLine("Invalid Product Code");
                DisplaySubMenu(vendingMachine, customer, mainmenu, logger);
            }
            catch (IndexOutOfRangeException)
            {
                ErrorBuzz();
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Please Make Your Selection Again");
                DisplaySubMenu(vendingMachine, customer, mainmenu, logger);
            }
            catch (NullReferenceException)
            {
                ErrorBuzz();

                Console.WriteLine();
                Console.WriteLine("Please Select Another Product");
                DisplaySubMenu(vendingMachine, customer, mainmenu, logger);
            }
            catch (FormatException)
            {
                ErrorBuzz();
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Please Enter Whole Dollar Amounts(ie $1, $5, $10, $20)");
                DisplaySubMenu(vendingMachine, customer, mainmenu, logger);
            }
        }
    }
}



