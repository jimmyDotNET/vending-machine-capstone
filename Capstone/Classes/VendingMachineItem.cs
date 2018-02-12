using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VendingMachineItem
    {
        public string ItemName { get; protected set; }

        public decimal Price { get; protected set; }

        public VendingMachineItem(string item, decimal price)
        {
            ItemName = item;

            Price = price;
        }
    
        public virtual string Consume()
        {
            return " ";
        }
    }
}