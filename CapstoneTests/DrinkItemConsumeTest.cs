using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{

    [TestClass]
    public class DrinkItemTests
    {
        [TestMethod]
        public void DrinkItem()
        {
            string item = "";

            decimal price = 0.00M;

            DrinkItem testClass = new DrinkItem(item, price);

            string result = testClass.Consume();

            Assert.AreEqual("Glug Glug, Yum!", result);

        }
    }
}

