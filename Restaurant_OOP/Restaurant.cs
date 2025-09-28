using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_OOP
{
    internal class Restaurant
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public List<Menu> Menus { get; private set; }
        public List<Customer> Customers { get; private set; }
        public List<Personnel> Personnels { get; private set; }
        public Restaurant(string name, string description, string address)
        {
            Menus = new List<Menu>();
            Customers = new List<Customer>();
            Personnels = new List<Personnel>();
            this.Name = name;
            this.Description = description;
            this.Address = address;
        }
        public void AddMenu(Menu menu)
        {
            Menus.Add(menu);
        }
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }
        public void AddPersonnel(Personnel personnel)
        {
            Personnels.Add(personnel);
        }
        public void AddItemOrder(Order order, Menu menu, int qty)
        {
            order.MenuList.Add(menu, qty);
        }
        public void AddOrder(Customer customer, Order order)
        {
            customer.Orders.Add(order);
        }
        public void ChargeBalance(Customer customer, decimal balance)
        {
            customer.Balance.Add(balance);
        }
        public override string ToString()
        {
            return $"Restaurant: [{Name}] - Description: [{Description}] - Address: [{Address}]";
        }
        public IEnumerable<string> GetMenu()
        {
            return Menus.Select(menu => $"Name: [{menu.Name}] - Description: [{menu.Description}] - Price: [{menu.Price}]");
        }
        public IEnumerable<string> GetPersonnel()
        {
            return Personnels.Select(personnel => $"Name: [{personnel.FirstName} {personnel.LastName}] - ID Number: [{personnel.IdNumber}] - Address: [{personnel.Address}]");
        }
        public IEnumerable<string> GetCustomer()
        {
            return Customers.Select(customer => $"Name: [{customer.FirstName} {customer.LastName}] - ID Number: [{customer.IdNumber}] - Address: [{customer.Address}] - Orders: [{customer.Orders.Count}] - Balance: [{customer.GetBalance()}]");
        }
        public IEnumerable<string> GetOrderDetail(Order order)
        {
            return order.MenuList.Select(detail => $"Name: [{detail.Key.Name}] - Price: [{detail.Key.Price}] - Qty: [{detail.Value}] - Sum: [{detail.Key.Price * detail.Value}]");
        }
        public IEnumerable<string> GetOrder(Customer customer)
        {
            return customer.Orders.Select(order => $"ID: [{order.Id}] - Date: [{order.Date}] - Customer: [{customer.FirstName} {customer.LastName}] - Status: [{order.Status}] - Sum: [{order.OrderSum()}]");
        }
    }
}
