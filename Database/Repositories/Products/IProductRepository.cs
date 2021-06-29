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
        Task CreateProductAsync(Product product, CancellationToken cancellationToken);
        Task<Product> RetrieveSignleProductAsync(Guid Id, CancellationToken cancellationToken);
        Task<List<Product>> RetrieveProductsAsync(CancellationToken cancellationToken);
        void UpdateProduct(Product product);
        void DeteleProduct(Product product);

    }
}
