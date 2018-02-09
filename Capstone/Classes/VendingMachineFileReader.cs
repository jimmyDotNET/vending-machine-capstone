using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachineFileReader
    {

        private string FilePath;

        public VendingMachineFileReader(string filepath)
        {
            FilePath = filepath;
        }

        public Dictionary<string, List<VendingMachineItem>> GetInventory()
        {
            Dictionary<string, List<VendingMachineItem>> inventory = new Dictionary<string, List<VendingMachineItem>>();

            try
            {
                using (StreamReader sr = new StreamReader("vend.csv"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        string[] inventoryInput = line.Split('|');

                        string slotID = inventoryInput[0];
                        string itemName = inventoryInput[1];
                        decimal price = decimal.Parse(inventoryInput[2]);

                        List<VendingMachineItem> inventoryItems = new List<VendingMachineItem>();

                        for (int i = 0; i < 5; i++)
                        {
                            if (slotID.StartsWith("A"))
                            {
                                inventoryItems.Add(new ChipItem(itemName, price));
                            }
                            else if (slotID.StartsWith("B"))
                            {
                                inventoryItems.Add(new CandyItem(itemName, price));
                            }
                            else if (slotID.StartsWith("C"))
                            {
                                inventoryItems.Add(new DrinkItem(itemName, price));
                            }
                            else if (slotID.StartsWith("D"))
                            {
                                inventoryItems.Add(new GumItem(itemName, price));
                            }
                        }
                        inventory.Add(slotID, inventoryItems);
                    }
                }
            }
            catch(IOException ex)
            {
                Console.WriteLine("There was an error");
            }
            return inventory;
        }

    }
}
