using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ChipItemTests
    {
        [TestMethod]
        public void ChipItem()
        {
            string item = "";

            decimal price = 0.00M;

            ChipItem testClass = new ChipItem(item, price);

            string result = testClass.Consume();

            Assert.AreEqual("Crunch Crunch, Yum!", result);

        }
    }
}