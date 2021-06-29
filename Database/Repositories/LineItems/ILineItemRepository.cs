using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Database.Repositories.LineItems
{
    public interface ILineItemRepository
    {
        Task CreateLineItemAsync(LineItem lineItem, CancellationToken cancellationToken = default);
        Task<LineItem> RetrieveSingleLineItemAsync(Guid Id, CancellationToken cancellationToken = default);
        Task<List<LineItem>> RetrieveLineItemsAsync(CancellationToken cancellationToken);
        void DeleteLineItem(LineItem lineItem);
        void UpdateLineItme(LineItem lineItem);


    }
}
