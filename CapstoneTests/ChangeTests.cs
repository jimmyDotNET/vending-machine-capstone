using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ChangeTests
    {
        [TestMethod]
        public void ChangeFor6DollarsAnd40Cents()
        {
            VendingMachine vendingMachine = new VendingMachine();

            decimal total = 6.40m;

            Change change = new Change(total);

            Change result = vendingMachine.ReturnChange();

            Assert.AreEqual(25, change.Quarters);

            Assert.AreEqual(1, change.Dimes);

            Assert.AreEqual(1, change.Nickels);

        }
    }
}
