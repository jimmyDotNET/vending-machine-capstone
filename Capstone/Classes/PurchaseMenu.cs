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
        public new void Display()
        {
            try
            {
                VendingMachine vendingMachine = new VendingMachine();

                int enums = 0;
                foreach (var kvp in vendingMachine.Slots)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine($"{vendingMachine.Slots.GetValue(enums)} - {vendingMachine.GetItemAtSlot(kvp).ItemName.PadRight(20)} ---- {vendingMachine.GetQuantityRemaining(kvp)}");
                    enums++;

                }

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Purchase Menu");
                    Console.WriteLine("1] >> Insert Money");
                    Console.WriteLine("2] >> Purchase Item");
                    Console.WriteLine("Q] >> Return To Main Menu");

                    Console.Write("What option do you want to select? ");
                    string input = Console.ReadLine();

                    if (input == "1")
                    {
                        Console.Write("How Much Money Would You Like To Insert?: ");
                        decimal insertedMoney = decimal.Parse(Console.ReadLine());
                        insertedMoney += vendingMachine.Balance;

                       
                    }
                    else if (input == "2")
                    {
                        Console.Write("Which item would you like to purchase? ");
                        string viewSlot = Console.ReadLine();

                        Console.WriteLine($"{vendingMachine.Slots}{vendingMachine.GetItemAtSlot(viewSlot).ItemName} - {vendingMachine.GetQuantityRemaining(viewSlot)} remaining");
                        vendingMachine.Purchase(viewSlot);
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
            catch(IOException ex)
            {
                Console.WriteLine("What are you doing, Dave?");
            }
        }
    }
}
