using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class MainMenu
    {
        public void Display(VendingMachine vendingMachine, List<VendingMachineItem> customer, MainMenu mainmenu, VendingMachineLogger logger, Dictionary<string, int> salesAudit)
        {
            // variables for keeping trak of various user inputs and interactions
            bool stillShopping = true;
            decimal startingBalance = 0.00m;
            string input;

            try
            {
                if (salesAudit.Count == 0 && salesAudit.Count < 16)
                {
                    for (int i = 0; i < vendingMachine.Slots.Length; i++)
                    {
                        salesAudit.Add(vendingMachine.GetItemAtSlot(vendingMachine.Slots[i]).ItemName, 0);
                    }
                }

                PrintHeader();

                while (stillShopping)
                {
                    // Main Menu
                    Console.WriteLine();
                    Console.WriteLine("Main Menu".PadLeft(15));
                    Console.WriteLine("  ________________________");
                    Console.WriteLine("1] >> Display Items");
                    Console.WriteLine("2] >> Purchase Menu");
                    Console.WriteLine("3] >> Complete Transaction");
                    Console.WriteLine("Q] >> Quit");
                    Console.WriteLine();

                    // Asking User Which Option They Want
                    Console.Write("What option do you want to select?: ");
                    input = Console.ReadLine();

                    // If Option 1, Display All Items in the Inventory
                    if (input == "1")
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Displaying Vending Machine Items");
                        Console.WriteLine();

                        // Check to see if the items are in stock or not. If In Stock Print Price, Name and Amount Available. If Out Of Stock Print Out Of Stock
                        int enums = 0;// enumerator int used to keep track of current slot in the foreach loop
                        Console.WriteLine(" ____________________________________");
                        foreach (var kvp in vendingMachine.Slots)
                        {
                            VendingMachineItem vmi = vendingMachine.GetItemAtSlot(kvp); // assigning the value at the current slot in the loop to a variable

                            if (vmi == null)// if - slot is empty list item as sold out
                            {
                                Console.WriteLine($"| {vendingMachine.Slots.GetValue(enums)} | SOLD OUT                      |");
                            }
                            else// else - list key, item, price and quantity
                            {
                                Console.WriteLine($"| {vendingMachine.Slots.GetValue(enums)} | {vendingMachine.GetItemAtSlot(kvp).ItemName.PadRight(18)} | {vendingMachine.GetItemAtSlot(kvp).Price} | {vendingMachine.GetQuantityRemaining(kvp)} |");
                            }
                            enums++;// enumerator
                        }
                        Console.WriteLine(" ____________________________________");
                        Console.WriteLine();
                        Console.WriteLine($"Current Balance: ${vendingMachine.Balance}");// money currently in the machine
                        Console.WriteLine();
                    }
                    else if (input == "2")
                    {
                        Console.Clear();
                        PurchaseMenu purchaseMenu = new PurchaseMenu();// creates a sub menu called purchaseMenu
                        purchaseMenu.Display(vendingMachine, customer, mainmenu, purchaseMenu, logger, salesAudit);// takes you in to the purchase menu
                    }
                    else if (input == "3")
                    {
                        Console.Clear();
                        if (customer.Count > 0 || vendingMachine.Balance > 0) // if - customer has items to consume and change to be returned, perform appropriate actions 
                        {
                            Console.WriteLine();
                            foreach (var item in customer)// loop through purchased items and 'cosume' them
                            {
                                Console.WriteLine(item.Consume());
                            }
                            customer.Clear(); // clear out consumed items
                            startingBalance = vendingMachine.Balance;
                            Console.WriteLine();
                            Console.WriteLine($"Total Change Due: {vendingMachine.Balance}");
                            Console.WriteLine();
                            Console.WriteLine(vendingMachine.ReturnChange().DueChange); // prints change in least amount of quarters, dimes and nickels
                            logger.RecordTransaction("GIVE CHANGE ", startingBalance, startingBalance, vendingMachine.Balance, salesAudit);
                            Console.WriteLine();

                            //logger.TotalSalesLog(salesAudit, vendingMachine); // this was where we were trying to log the running sales total and running items sold total
                            stillShopping = false;
                        } 
                        else // else - prevent customer from even prodding this area if they don't have items to consume and change to return
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("There Is No Transaction To Complete");
                        }
                    }
                    else if (input.ToLower() == "q" && customer.Count == 0 && vendingMachine.Balance == 0)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        stillShopping = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Please Select A Valid Menu Option Or Select Complete Transaction To Return Your Money");
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {

            }
        }
        private void PrintHeader()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to Vend-O-Matic!");
            Console.WriteLine();
        }
    }
}


