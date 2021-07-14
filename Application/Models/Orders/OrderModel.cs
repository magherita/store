using Application.Models.LineItems;
using Domain.Orders;
using System;
using System.Collections.Generic;

namespace Application.Models.Orders
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public double Total { get; set; }
        public OrderStatus Status { get; set; }
        public Guid CustomerId { get; set; }
        public List<LineItemModel> LineItems { get; set; }
    }
}
