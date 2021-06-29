using Database.Configurations;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Database.Repositories.LineItems
{
     
    public class LineItemRepository : ILineItemRepository
    {
        private readonly StoreContext _context;
        public LineItemRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task CreateLineItemAsync(LineItem lineItem, CancellationToken cancellationToken = default)
        {
            await _context.LineItems.AddAsync(lineItem);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void DeleteLineItem(LineItem lineItem)
        {
            _context.LineItems.Remove(lineItem);
            _context.SaveChanges();
        }

        public async Task<List<LineItem>> RetrieveLineItemsAsync(CancellationToken cancellationToken)
        {
            return await _context.LineItems.ToListAsync(cancellationToken);
        }

        public async Task<LineItem> RetrieveSingleLineItemAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            return await _context.LineItems.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
        }

        public void UpdateLineItme(LineItem lineItem)
        {
            _context.LineItems.Update(lineItem);
            _context.SaveChanges();
        }
    }
}
