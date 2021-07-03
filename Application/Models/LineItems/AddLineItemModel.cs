using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.LineItems
{
    public class AddLineItemModel
    {
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
    }
}
