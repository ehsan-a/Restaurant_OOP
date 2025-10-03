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
        public bool IsAdmin { get; set; }
        public Personnel(int id, string firstName, string lastName, string idNumber, string address, string userName, string password, bool isAdmin=false)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            Address = address;
            Username = userName;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}
