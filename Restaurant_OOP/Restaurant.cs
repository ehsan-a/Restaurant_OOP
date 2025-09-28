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
        public void ChargeFoodQty(Menu menu, int qty)
        {
            menu.Qty.Add(qty);
        }
        public void ChangeStatus(Order order, Order.OrderStatus orderStatus)
        {
            order.Status = orderStatus;
        }
        public override string ToString()
        {
            return $"Restaurant: [{Name}] - Description: [{Description}] - Address: [{Address}]";
        }
        public IEnumerable<string> GetMenu()
        {
            //return Menus.Select(menu => $"Name: [{menu.Name}] - Description: [{menu.Description}] - Price: [{menu.Price}] - Qty: [{GetFoodQty(menu)}]");
            return Menus.Select(menu => $"{menu.Name.PadRight(27)}{menu.Description.PadRight(35)}{menu.Price.ToString().PadRight(10)}{GetFoodQty(menu).ToString().PadLeft(5)}");
        }
        public IEnumerable<string> GetPersonnel()
        {
            //return Personnels.Select(personnel => $"Name: [{personnel.FirstName} {personnel.LastName}] - ID Number: [{personnel.IdNumber}] - Address: [{personnel.Address}]");
            return Personnels.Select(personnel => $"{personnel.FirstName.PadRight(12)}{personnel.LastName.PadRight(15)}{personnel.IdNumber.PadRight(11)}{personnel.Address.PadLeft(39)}");
        }
        public IEnumerable<string> GetCustomer()
        {
            //return Customers.Select(customer => $"Name: [{customer.FirstName} {customer.LastName}] - ID Number: [{customer.IdNumber}] - Address: [{customer.Address}] - Orders: [{customer.Orders.Count}] - Balance: [{customer.GetBalance()}]");
            return Customers.Select(customer => $"{customer.FirstName.PadRight(12)}{customer.LastName.PadRight(12)}{customer.IdNumber.PadRight(11)}{customer.Address.PadRight(26)}{customer.Orders.Count.ToString().PadRight(3)}{customer.GetBalance().ToString().PadLeft(13)}");
        }
        public IEnumerable<string> GetOrderDetail(Order order)
        {
            //return order.MenuList.Select(detail => $"Name: [{detail.Key.Name}] - Price: [{detail.Key.Price}] - Qty: [{detail.Value}] - Sum: [{detail.Key.Price * detail.Value}]");
            return order.MenuList.Select(detail => $"{detail.Key.Name.PadRight(30)}{detail.Key.Price.ToString().PadRight(17)}{detail.Value.ToString().PadRight(15)}{(detail.Key.Price * detail.Value).ToString().PadLeft(15)}");

        }
        public IEnumerable<string> GetOrder(Customer customer)
        {
            //return customer.Orders.Select(order => $"ID: [{order.Id}] - Date: [{order.Date}] - Customer: [{customer.FirstName} {customer.LastName}] - Status: [{order.Status}] - Sum: [{order.OrderSum()}]");
            return customer.Orders.Select(order => $"{order.Id.ToString().PadRight(4)}{(customer.FirstName + " " + customer.LastName).PadRight(24)}{order.Date.ToString().PadRight(30)}{order.Status.ToString().PadRight(10)}{order.OrderSum().ToString().PadLeft(9)}");
        }
        public int GetFoodQty(Menu menu)
        {
            int sum = 0;
            foreach (var item in Customers)
            {
                foreach (var item2 in item.Orders)
                {
                    foreach (var item3 in item2.MenuList)
                    {
                        if (item3.Key.Name == menu.Name)
                            sum += item3.Value;
                    }
                }
            }
            return menu.Qty.Sum() - sum;
        }
    }
}
