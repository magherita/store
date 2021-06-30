using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.Products
{
    public interface IProductRepository
    {
        // Define Product CRUD methods.
        Task CreateProductAsync(Product product, CancellationToken cancellationToken = default);

        Task<Product> RetrieveProductAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<Product>> RetrieveProductAsync(CancellationToken cancellationToken = default);

        void UpdateProductAsync(Product product);

        void DeleteProductAsync(Product product);
    
    }
}
