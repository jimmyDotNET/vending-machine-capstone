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
            System.Media.SoundPlayer loop = new System.Media.SoundPlayer(@".\Elevator-music.wav");
            // :)
            loop.PlayLooping();

            VendingMachine vendingMachine = new VendingMachine(); // create the vending machine we will be using
            VendingMachineLogger logger = new VendingMachineLogger("log.txt"); // creating an instance of the file logger
            List<VendingMachineItem> customer = new List<VendingMachineItem>(); // create a list to store purchased items

            MainMenu mainmenu = new MainMenu(); // create the menu UI
            mainmenu.Display(vendingMachine, customer, mainmenu, logger); // display the UI
        }
    }
}
