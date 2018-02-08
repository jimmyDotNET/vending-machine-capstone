using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class PurchaseMenu
    {
        public void Display()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Purchase Menu");
                Console.WriteLine("1] >> Insert Money");
                Console.WriteLine("2] >> Purchase");
                Console.WriteLine("3] >> Finish Transaction");
                Console.WriteLine("Q] >> Return To Main Menu");

                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.Write("How Much Money Would You Like To Insert?: ");
                    decimal insertedMoney = decimal.Parse(Console.ReadLine());
                }
                else if (input == "2")
                {
                    Console.WriteLine("Performing submenu option 2");
                }
                else if (input == "3")
                {
                    Console.WriteLine("Returning to main menu");
                    break;
                }
                else if (input == "Q" || input == "q")
                {

                }
                else
                {
                    Console.WriteLine("Please try again");
                }

            }
        }
    }
}
