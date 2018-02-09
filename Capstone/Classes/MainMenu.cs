using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class MainMenu 
    {
        public void Display(VendingMachine vendingMachine, List<VendingMachineItem> customer)
        {
            try
            {
                PrintHeader();

                while (true)
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
                    string input = Console.ReadLine();

                    // If Option 1, Display All Items in the Inventory
                    if (input == "1")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Displaying Vending Machine Items");
                        Console.WriteLine(" ");

                        int enums = 0;
                        foreach (var kvp in vendingMachine.Slots)
                        {
                            VendingMachineItem vmi = vendingMachine.GetItemAtSlot(kvp);

                            if (vmi == null)
                            {
                                Console.WriteLine($"{vendingMachine.Slots.GetValue(enums)} - SOLD OUT");
                            }
                            else
                            {
                                Console.WriteLine($"{vendingMachine.Slots.GetValue(enums)} - {vendingMachine.GetItemAtSlot(kvp).ItemName.PadRight(18)} | {vendingMachine.GetItemAtSlot(kvp).Price} | {vendingMachine.GetQuantityRemaining(kvp)}");
                            }
                            enums++;
                        }
                        Console.WriteLine(" ");
                        Console.WriteLine($"Current Balance: ${vendingMachine.Balance}");
                        Console.WriteLine(" ");
                    }
                    else if (input == "2")
                    {
                        PurchaseMenu purchaseMenu = new PurchaseMenu();
                        purchaseMenu.Display(vendingMachine, customer);
                    }
                    else if (input == "3")
                    {
                        Change customerChange = new Change(vendingMachine.Balance);

                        Console.WriteLine(" ");
                        foreach (var item in customer)
                        {
                            Console.WriteLine(item.Consume());
                        }
                        Console.WriteLine(" ");
                        Console.WriteLine($"Total Change Due: {vendingMachine.Balance}");
                        Console.WriteLine(" ");
                        Console.WriteLine($"Your change is {customerChange.Quarters} quarters, {customerChange.Dimes} dimes,  {customerChange.Nickels} nickels");
                        Console.WriteLine(" ");

                        break;
                    }
                    else
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Please Select A Valid Menu Option");
                        Console.WriteLine(" ");
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Uh oh, there was an error");
                Console.WriteLine(" ");
            }
        }

        private void PrintHeader()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Welcome to Vend-O-Matic!");
            Console.WriteLine(" ");
        }
    }
}


