using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public decimal Balance { get; private set; } = 2.00m;

        private Dictionary<string, List<VendingMachineItem>> Inventory { get; }

        public string[] Slots
        {
            get
            {
                return Inventory.Keys.ToArray();
            }
        }

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
            if (Inventory[slot].Count > 0)
            {
                return Inventory[slot][0];
            }
            else
            {
                return null;
            }

        }

        public int GetQuantityRemaining(string slot)
        {
            return Inventory[slot].Count();
        }

        public void Purchase(string slot, VendingMachine vendingMachine)
        {

            // check if item is in stock - if not, return "out of stock"
            if (GetQuantityRemaining(slot) == 0)
            {
                Console.WriteLine(" ");
                Console.Write("SOLD OUT!");
                Console.WriteLine(" ");
            }
            else if (Balance < vendingMachine.GetItemAtSlot(slot).Price)
            {
                // check if user has enough money - if not return "insufficient funds"
                Console.WriteLine(" ");
                Console.Write("INSUFFICIENT FUNDS!");
                Console.WriteLine(" ");

            }
            else if (GetQuantityRemaining(slot) > 0 && vendingMachine.GetItemAtSlot(slot).Price <= Balance)
            { 
                // remove item from top of list
                Inventory[slot].RemoveAt(0);
                // subtract amount spent from balance            
                Balance -= vendingMachine.GetItemAtSlot(slot).Price;
                // write message to console IE "You have purchased {item name}"
            }
        }

        public Change ReturnChange()
        {
            return new Change(Balance);
        }
    }
}
