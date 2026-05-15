using ProductApp.Models;
using ProductApp.Data;
using ProductApp.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ProductApp.RepositoryLayer
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = ProductData.Products;

        public void Create(Product product)
        {
            if (products.Any(p => p.ProductID == product.ProductID))
                throw new DuplicateProductException(product.ProductID);

            products.Add(product);
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public Product GetById(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductID == id);

            if (product == null)
                throw new ProductNotFoundException(id);

            return product;
        }

        public void Update(Product product)
        {
            var existing = GetById(product.ProductID);

            existing.ProductName = product.ProductName;
            existing.ProductPrice = product.ProductPrice;
            existing.ProductDesc = product.ProductDesc;
            existing.ProductQuantity = product.ProductQuantity;
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            products.Remove(product);
        }
    }
}