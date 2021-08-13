using Application.Models.LineItems;
using Application.Models.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreTests
{
    public class OrderServiceTest
    {
        // Arrande , Act & Assert.
        private OrderModel _orderModel;
        private Guid _customerId;
        private Guid _productId;

        //Arrranging
        public OrderServiceTest()
        {
            _customerId = Guid.NewGuid();
            _orderModel = new OrderModel
            {
                Id = Guid.NewGuid(),
                Status = Domain.Orders.OrderStatus.Pending,
                Total = 1000,
                CustomerId = _customerId,
                LineItems = new List<LineItemModel>
                   {
                     new LineItemModel
                     {
                       Quantity = 1,
                       ProductId = Guid.NewGuid(),
                       Id = Guid.NewGuid()
                     },
                     new LineItemModel
                     {
                       Quantity = 2,
                       ProductId = Guid.NewGuid(),
                       Id = Guid.NewGuid()
                     }
                   }
            };
        }
    }
}
