using ProductApp.Models;
using ProductApp.RepositoryLayer;
using ProductApp.ServiceLayer;
using ProductApp.Exceptions;
using System;

class Program
{
    static void Main()
    {
        IProductRepository repo = new ProductRepository();
        IProductService service = new ProductService(repo);

        while (true)
        {
            Console.WriteLine("\n1. Create Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");

            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Product ID: ");
                        int newId = Convert.ToInt32(Console.ReadLine());

                        // ✅ Check duplicate immediately
                        var existingProduct = service.GetProducts()
                                                     .FirstOrDefault(p => p.ProductID == newId);

                        if (existingProduct != null)
                            throw new DuplicateProductException(newId);

                        var p = new Product();
                        p.ProductID = newId;

                        Console.Write("Name: ");
                        p.ProductName = Console.ReadLine();

                        Console.Write("Price: ");
                        p.ProductPrice = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Description: ");
                        p.ProductDesc = Console.ReadLine();

                        Console.Write("Quantity: ");
                        p.ProductQuantity = Convert.ToInt32(Console.ReadLine());

                        service.AddProduct(p);
                        Console.WriteLine(" Product added successfully!");
                        break;

                    case 2:
                        var products = service.GetProducts();

                        Console.WriteLine("\nID | Name | Price | Description | Quantity");
                        Console.WriteLine("--------------------------------------------------");

                        foreach (var item in products)
                        {
                            Console.WriteLine($"{item.ProductID} | {item.ProductName} | {item.ProductPrice} | {item.ProductDesc} | {item.ProductQuantity}");
                        }
                        break;

                    case 3:
                        Console.Write("Enter ID to update: ");
                        int updateId = Convert.ToInt32(Console.ReadLine());

                        existingProduct = service.GetProducts()
                                                     .FirstOrDefault(p => p.ProductID == updateId);

                        if (existingProduct == null)
                            throw new ProductNotFoundException(updateId);

                        var update = new Product();
                        update.ProductID = updateId;

                        Console.Write("New Name: ");
                        update.ProductName = Console.ReadLine();

                        Console.Write("New Price: ");
                        update.ProductPrice = Convert.ToDouble(Console.ReadLine());

                        Console.Write("New Description: ");
                        update.ProductDesc = Console.ReadLine();

                        Console.Write("New Quantity: ");
                        update.ProductQuantity = Convert.ToInt32(Console.ReadLine());

                        service.UpdateProduct(update);
                        Console.WriteLine(" Product updated!");
                        break;

                    case 4:
                        Console.Write("Enter ID to delete: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        service.RemoveProduct(id);
                        Console.WriteLine(" Product deleted successfully!");
                        break;

                    case 5:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
            catch (ProductException ex)
            {
                Console.WriteLine(" Product Error: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine(" Invalid input format. Please enter correct values.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Unexpected Error: " + ex.Message);
            }
        }
    }
}