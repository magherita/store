using Domain.Orders;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.LineItems
{
    public class LineItemModel
    {
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
