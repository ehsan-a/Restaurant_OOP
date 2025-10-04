using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_OOP
{
    internal class Order
    {
        public enum OrderStatus
        {
            Confirm,
            Preparation,
            Sending,
            Delivery
        }
        public int Id { get; private set; }
        public int CustomerId { get; private set; }
        public DateTime Date { get; private set; }
        public OrderStatus Status { get; private set; }
        public Order(int id, int customerId, DateTime date, OrderStatus orderStatus = 0)
        {
            Id = id;
            CustomerId = customerId;
            Date = date;
            Status = orderStatus;
        }
    }
}
