using Application.Models.LineItems;
using Application.Models.Orders;
using Application.Services.Orders;
using Database.Repositories.Orders;
using Domain.Orders;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Test
{
    public class OrderServiceTests
    {
        private OrderModel _orderModel;
        private Guid _customerId;

        private Mock<IOrderRepository> _orderRepository;
        private ILogger<OrderService> _logger;

        private OrderService _orderService;

        public OrderServiceTests(ITestOutputHelper testOutputHelper)
        {
            // arrange
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

            _orderRepository = new Mock<IOrderRepository>();           

            _logger = testOutputHelper.BuildLoggerFor<OrderService>();

            _orderService = new OrderService(_orderRepository.Object, _logger);
        }       

        // get customer order from db --done
        // check whther is not null, if null throw exceptions -- done
        // map the order to the order model and return -- done

        [Fact]
        public async Task OrderService_ShouldGetCustomerOrderFromTheDatabase()
        {
            // Act
            // return an order from db
            _orderRepository.Setup(x => x.RetrieveCustomerOrderAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(new Order
               {
                   CustomerId = _orderModel.CustomerId,
                   Id = _orderModel.Id,
                   Status = _orderModel.Status,
                   Total = _orderModel.Total,
                   LineItems = _orderModel.LineItems.Select(x => new LineItem
                   {
                       Id = x.Id,
                       ProductId = x.ProductId,
                       Quantity = x.Quantity
                   }).ToList()
               });

            await _orderService.GetCustomerOrderAsync(_customerId, It.IsAny<CancellationToken>());

            _orderRepository.Verify(
                x => x.RetrieveCustomerOrderAsync(It.Is<Guid>(id => id == _customerId), It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Fact]
        public async Task OrderService_ShouldThrowAnExceptionWhenCustomerOrderIsNull()
        {
            // arrange
            // return null from db
            _orderRepository.Setup(x => x.RetrieveCustomerOrderAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()));

            // assert
            await Assert.ThrowsAsync<Exception>(async () => await _orderService.GetCustomerOrderAsync(_customerId, It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task OrderService_ShouldGetCustomerOrderWithoutThrowingAnException()
        {
            // return an order from db
            _orderRepository.Setup(x => x.RetrieveCustomerOrderAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(new Order
               {
                   CustomerId = _orderModel.CustomerId,
                   Id = _orderModel.Id,
                   Status = _orderModel.Status,
                   Total = _orderModel.Total,
                   LineItems = _orderModel.LineItems.Select(x => new LineItem
                   {
                       Id = x.Id,
                       ProductId = x.ProductId,
                       Quantity = x.Quantity
                   }).ToList()
               });

            var result = await _orderService.GetCustomerOrderAsync(_customerId, It.IsAny<CancellationToken>());

            Assert.IsType<OrderModel>(result);
            Assert.NotNull(result);
            Assert.Equal(result.CustomerId, _customerId);
            Assert.Equal(result.Id, _orderModel.Id);
            Assert.Equal(result.Total, _orderModel.Total);
            Assert.Equal(result.Status, _orderModel.Status);
            Assert.Equal(result.LineItems[0].Quantity, _orderModel.LineItems[0].Quantity);
        }
    }
}
