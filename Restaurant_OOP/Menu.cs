using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_OOP
{
    internal class Menu
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<int> Qty { get; set; }
        public Menu(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
            Qty = new List<int>();
        }
    }
}
