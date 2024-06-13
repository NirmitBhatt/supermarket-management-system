namespace Supermarket_Management_System.Models
{
    public class Product
    {
        public int ProductID {  get; set; }
        public int? CategoryID { get; set; }
        public string ProductName {  get; set; } = string.Empty;
        public double? Price { get; set; }
        public int? Quantity {  get; set; }
        public Category? Category {  get; set; } 
    }
}
