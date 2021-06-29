using Domain.Customers;
using System;
using System.Collections.Generic;

namespace Domain.Orders
{
    public class Order
    {
        // Order(Id, LineItem, Customer)
        public Guid Id { get; set; }        

        public double Total { get; set; }

        public OrderStatus Status { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<LineItem> LineItems { get; set; }
    }

    public enum OrderStatus
    {
        Pending = 1,
        Completed = 2,
        Cancelled = 3
    }
}
