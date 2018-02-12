using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine(); // create the vending machine we will be using to have it available throughout the program
            VendingMachineLogger logger = new VendingMachineLogger("log.txt"); // creating an instance of the file logger to have it available throughout the program
            Dictionary<string, int> salesAudit = new Dictionary<string, int>(); // dictionary with item name as key and an int as value... we attempted to use this to keep track of the number of items sold
            List<VendingMachineItem> customer = new List<VendingMachineItem>(); // create a list to store purchased items
            MainMenu mainmenu = new MainMenu(); // create the menu UI
            mainmenu.Display(vendingMachine, customer, mainmenu, logger, salesAudit); // display the UI
        }
    }
}
