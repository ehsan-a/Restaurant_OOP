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
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public Personnel(string firstName, string lastName, string idNumber, string address, string userName, string password, bool isAdmin)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            Address = address;
            UserName = userName;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}
