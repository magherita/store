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
            //Ensure the model is not null
            if ( model == null)
            {
                throw new Exception("No LineItem Details provided");
            }

            // Map model to the LineItem Domain
            var lineItem = new LineItem
            {
                Quantity = model.Quantity,
                ProductId = model.ProductId,
                OrderId = model.OrderId
            };

            //Create and save the LineItem
            await _lineItemRepository.CreateLineItemAsync(lineItem, cancellationToken);


            //LineItem has been saved
            // Map LineItem to LineItem model and save.
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
            //Ensure the model is not null
            if (model == null)
            {
                throw new Exception("No LineItem details provided");
            }

            //Get the lineItem using the provided Id
            var lineItem = await _lineItemRepository.RetrieveLineItemAsync(model.Id, cancellationToken);

            //Ensure the LineItem is not null
            if (lineItem == null)
            {
                throw new Exception("No LineItem was found in the database");
            }

            // delete the lineItem
            _lineItemRepository.DeleteLineItem(lineItem);
        }

        public async Task<LineItemModel> GetLineItemAsync(Guid lineItemId, CancellationToken cancellationToken = default)
        {
            // Get the LineItem from the database
            var lineItem = await _lineItemRepository.RetrieveLineItemAsync(lineItemId, cancellationToken);

            //Ensure the LineItem is not Null
            if (lineItem == null)
            {
                throw new Exception($"No LineItem was found in the database with Id {lineItemId}");
            }

            // Map LineItem to the LineItemMOdel
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
            // Get LineItems from the database
            var lineItems = await _lineItemRepository.RetrieveLineItemsAsync(cancellationToken);

            //Map the customer List to the customer model
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
            // Verify if the LineItem exists in the database
            var lineItem = await _lineItemRepository.RetrieveLineItemAsync(model.Id, cancellationToken);

            if (lineItem == null)
            {
                throw new Exception($"No LineItem was found in the database with Id {model.Id}");
            }

            // Update the existing lineItem details with the new LineItem in the model
            lineItem.Quantity = model.Quantity;
            lineItem.ProductId = model.ProductId;
            lineItem.OrderId = model.OrderId;

            //Updat the line Item in the database 
            _lineItemRepository.UpdateLineItem(lineItem);

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
