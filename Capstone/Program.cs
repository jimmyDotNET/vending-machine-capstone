using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone
{
    class Program
    {
        public static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();
            List<VendingMachineItem> customer = new List<VendingMachineItem>();
            MainMenu mainmenu = new MainMenu();
            mainmenu.Display(vendingMachine, customer);
        }
    }
}
