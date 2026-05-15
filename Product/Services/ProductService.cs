using ProductApp.Models;
using ProductApp.RepositoryLayer;
using ProductApp.Exceptions;
using System.Collections.Generic;

namespace ProductApp.ServiceLayer
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repo)
        {
            repository = repo;
        }

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new InvalidProductException("Product cannot be null");

            if (string.IsNullOrWhiteSpace(product.ProductName))
                throw new InvalidProductException("Product name cannot be empty");

            if (product.ProductPrice <= 0)
                throw new InvalidProductException("Price must be greater than zero");

            repository.Create(product);
        }

        public List<Product> GetProducts()
        {
            return repository.GetAll();
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
                throw new InvalidProductException("Product cannot be null");

            if (string.IsNullOrWhiteSpace(product.ProductName))
                throw new InvalidProductException("Product name cannot be empty");

            if (product.ProductPrice <= 0)
                throw new InvalidProductException("Invalid price");

            repository.Update(product);
        }

        public void RemoveProduct(int id)
        {
            repository.Delete(id);
        }
    }
}