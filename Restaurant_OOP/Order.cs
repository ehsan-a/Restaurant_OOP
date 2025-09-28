using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_OOP
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<Menu, int> MenuList { get; set; }
        public Order(int id, DateTime date)
        {
            MenuList = new Dictionary<Menu, int>();
            Id = id;
            Date = date;
        }
        public decimal OrderSum()
        {
            return MenuList.Sum(m => m.Key.Price * m.Value);
        }
    }
}
