﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class MainMenu
    {
        public void Display(VendingMachine vendingMachine, List<VendingMachineItem> customer, MainMenu mainmenu)
        {
            // variables for keeping trak of various user inputs and interactions
            bool stillShopping = true;
            string input;
            try
            {
                PrintHeader();

                while (stillShopping)
                {
                    // Main Menu
                    Console.WriteLine();
                    Console.WriteLine("Main Menu");
                    Console.WriteLine();
                    Console.WriteLine("1] >> Display Items");
                    Console.WriteLine("2] >> Purchase Menu");
                    Console.WriteLine("3] >> Complete Transaction");
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
                        purchaseMenu.Display(vendingMachine, customer, mainmenu, purchaseMenu);// takes you in to the purchase menu
                    }
                    else if (input == "3")
                    {
                        Console.Clear();
                        if (customer.Count > 0) // if - customer has items to consume and change to be returned, perform appropriate actions 
                        {
                            Console.WriteLine();
                            foreach (var item in customer)// loop through purchased items and 'cosume' them
                            {
                                Console.WriteLine(item.Consume());
                            }
                            customer.Clear(); // clear out consumed items
                            Console.WriteLine();
                            Console.WriteLine($"Total Change Due: {vendingMachine.Balance}");
                            Console.WriteLine();
                            Console.WriteLine(vendingMachine.ReturnChange().DueChange); // prints change in least amount of quarters, dimes and nickels
                            Console.WriteLine();
                            Console.Write("Return to Main Menu?:(y/n) "); // ask user if they want to keep using app or leave
                            input = Console.ReadLine();

                            if (input.ToLower() == "y")
                            {
                                stillShopping = true; // return to top of main menu loop
                            }
                            else if (input.ToLower() == "n")
                            {
                                Console.WriteLine();
                                Console.WriteLine("Thank You - Come Again");
                                Console.WriteLine();
                                stillShopping = false; // break main menu loop and leave the program 
                            }
                        }
                        else // else - prevent customer from even prodding this area if they have items to consume and change to return
                        {
                            Console.WriteLine();
                            Console.WriteLine("There Is No Transaction To Complete");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Please Select A Valid Menu Option");
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine();
                Console.WriteLine("Please Make Another Selection");
                Console.WriteLine();
                mainmenu.Display(vendingMachine, customer, mainmenu);
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


