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

        public void Purchase(string slot)
        { 

            // check if item is in stock - if not, return "out of stock"
            if (GetQuantityRemaining(slot) > 0)
            {
                // remove item from top of list
                Inventory[slot].RemoveAt(0);
                
                
                // subtract amount spent from balance            

                // write message to console IE "You have purchased {item name}"
            }
            else
            {
                Console.Write("Were friggin walkin here.");
            }
            

                // check if user has enough money - if not return "insufficient funds"




        }

        public Change ReturnChange()
        {
            return new Change(Balance);
        }
    }
}
