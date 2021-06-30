using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Database.Repositories.LineItems
{
    public interface ILineItemRepository
    {
        // Define Product CRUD methods.
       
        Task CreateLineItem(LineItem lineItem, CancellationToken cancellationToken = default);

        Task<LineItem> RetrieveLineItemAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<LineItem>> RetrieveLineItemAsync(CancellationToken cancellationToken = default);

        void UpdateLineItem(LineItem lineItem);

        void DeleteLineItem(LineItem lineItem);
    }
}
