using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class TransactionLogger
    {

        private string FilePath;

        public TransactionLogger(string filepath)
        {
            FilePath = filepath;
        }

        public void RecordDeposit(decimal amount, decimal finalBalance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FilePath))
                {

                }
            }
            catch(IOException ex)
            {

            }
        }

    }
}
