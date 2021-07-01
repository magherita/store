using Domain.Orders;
using System;

namespace Application.Models.Orders
{
    public class OrderModel
    {
        public Guid Id { get; set; }

        public double Total { get; set; }

        public OrderStatus Status { get; set; }

        public Guid CustomerId { get; set; }
    }
}
