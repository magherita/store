using Application.Models.Products;
using Database.Repositories.Products;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductModel> AddProductAsync(AddProductModel model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new Exception("No product details were provided!");
            }

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Quatity = model.Quatity,
                Category = model.Category
            };

            await _productRepository.CreateProductAsync(product, cancellationToken);

            return new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quatity = product.Quatity,
                Category = product.Category
            };
        }

        public async Task DeleteProductAsync(DeleteProductModel model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new Exception("No product id was provided!");
            }

            var product = await _productRepository.RetrieveSignleProductAsync(model.Id, cancellationToken);

            if (product == null)
            {
                throw new Exception("No product was found in the database!");
            }

            _productRepository.DeteleProduct(product);
        }

        public async Task<ProductModel> GetProductAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.RetrieveSignleProductAsync(productId, cancellationToken);

            if (product == null)
            {
                throw new Exception($"No product was found in the database with id {productId}!");
            }

            // map customer to the customer model
            return new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quatity = product.Quatity,
                Category = product.Category
            };
        }

        public async Task<List<ProductModel>> GetProductListAsync(CancellationToken cancellationToken = default)
        {
            var products = await _productRepository.RetrieveProductsAsync(cancellationToken);

            var models = new List<ProductModel>();

            foreach (var product in products)
            {
                var model = new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quatity = product.Quatity,
                    Category = product.Category
                };

                models.Add(model);
            }

            return models;
        }

        public async Task<ProductModel> UpdateProductAsync(UpdateProductModel model, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.RetrieveSignleProductAsync(model.Id, cancellationToken);

            if (product == null)
            {
                throw new Exception($"No product was found in the database with id {model.Id}!");
            }

            product.Name = model.Name;
            product.Price = model.Price;
            product.Quatity = model.Quatity;
            product.Category = model.Category;

            _productRepository.UpdateProduct(product);

            return new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quatity = product.Quatity,
                Category = product.Category
            };
        }
    }
}
