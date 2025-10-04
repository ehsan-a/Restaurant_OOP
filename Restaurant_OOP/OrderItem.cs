using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_OOP
{
    internal class OrderItem
    {
        public int OrderId { get; private set; }
        public int FoodId { get; private set; }
        public int Qty { get; private set; }
        public OrderItem(int orderId, int foodId, int qty)
        {
            OrderId = orderId;
            FoodId = foodId;
            Qty = qty;
        }
    }
}
