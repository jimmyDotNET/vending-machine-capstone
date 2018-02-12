using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class CandyItemConsumeTests
    {
        [TestMethod]
        public void CandyItem()
        {
            string item = "";

            decimal price = 0.00M;

            CandyItem testClass = new CandyItem(item, price);
            
            string result = testClass.Consume();

            Assert.AreEqual("Munch Munch, Yum!", result);
          

        }
    }
}
