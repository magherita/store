using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Database.Repositories.Products
{
    public interface IProductRepository
    {
        // Define Product CRUD methods.
        Task CreateProductAsync(Product product, CancellationToken cancellationToken = default);

        Task<Product> RetrieveProductAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<Product>> RetrieveProductAsync(CancellationToken cancellationToken = default);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);
    
    }
}
