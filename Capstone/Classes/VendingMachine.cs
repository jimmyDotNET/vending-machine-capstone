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
            if (Balance < GetItemAtSlot(slot).Price)// check if user has enough money - if not return "insufficient funds"
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
                Console.WriteLine($"Purchased {vendingMachine.GetItemAtSlot(slot).ItemName}");
                // remove item from top of list
                // subtract amount spent from balance            
                Balance -= (GetItemAtSlot(slot).Price);  
                customer.Add(vendingMachine.GetItemAtSlot(slot));
                Inventory[slot].RemoveAt(0);
            }
        }
        public Change ReturnChange()
        {
            Change change = new Change(Balance);
            Balance = 0.00m;
            return change;
        }
    }
}
