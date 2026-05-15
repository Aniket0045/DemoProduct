using ProductApp.Data;
namespace ProductApp.Models

{
    public class Product
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string? ProductDesc { get; set; }
        public int ProductQuantity { get; set; }
    }
}