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
        private readonly IProductRepository _productRespository;

        public ProductService(IProductRepository productRespository)
        {
            _productRespository = productRespository;
        }
        public async Task<ProductModel> AddProductAsync(AddProductModel model, CancellationToken cancellationToken = default)
        {
            // ensure the model is not null
            if (model == null)
            {
                throw new Exception("No Product details were provided!");
            }

            // map model to the product domain
            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Quatity = model.Quatity,
                Category = model.Category,
                LineItems = model.LineItems
            };

            // create and save the Product
            await _productRespository.CreateProductAsync(product, cancellationToken);

            // product has been saved
            // map product to product model and return
            return new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quatity = product.Quatity,
                Category = product.Category,
                LineItems = product.LineItems

            };
        }

        public async Task DeleteProductAsync(DeleteProductModel model, CancellationToken cancellationToken = default)
        {
            // ensure the model is not null
            if (model == null)
            {
                throw new Exception("No Product id was provided!");
            }

            // get product using provided id
            var product = await _productRespository.RetrieveProductAsync(model.Id, cancellationToken);
           

            // ensure the customer is not null
            if (product == null)
            {
                throw new Exception("No product was found in the database!");
            }

            // delete the product
            _productRespository.DeleteProduct(product);
           
        }

        public async Task<List<ProductModel>> GetAllProductsAsync(CancellationToken cancellationToken = default)
        {
            // get products from database
            var products = await _productRespository.RetrieveProductAsync(cancellationToken);

            // map customer list to customer model list
            var models = new List<ProductModel>();

            foreach (var product in products)
            {
                var model = new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quatity = product.Quatity,
                    Category = product.Category,
                    LineItems = product.LineItems
                };

                models.Add(model);
            }

            return models;
        }

        public async Task<ProductModel> GetProductAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            // get product from database
            var product = await _productRespository.RetrieveProductAsync(productId, cancellationToken);

            // ensure the product is not null
            if (product == null)
            {
                throw new Exception($"No product was found in the database with id {productId}!");
            }

            // map product to the product model
            return new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quatity = product.Quatity,
                Category = product.Category,
                LineItems = product.LineItems
            };
        }

        public async Task<ProductModel> UpdateProductAsync(UpdateProductModel model, CancellationToken cancellationToken = default)
        {
            // verify the product already exists in the database
            var product = await _productRespository.RetrieveProductAsync(model.Id, cancellationToken);
           

            // ensure the product exists
            if (product == null)
            {
                throw new Exception($"No product was found in the database with id {model.Id}!");
            }

            // update exisiting product details with new details from the model
            product.Name = product.Name;
            product.Price = product.Price;
            product.Quatity = product.Quatity;
            product.Category = product.Category;
            product.LineItems = product.LineItems;

            // update the product in the database
            _productRespository.UpdateProduct(product);

            return new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quatity = product.Quatity,
                Category = product.Category,
                LineItems = product.LineItems
            };
        }
    }
}
