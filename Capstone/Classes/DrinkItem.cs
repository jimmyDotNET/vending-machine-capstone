using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class DrinkItem : VendingMachineItem
    {
        public DrinkItem(string item, decimal price) : base (item, price)
        {
            ItemName = item;

            Price = price;
        }

        public override string Consume()
        {
            return "Glug Glug, Yum!";
        }

    }
}
