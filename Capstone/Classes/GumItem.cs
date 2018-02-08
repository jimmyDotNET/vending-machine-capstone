using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    class GumItem : VendingMachineItem
    {

        public GumItem(string item, decimal price) : base (item, price)
        {
            ItemName = item;

            Price = price;
        }

        public override string Consume()
        {
            return "Chew Chew, Yum!";
        }
    }
}
