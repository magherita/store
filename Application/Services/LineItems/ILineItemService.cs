using Application.Models.LineItems;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.LineItems
{
    public interface ILineItemService
    {
        Task<LineItemModel> AddLineItemAsync(
            AddLineItemModel model, CancellationToken cancellationToken = default);
        Task<LineItemModel> UpdateLineItemAsync(
            UpdateLineItemModel model,
            CancellationToken cancellationToken = default);

        Task DeleteLineItemAsync(
            DeleteLineItemModel model,
            CancellationToken cancellationToken = default);

        Task<LineItemModel> GetLineItemAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        Task<List<LineItemModel>> GetLineItemListAsync(CancellationToken cancellationToken = default);
    }
}
