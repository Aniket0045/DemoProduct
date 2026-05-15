using ProductApp.Models;
using System.Collections.Generic;

namespace ProductApp.RepositoryLayer
{
    public interface IProductRepository
    {
        void Create(Product product);
        List<Product> GetAll();
        Product GetById(int id);
        void Update(Product product);
        void Delete(int id);
    }
}