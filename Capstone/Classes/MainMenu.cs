using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class MainMenu : VendingMachine
    {
        public void Display(VendingMachine vendingMachine, List<VendingMachineItem> customer, MainMenu mainmenu, VendingMachineLogger logger)
        {
            System.Media.SoundPlayer boom = new System.Media.SoundPlayer(@".\bomb_x.wav");
            // :)
            System.Media.SoundPlayer click = new System.Media.SoundPlayer(@".\click_x.wav");

                        System.Media.SoundPlayer error = new System.Media.SoundPlayer(@".\fail-buzzer.wav");

            // variables for keeping trak of if user is still in menu and starting balance for logging
            bool stillShopping = true;
            decimal startingBalance = 0.00m;

            try
            {

                while (stillShopping)
                {
                    PrintHeader();
                    MenuSound();
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
                    ConsoleKeyInfo key = Console.ReadKey();

                    // If Option 1, Display All Items in the Inventory
                    if (key.KeyChar == '1')
                    {
                        ButtonSound();
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
                    else if (key.KeyChar == '2')
                    {
                        ButtonSound();
                        Console.Clear();
                        PurchaseMenu purchaseMenu = new PurchaseMenu();// creates a sub menu called purchaseMenu
                        purchaseMenu.Display(vendingMachine, customer, mainmenu, purchaseMenu, logger);// takes you in to the purchase menu
                    }
                    else if (key.KeyChar == '3')
                    {
                        ButtonSound();
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
                            logger.RecordTransaction("GIVE CHANGE ", startingBalance, startingBalance, vendingMachine.Balance);
                            Console.WriteLine();

                            //logger.TotalSalesLog(salesAudit, vendingMachine); // this was where we were trying to log the running sales total and running items sold total
                            stillShopping = false;
                        } 
                        else // else - prevent customer from even prodding this area if they don't have items to consume and change to return
                        {
                            FatalErrorSound();
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("There Is No Transaction To Complete");
                        }
                    }
                    else if (key.KeyChar == 'q' || key.KeyChar == 'Q' && customer.Count == 0 && vendingMachine.Balance == 0)
                    {
                        ButtonSound();
                        Console.Clear();
                        Console.WriteLine();
                        stillShopping = false;
                    }
                    else
                    {
                        FatalErrorSound();
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Please Select A Valid Menu Option");
                        Console.WriteLine();
                        Console.WriteLine("Select Complete Transaction To Return Your Money");
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                FatalErrorSound();
                Console.WriteLine();
                Console.WriteLine("Please Make Another Selection");
            }
        }
        private void PrintHeader()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to Vend-O-Matic!");
            Console.WriteLine();
        }
        public void MakePurchase(string input, VendingMachine vendingMachine, List<VendingMachineItem> customer, PurchaseMenu purchaseMenu, MainMenu mainmenu, VendingMachineLogger logger)
        {
            vendingMachine.Purchase(input, vendingMachine, customer, mainmenu);
        }
        public void SalesAudit(string transactType, decimal startingBal, decimal transactAmt, decimal finalBal, VendingMachineLogger logger)
        {
            logger.RecordTransaction(" ", startingBal, transactAmt, finalBal);
        }
        public void MenuSound()
        {
            System.Media.SoundPlayer loop = new System.Media.SoundPlayer(@".\Elevator-music.wav");
            loop.Play();
        }
        public void ButtonSound()
        {
            System.Media.SoundPlayer click = new System.Media.SoundPlayer(@".\click_x.wav");
            click.PlaySync();
        }
        public void FatalErrorSound()
        {
            System.Media.SoundPlayer error = new System.Media.SoundPlayer(@".\fail-buzzer.wav");
            error.PlaySync();   
        }
    }
}


