using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {

        private readonly StoreContext _context;

        public ProductRepository (StoreContext context)
	    {
            this._context = context; 
	    }

        public async Task CreateProductAsync(Product  product, CancellationToken cancellationToken = default)
        {
           await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync(cancellationToken);
        }


        public Task DeleteProduct(Product product, CancellationToken cancellationToken = default)
        {
            _context.Remove(product);


        }

        public Task<Product> RetrieveProductAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> RetrieveProductAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(Product product, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
