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

        public Dictionary<string, Stack<VendingMachineItem>> GetInventory()
        {
            try
            {
                using (StreamReader sr = new StreamReader("vend.csv"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        string[] inventoryInput = line.Split('|');
                    }
                }
            }
            catch(IOException ex)
            {
                Console.WriteLine("There was an error");
            }
        }

    }
}
