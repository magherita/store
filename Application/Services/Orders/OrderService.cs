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

        public OrderService( IOrderRepository orderRepository, ILogger<OrderService> logger )
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }
        public async Task<OrderModel> AddOrderAsync(AddOrderModel model, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Adding order...");

            if (model == null)
            {
                _logger.LogError("No order details were provided");
                throw new Exception("No order details were provided!");
            }

            _logger.LogInformation("Mapping the order model to order domain");

            var order = new Order
            {
                Total = model.Total,
                Status = model.Status,
                CustomerId = model.CustomerId,
                LineItems = model.LineItems.Select(x => new LineItem { ProductId= x.ProductId, Quantity = x.Quantity } ).ToList()
            };

            _logger.LogInformation("Creating order in db");

            await _orderRepository.CreateOrderRepositoryAsync(order, cancellationToken);

            var orderJson = JsonConvert.SerializeObject(
                order, 
                new JsonSerializerSettings 
                { 
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore 
                });

            _logger.LogInformation($"the order result is {orderJson}");

            return new OrderModel
            {
                Id = order.Id,
                Total = order.Total,
                Status = order.Status,
                CustomerId = order.CustomerId
            };
        }

        public async Task DeleteOrderAsync(DeleteOrderModel model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new Exception("No order id was provided!");
            }

            var order = await _orderRepository.RetrieveSingleOrderAsync(model.Id, cancellationToken);

            if (order == null)
            {
                throw new Exception("No order was found in the database!");
            }

            _orderRepository.DeleteOrder(order);
        }

        public async Task<OrderModel> GetCustomerOrderAsync(Guid customerId, CancellationToken cancellationToken = default)
        {
            var customerOrder = await _orderRepository.RetrieveCustomerOrderAsync(customerId, cancellationToken);

            if (customerOrder == null)
            {
                throw new Exception($"No order found for customer with id {customerId}");
            }

            // map from order to order model
            return new OrderModel 
            {
                Id = customerOrder.Id,
                CustomerId = customerOrder.CustomerId,
                Status = customerOrder.Status,
                Total = customerOrder.Total,
                LineItems = customerOrder.LineItems.Select(x => new LineItemModel
                { 
                    Id = x.Id,
                    OrderId = x.OrderId,
                    ProductId = x.ProductId,
                    Quantity = x.Quantity
                }).ToList(),
            };
        }

        public async Task<OrderModel> GetOrderAsync(Guid orderId, CancellationToken cancellationToken = default)
        {
            var order = await _orderRepository.RetrieveSingleOrderAsync(orderId, cancellationToken);

            if (order == null)
            {
                throw new Exception($"No order was found in the database with id {orderId}!");
            }

            // map customer to the customer model
            return new OrderModel
            {
                Id = order.Id,
                Total = order.Total,
                Status = order.Status,
                CustomerId = order.CustomerId,
                LineItems = order.LineItems.Select(x => new LineItemModel { OrderId = x.OrderId, ProductId = x.ProductId, Quantity = x.Quantity, Id = x.Id }).ToList()
            };
        }

        public async Task<List<OrderModel>> GetOrderListAsync(CancellationToken cancellationToken = default)
        {
            var orders = await _orderRepository.RetrieveOrdersAsync(cancellationToken);

            var models = new List<OrderModel>();

            foreach (var order in orders)
            {
                var model = new OrderModel
                {
                    Id = order.Id,
                    Total = order.Total,
                    Status = order.Status,
                    CustomerId = order.CustomerId,
                    LineItems = order.LineItems.Select(x => new LineItemModel { OrderId = x.OrderId, ProductId = x.ProductId, Quantity = x.Quantity, Id = x.Id } ).ToList()
                };

                models.Add(model);
            }

            return models;
        }

        public async Task<OrderModel> UpdateOrderAsync(UpdateOrderModel model, CancellationToken cancellationToken = default)
        {
            var order = await _orderRepository.RetrieveSingleOrderAsync(model.Id, cancellationToken);

            if (order == null)
            {
                throw new Exception($"No order was found in the database with id {model.Id}!");
            }

            order.Total = model.Total;
            order.Status = model.Status;
            order.CustomerId = model.CustomerId;

            _orderRepository.UpdateOrder(order);

            return new OrderModel
            {
                Id = order.Id,
                Total = order.Total,
                Status = order.Status,
                CustomerId = order.CustomerId,
            };
        }
    }
}
