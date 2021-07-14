using Database.Configurations;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Database.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {

        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }


        public async Task CreateProductAsync(Product product, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(product);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);

            _context.SaveChanges();
        }

        public async Task<Product> RetrieveProductAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<Product>> RetrieveProductAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);

            _context.SaveChanges();
        }
    }
}
