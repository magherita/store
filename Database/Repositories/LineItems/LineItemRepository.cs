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

        public StoreContext Context { get; }

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

        public async Task<LineItem> RetrieveLineItemAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.LineItems
               .Where(x => x.Id == id)
               .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<LineItem>> RetrieveLineItemAsync(CancellationToken cancellationToken = default)
        {
            return await _context.LineItems.ToListAsync(cancellationToken);
        }

        public void UpdateLineItem(LineItem lineItem)
        {
            _context.LineItems.Update(lineItem);

            _context.SaveChanges();
        }
    }
}
