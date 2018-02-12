using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachineLogger : MainMenu
    {

        private string FilePath;

        public VendingMachineLogger(string filepath)
        {
            FilePath = filepath;
        }

        public void RecordTransaction(string transaction, decimal startBalance, decimal transactAmount, decimal finalBalance, Dictionary<string, int> salesAudit)
        {
            try
            {
                using (StreamWriter logger = new StreamWriter("log.txt", true))
                {
                    logger.WriteLine($"{DateTime.Now} {transaction}: {startBalance} {transactAmount} {finalBalance}");
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Sales Logging Error");
            }
        }
        public void TotalSalesLog(Dictionary<string, int> salesAudit, VendingMachine vendingMachine)
        {
            try
            {
                StreamWriter audit = new StreamWriter("sales-log.txt", true);
                using (StreamReader sr = new StreamReader("log.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        foreach (var kvp in salesAudit)
                        {
                            if (line.Contains(kvp.Key.ToString()))
                            {
                                salesAudit[kvp.Key] += 1;
                            }
                        }
                        foreach (var kvp in salesAudit)
                        {
                            audit.WriteLine($"{kvp.Key} {kvp.Value}");
                        }
                    }
                }
            }
            catch (IOException)
            {

            }
        }
    }
}


