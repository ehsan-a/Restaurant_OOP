using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_OOP
{
    internal class FoodQty
    {
        public int FoodId { get; private set; }
        public DateTime Date { get; private set; }
        public int Qty { get; private set; }
        public FoodQty(int foodId, int qty, DateTime date)
        {
            FoodId = foodId;
            Date = date;
            Qty = qty;
        }
    }
}
