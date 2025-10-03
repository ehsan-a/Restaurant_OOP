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
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public Order(int id, int customerId, DateTime date, OrderStatus orderStatus = 0)
        {
            Id = id;
            CustomerId = customerId;
            Date = date;
            Status = orderStatus;
        }
    }
}
