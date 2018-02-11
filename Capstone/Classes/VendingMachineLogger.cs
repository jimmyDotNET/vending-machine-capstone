using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachineLogger
    {

        private string FilePath;

        public VendingMachineLogger(string filepath)
        {
            FilePath = filepath;
        }

        public void RecordTransaction(string transaction, decimal startBalance, decimal transactAmount, decimal finalBalance)
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
        public void SalesRecord(VendingMachineItem item, int amountSold)
        {
            try
            {

            }
            catch
            {

            }

        }
    }
}
