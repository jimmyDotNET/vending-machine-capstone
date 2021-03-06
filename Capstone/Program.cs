﻿using System;
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
            VendingMachine vendingMachine = new VendingMachine(); // create the vending machine we will be using
            VendingMachineLogger logger = new VendingMachineLogger(@"Logs\log.txt"); // creating an instance of the file logger, located in debug folder
            List<VendingMachineItem> customer = new List<VendingMachineItem>(); // create a list to store purchased items
            MainMenu mainmenu = new MainMenu(); // create the menu UI
            mainmenu.PrintHeader();
            mainmenu.Display(vendingMachine, customer, mainmenu, logger); // display the UI
        }
    }
}
