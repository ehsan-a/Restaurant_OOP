using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_OOP
{
    internal class Personnel : Person
    {
        public Personnel(string firstName, string lastName, string idNumber, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            Address = address;
        }
    }
}
