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

        public void RecordTransaction(string dateTime, string transaction, decimal startBalance, decimal transactAmount, decimal finalBalance)
        {
            try
            {
                using (StreamWriter logger = new StreamWriter(FilePath))
                {

                }
            }
            catch (IOException)
            {

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
