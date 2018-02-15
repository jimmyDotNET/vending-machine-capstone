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

        public void RecordTransaction(string transaction, decimal startBalance, decimal transactAmount, decimal finalBalance)
        {
            try
            {
                if (!Directory.Exists("Logs"))
                {
                    Directory.CreateDirectory("Logs");
                }
                using (StreamWriter logger = new StreamWriter(FilePath, true))
                {
                    logger.WriteLine($"{DateTime.Now} {transaction}: {startBalance} {transactAmount} {finalBalance}");
                }
            }
            catch (IOException)
            {
                Console.WriteLine();
                ErrorBuzz();
                Console.WriteLine("Sales Logging Error");
                Console.WriteLine();
            }
        }
    }
}


