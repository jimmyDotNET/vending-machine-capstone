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
        public new void Display(VendingMachine vendingMachine)
        {
            try
            { 
                Console.WriteLine("");

                int i = 0;
                foreach (var kvp in vendingMachine.Slots)
                {
                    Console.WriteLine($"{vendingMachine.Slots.GetValue(i)} | {vendingMachine.GetItemAtSlot(kvp).ItemName.PadRight(18)} | {vendingMachine.GetItemAtSlot(kvp).Price} | {vendingMachine.GetQuantityRemaining(kvp)}");
                    i++;
                }
                Console.WriteLine(" ");
                Console.WriteLine($"Current Balance: ${vendingMachine.Balance}");
                Console.WriteLine(" ");
                while (true)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Purchase Menu");
                    Console.WriteLine(" ");
                    Console.WriteLine("1] >> Insert Money");
                    Console.WriteLine("2] >> Purchase Item");
                    Console.WriteLine("Q] >> Return To Main Menu");

                    Console.Write("What option do you want to select? ");
                    string input = Console.ReadLine();

                    if (input == "1")
                    {
                        Console.Write("What Bill Would You Like To Insert?(Whole Dollar Amounts): $");
                        int addedMoney = int.Parse(Console.ReadLine());

                        vendingMachine.FeedMoney(addedMoney);

                        Console.WriteLine(" ");
                        Console.WriteLine($"Current Balance: ${vendingMachine.Balance}");
                    }
                    else if (input == "2")
                    {
                        bool stillShopping = true;

                        while (stillShopping)
                        {
                            int enums = 0;
                            Console.WriteLine(" ");
                            foreach (var kvp in vendingMachine.Slots)
                            {
                                VendingMachineItem vmi = vendingMachine.GetItemAtSlot(kvp);

                                if (vmi == null)
                                {
                                    Console.WriteLine($"{vendingMachine.Slots.GetValue(enums)} - SOLD OUT");
                                }
                                else
                                {
                                Console.WriteLine($"{vendingMachine.Slots.GetValue(enums)} | {vendingMachine.GetItemAtSlot(kvp).ItemName.PadRight(18)} | {vendingMachine.GetItemAtSlot(kvp).Price} | {vendingMachine.GetQuantityRemaining(kvp)}");
                                enums++;
                                }
                            }
                            Console.WriteLine(" ");
                            Console.WriteLine($"Current Balance: ${vendingMachine.Balance}");
                            Console.WriteLine(" ");

                            Console.Write("Which item would you like to purchase? ");
                            string viewSlot = Console.ReadLine();
                            vendingMachine.Purchase(viewSlot, vendingMachine);

                            Console.WriteLine(" ");
                            Console.Write("Are you done shopping?(y/n): ");
                            string userAnswer = Console.ReadLine();

                            if(userAnswer.ToLower() == "y")
                            {
                                stillShopping = false;
                            }
                            else
                            {
                                stillShopping = true;
                            }
                        }
                    }
                    else if (input.ToLower() == "q")
                    {
                        Console.WriteLine("Returning to main menu");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please try again");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("What are you doing, Dave?");
            }
        }
    }
}
