using ProductApp.Models;
using System.Collections.Generic;

namespace ProductApp.ServiceLayer
{
    public interface IProductService
    {
        void AddProduct(Product product);
        List<Product> GetProducts();
        void UpdateProduct(Product product);
        void RemoveProduct(int id);
    }
}