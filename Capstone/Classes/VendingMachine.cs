using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public decimal Balance { get; private set; } = 0.00m;

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
            VendingMachineFileReader vmfr = new VendingMachineFileReader(@"vend.csv");
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
        public void Purchase(string slot, VendingMachine vendingMachine, List<VendingMachineItem> customer, MainMenu mainmenu)
        {
            VendingMachineItem vmi = vendingMachine.GetItemAtSlot(slot);
            // check if item is in stock - if not, return "out of stock"
            if (vendingMachine.GetQuantityRemaining(slot) == 0 || vmi == null)
            {
                Console.WriteLine();
                Console.Write("SOLD OUT!");
                mainmenu.ErrorBuzz();
                Console.WriteLine();
            }
            // check if user has enough money - if not return "insufficient funds"
            if (Balance < GetItemAtSlot(slot).Price)
            {
                Console.Clear();
                Console.WriteLine();
                Console.Write("INSUFFICIENT FUNDS!");
                mainmenu.ErrorBuzz();
                Console.WriteLine();
            }
            else 
            {
                Console.WriteLine();
                // return what item has been purchased
                Console.WriteLine($"Purchased {vendingMachine.GetItemAtSlot(slot).ItemName}");
                // subtract price of item from balance            
                Balance -= (GetItemAtSlot(slot).Price);
                // add item to customer bin ( list )
                customer.Add(vendingMachine.GetItemAtSlot(slot));
                // remove purchased item from inventory
                Inventory[slot].RemoveAt(0);
            }
        }
        public Change Change()
        {
            // creates an instance of the object containing the make change functions 
            Change change = new Change(Balance);
            Balance = 0.00m;
            return change;
        }
    }
}
