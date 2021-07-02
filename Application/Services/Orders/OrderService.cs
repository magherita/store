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

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        

        public async Task<OrderModel> AddOrderAsync(AddOrderModel model, CancellationToken cancellationToken = default)
        {
            if ( model == null)
            {
                throw new Exception("The Order can not be Empty");
            }

            var order = new Order
            {
                Total = model.Total,
                Status = model.Status
            };

            await _orderRepository.CreateOrdersAsync(order, cancellationToken);

            return new OrderModel
            {
                Id = order.Id,
                Total = order.Total,
                Status = order.Status,
                CustomerId = order.CustomerId
            };
           
        }

        public async Task DeleteModelAsync(DeleteOrderModel model)
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

        public async Task<OrderModel> GetOrderModelAsync(Guid orderId, CancellationToken cancellationToken = default)
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
                CustomerId = order.CustomerId
            };
        }

        public async Task<List<OrderModel>> GetOrderModelListAsync(CancellationToken cancellationToken = default)
        {// Get orders from the database
            var customers = await _orderRepository.RetrieveOrderAsync(cancellationToken);

            // map orders list to order model list  
            var models = new List<OrderModel>();

            foreach (var order in customers)
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

        public async OrderModel UpdateOrderAsync(UpdateOrderModel model, CancellationToken cancellationToken = default)
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
