using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class GumConsumeTest
    {
        [TestMethod]
        public void GumItem()
        {
            string item = "";

            decimal price = 0.00M;

            Capstone.Classes.GumItem testClass = new GumItem(item, price);

            string result = testClass.Consume();

            Assert.AreEqual("Chew Chew, Yum!", result);


        }
        
    }
}
