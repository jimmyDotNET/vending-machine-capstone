using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class MainMenu
    {
        public void Display()
        {
            PrintHeader();
            VendingMachine vendingMachine = new VendingMachine();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine("1] >> Display Vending Machine Items");
                Console.WriteLine("2] >> Purchase");
                Console.WriteLine("Q] >> Quit");

                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Displaying Vending Machine Items");
                    Console.WriteLine(" ");
                    VendingMachine.;
                }
                else if (input == "2")
                {
                    PurchaseMenu purchaseMenu = new PurchaseMenu();
                    purchaseMenu.Display();
                }
                else if (input == "Q")
                {
                    Console.WriteLine("Quitting");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again");
                }
            }
        }

        private void PrintHeader()
        {

            Console.WriteLine("WELCOME!!!!");
        }
    }
}
