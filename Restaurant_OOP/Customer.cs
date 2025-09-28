using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_OOP
{
    internal class Customer : Person
    {
        public List<decimal> Balance { get; set; }
        public List<Order> Orders { get; private set; }
        public Customer(string firstName, string lastName, string idNumber, string address)
        {
            Balance = new List<decimal>();
            Orders = new List<Order>();
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            Address = address;
        }
        public decimal GetBalance()
        {
            return Balance.Sum() - Orders.Sum(m => m.OrderSum());
        }
    }
}
