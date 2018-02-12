using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class GetItemAtSlotTests
    {
        [TestMethod]
        public void HasMoonpieAtB1()
        {
            VendingMachine vendingMachine = new VendingMachine();
           
            VendingMachineFileReader vmfr = new VendingMachineFileReader("vend.csv");

            Dictionary<string, List<VendingMachineItem>> inventory = new Dictionary<string, List<VendingMachineItem>>();

            inventory = vmfr.GetInventory();

            VendingMachineItem result = vendingMachine.GetItemAtSlot("B1");

            Assert.AreEqual("Moonpie", result);
        }
    }
}
