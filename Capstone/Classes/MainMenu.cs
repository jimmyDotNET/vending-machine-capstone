using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class MainMenu
    {
        public void Display(VendingMachine vendingMachine)
        {
            try
            {
                PrintHeader();

                bool keepRun = true;
                while (keepRun)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Main Menu");
                    Console.WriteLine(" ");
                    Console.WriteLine("1] >> Display Items");
                    Console.WriteLine("2] >> Purchase Menu");
                    Console.WriteLine("Q] >> Quit");

                    Console.Write("What option do you want to select? ");
                    string input = Console.ReadLine();

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
                        purchaseMenu.Display(vendingMachine);
                    }
                    else if (input.ToLower() == "q")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Quitting");
                        Console.WriteLine(" ");
                        keepRun = false;
                    }
                    else
                    {
                        Console.WriteLine("Please try again");
                    }
                }
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine("Uh oh, there was an error");
            }
        }

        private void PrintHeader()
        {

            Console.WriteLine("Welcome to Vend-O-Matic!");
        }
    }
}

