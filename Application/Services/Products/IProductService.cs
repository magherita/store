using Application.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Products
{
    public interface IProductService
    {
        Task<ProductModel> AddProductAsync(
           AddProductModel model,
           CancellationToken cancellationToken = default);

        Task<ProductModel> UpdateProductAsync(
            UpdateProductModel model,
            CancellationToken cancellationToken = default);

        Task DeleteProductAsync(
            DeleteProductModel model,
            CancellationToken cancellationToken = default);

        Task<ProductModel> GetProductAsync(
            Guid productId,
            CancellationToken cancellationToken = default);

        Task<List<ProductModel>> GetAllProductsAsync(CancellationToken cancellationToken = default);
    }
}
