using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_OOP
{
    internal class FoodQty
    {
        public int FoodId { get; set; }
        public DateTime Date { get; set; }
        public int Qty;
        public FoodQty(int foodId, int qty, DateTime date)
        {
            FoodId = foodId;
            Date = date;
            Qty = qty;
        }
    }
}
