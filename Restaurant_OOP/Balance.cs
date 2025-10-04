using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_OOP
{
    internal class Balance
    {
        public int CustomerId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public Balance(int customerId, decimal amount, DateTime date)
        {
            CustomerId = customerId;
            Amount = amount;
            Date = date;
        }
    }
}
