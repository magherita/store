using Database.Configurations;
using Domain.Products;
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
            await _context.AddAsync(new Product { });

            await _context.SaveChangesAsync(cancellationToken);
        }

        public void DeleteProductAsync(Product product)
        {
            _context.Products.Remove(product);

            _context.SaveChanges();
        }

        public Task<Product> RetrieveProductAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> RetrieveProductAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);

            _context.SaveChanges();
        }
    }
}
