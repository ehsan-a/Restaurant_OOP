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
        public Customer(int id, string firstName, string lastName, string idNumber, string address, string username, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            Address = address;
            Username = username;
            Password = password;
        }
    }
}
