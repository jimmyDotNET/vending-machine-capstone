using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public decimal Balance { get; private set; }

        private Dictionary<string, Stack<VendingMachineItem>> Inventory { get; }

        public string[] Slots { get; }

        public void FeedMoney(int dollars)
        {
            Balance += dollars;
        }

        public VendingMachineItem GetItemAtSlot(string slot)
        {
            return Inventory[slot].Peek();
        }

        public int GetQuantityRemaining(string slot)
        {
            return Inventory[slot].Count();
        }

        public VendingMachineItem Purchase(string slot)
        {
            return Inventory[slot].Pop();
        }

        public Change ReturnChange()
        {
            
        }
    }
}
