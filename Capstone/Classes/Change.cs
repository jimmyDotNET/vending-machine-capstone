using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Change
    {
        public int Nickels { get; }

        public int Dimes { get; }

        public int Quarters { get; }

        public decimal Total { get; }

        public Change (decimal total)
        {
            while (total > .25m)
            {
                total -= .25m;
                Quarters++;
            }
            while (total > .10m)
            {
                total -= .10m;
                Dimes++;
            }
            while (total > .05m)
            {
                total -= .5m;
                Nickels++;
            }
        }
    }
}
