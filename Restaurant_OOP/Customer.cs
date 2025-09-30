using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_OOP
{
    internal class Customer : Person
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<decimal> Balance { get; set; }
        public List<Order> Orders { get; private set; }
        public Customer(string firstName, string lastName, string idNumber, string address, string username, string password)
        {
            Balance = new List<decimal>();
            Orders = new List<Order>();
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            Address = address;
            this.Username = username;
            this.Password = password;
        }
        public decimal GetBalance()
        {
            return Balance.Sum() - Orders.Sum(m => m.OrderSum());
        }
    }
}
