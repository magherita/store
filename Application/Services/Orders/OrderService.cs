using Application.Models.LineItems;
using Application.Models.Orders;
using Database.Repositories.Orders;
using Domain.Orders;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        

        public async Task<OrderModel> AddOrderAsync(AddOrderModel model, CancellationToken cancellationToken = default)
        {
            if ( model == null)
            {
                _logger.LogError("No order details were provided");
                throw new Exception("The Order can not be Empty");
            }

            var order = new Order
            {
                Total = model.Total,
                Status = model.Status,
                CustomerId = model.CustomerId,
                LineItems = model.LineItems.Select(x => new LineItem { ProductId = x.ProductId, Quantity = x.Quantity}).ToList()

            };

            await _orderRepository.CreateOrdersAsync(order, cancellationToken);
            _logger.LogInformation($"the order result is {JsonConvert.SerializeObject(order)}");

            return new OrderModel
            {
                Id = order.Id,
                Total = order.Total,
                Status = order.Status,
                CustomerId = order.CustomerId,
                LineItems = order.LineItems.Select(x => new LineItemModel { ProductId = x.ProductId, Quantity = x.Quantity }).ToList()
            };
           
        }

        public async Task DeleteModelAsync(DeleteOrderModel model, CancellationToken cancellationToken = default)
        {
            // Ensure the model is not null.
            if ( model == null)
            {
                throw new Exception("Order id was not provided");
            }

            // Get order using provided id
            var order = await _orderRepository.RetrieveOrderAsync(model.Id);

            if(order == null)
            {
                throw new Exception("No order was found in the Database.");
            }

            // Delete the order.
            _orderRepository.DeleteOrder(order);
        }

      

        public async Task<OrderModel> GetOrderAsync(Guid orderId, CancellationToken cancellationToken = default)
        {
            // Get order from the database
            var order = await _orderRepository.RetrieveOrderAsync(orderId, cancellationToken);

            // Ensure the order is not null.
            if (order == null)
            {
                throw new Exception($"No order was found in the database with id {orderId}!");
            }

            //Map the order to the orderModel
            return new OrderModel
            {
                Id = order.Id,
                Total = order.Total,
                Status = order.Status,
                CustomerId = order.CustomerId,
                LineItems = order.LineItems.Select(x => new LineItemModel { OrderId = x.OrderId, ProductId = x.ProductId, Quantity = x.Quantity, Id = x.Id }).ToList()
            };
        }

        public async Task<List<OrderModel>> GetOrderModelListAsync(CancellationToken cancellationToken = default)
        {// Get orders from the database
            var orders = await _orderRepository.RetrieveOrderAsync(cancellationToken);

            // map orders list to order model list  
            var models = new List<OrderModel>();

            foreach (var order in orders)
            {
                var model = new OrderModel
                {
                    Id = order.Id,
                    Total = order.Total,
                    Status = order.Status,
                    CustomerId = order.CustomerId
                };

                models.Add(model);

            };

            return models;
        }

        public async Task<OrderModel> UpdateOrderAsync(UpdateOrderModel model, CancellationToken cancellationToken = default)
        {
            // Verify the order exist in the datatbase
            var order = await _orderRepository.RetrieveOrderAsync(model.Id, cancellationToken);

            // Ensure the order exists 
            if (order == null)
            {
                throw new Exception($"No Order was found in the database with id {model.Id}!");

            }

            //Map the model to order
            //Update the existing order details with new details from the model
            order.Total = model.Total;
            order.Status = model.Status;


            // update the order in the database
            _orderRepository.UpdateOrder(order);





            return new OrderModel
            {
                Id = order.Id,
                Total = order.Total,
                Status = order.Status,
                CustomerId = order.CustomerId
            };
        }

        
    }
}
