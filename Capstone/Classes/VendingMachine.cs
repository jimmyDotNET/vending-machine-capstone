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

        private Dictionary<string, List<VendingMachineItem>> Inventory { get; }

        public string[] Slots { get; }

        public VendingMachine()
        {
            VendingMachineFileReader vmfr = new VendingMachineFileReader("vend.csv");

            Inventory = vmfr.GetInventory();

        }

        public void FeedMoney(int dollars)
        {
            Balance += dollars;
        }

        public VendingMachineItem GetItemAtSlot(string slot)
        {
            return Inventory[slot][0];
        }

        public int GetQuantityRemaining(string slot)
        {
            return Inventory[slot].Count();
        }

        public void Purchase(string slot)
        {
             // remove from top of list 
        }

        public Change ReturnChange()
        {
            return new Change(Balance);
        }
    }
}
