using Application.Models.LineItems;
using Database.Repositories.LineItems;
using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.LineItems
{
    public class LineItemService : ILineItemService
    {
        private readonly ILineItemRepository _lineItemRepository;
        public LineItemService(ILineItemRepository lineItemRepository)
        {
            _lineItemRepository = lineItemRepository;
        }
        public async Task<LineItemModel> AddLineItemAsync(AddLineItemModel model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new Exception("No lineItem details were provided!");
            }

            var lineItem = new LineItem
            {
                Quantity = model.Quantity,
                ProductId = model.ProductId,
                OrderId = model.OrderId
            };

            await _lineItemRepository.CreateLineItemAsync(lineItem, cancellationToken);

            return new LineItemModel
            {
                Id = lineItem.Id,
                Quantity = lineItem.Quantity,
                ProductId = lineItem.ProductId,
                OrderId = lineItem.OrderId
            };
        }

        public async Task DeleteLineItemAsync(DeleteLineItemModel model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new Exception("No lineItem id was provided!");
            }

            var lineItem = await _lineItemRepository.RetrieveSingleLineItemAsync(model.Id, cancellationToken);

            if (lineItem == null)
            {
                throw new Exception("No line Item was found in the database!");
            }

            _lineItemRepository.DeleteLineItem(lineItem);
        }

        public async Task<LineItemModel> GetLineItemAsync(Guid lineItemId, CancellationToken cancellationToken = default)
        {
            var lineItem = await _lineItemRepository.RetrieveSingleLineItemAsync(lineItemId, cancellationToken);

            if (lineItem == null)
            {
                throw new Exception($"No line Item was found in the database with id {lineItemId}!");
            }

            // map customer to the customer model
            return new LineItemModel
            {
                Id = lineItem.Id,
                Quantity = lineItem.Quantity,
                ProductId = lineItem.ProductId,
                OrderId = lineItem.OrderId
            };
        }

        public async Task<List<LineItemModel>> GetLineItemListAsync(CancellationToken cancellationToken = default)
        {
            var lineItems = await _lineItemRepository.RetrieveLineItemsAsync(cancellationToken);

            var models = new List<LineItemModel>();

            foreach (var lineItem in lineItems)
            {
                var model = new LineItemModel
                {
                    Id = lineItem.Id,
                    Quantity = lineItem.Quantity,
                    ProductId = lineItem.ProductId,
                    OrderId = lineItem.OrderId
                };

                models.Add(model);
            }

            return models;
        }

        public async Task<LineItemModel> UpdateLineItemAsync(UpdateLineItemModel model, CancellationToken cancellationToken = default)
        {
            var lineItem = await _lineItemRepository.RetrieveSingleLineItemAsync(model.Id, cancellationToken);

            if (lineItem == null)
            {
                throw new Exception($"No line Item was found in the database with id {model.Id}!");
            }

            lineItem.Quantity = model.Quantity;
            lineItem.ProductId = model.ProductId;
            lineItem.OrderId = model.OrderId;

            _lineItemRepository.UpdateLineItme(lineItem);

            return new LineItemModel
            {
                Id = lineItem.Id,
                Quantity = lineItem.Quantity,
                ProductId = lineItem.ProductId,
                OrderId = lineItem.OrderId
            };
        }
    }
}
