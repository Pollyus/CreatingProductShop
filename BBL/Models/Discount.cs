using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class Discount
    {
        public Discount(decimal value)
        {
            this.value = value;
        }

        private decimal value;

        public decimal MakeDiscount(decimal sum)
        {
            if (DateTime.Today.Month == 10 | DateTime.Today.Month == 4 | DateTime.Today.Month == 1 | DateTime.Today.Month == 7)
            {
                return sum - sum * value;
            }
            return sum;
        }
    }
}
