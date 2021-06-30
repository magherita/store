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
            this._context = context;
        }



        /*
        private readonly StoreContext _context;

        public ProductRepository (StoreContext context)
	    {
            this._context = context; 
	    }

        public Task CreateProductAsync(Product product, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task CreateProductAsync(Product product, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> RetrieveProductAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> RetrieveProductAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Product> RetrieveProductAsync(Guid id, CancellationToken cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> RetrieveProductAsync(CancellationToken cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
        */
        public Task CreateProductAsync(Product product, CancellationToken cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> RetrieveProductAsync(Guid id, CancellationToken cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> RetrieveProductAsync(CancellationToken cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
