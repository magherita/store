using Domain.Orders;
using System;

namespace Domain.Customers
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public Order Order { get; set; }
    }
}
