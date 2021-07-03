using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Orders
{
    public class AddOrderModel
    {
        public double Total { get; set; }
        public OrderStatus Status { get; set; }
        public Guid CustomerId { get; set; }
    }
}
