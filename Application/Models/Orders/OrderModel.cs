using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Orders
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public double Total { get; set; }
        public OrderStatus Status { get; set; }
    }
}
