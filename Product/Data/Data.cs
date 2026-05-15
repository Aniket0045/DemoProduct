using ProductApp.Models;
using System.Collections.Generic;

namespace ProductApp.Data
{
    public static class ProductData
    {
        public static List<Product> Products = new List<Product>()
        {
            new Product { ProductID = 1, ProductName = "Laptop", ProductPrice = 50000, ProductDesc = "Gaming Laptop", ProductQuantity = 5 },
            new Product { ProductID = 2, ProductName = "Phone", ProductPrice = 20000, ProductDesc = "Android Phone", ProductQuantity = 10 }
        };
    }
}