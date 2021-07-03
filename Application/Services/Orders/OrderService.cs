using Application.Models.Orders;
using Database.Repositories.Orders;
using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService( IOrderRepository orderRepository )
        {
            _orderRepository = orderRepository;
        }
        public async Task<OrderModel> AddOrderAsync(AddOrderModel model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new Exception("No order details were provided!");
            }

            var order = new Order
            {
                Total = model.Total,
                Status = model.Status,
                CustomerId = model.CustomerId
            };

            await _orderRepository.CreateOrderRepositoryAsync(order, cancellationToken);

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

        public async Task<OrderModel> GetOrderAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            var order = await _orderRepository.RetrieveSingleOrderAsync(productId, cancellationToken);

            if (order == null)
            {
                throw new Exception($"No order was found in the database with id {productId}!");
            }

            // map customer to the customer model
            return new OrderModel
            {
                Id = order.Id,
                Total = order.Total,
                Status = order.Status,
                CustomerId = order.CustomerId
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
                    CustomerId = order.CustomerId
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
