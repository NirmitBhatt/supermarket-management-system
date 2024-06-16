using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Supermarket_Management_System.Models
{
    public class Product
    {
        public int ProductID {  get; set; }

        [Required]
        [Display(Name = "Category")]
        public int? CategoryID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string ProductName {  get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue, ErrorMessage ="The price of the product cannot be negative!")]
        public double? Price { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Cannot add product with less than 1 quantity")]
        public int? Quantity {  get; set; }

        public Category? Category {  get; set; } 
    }
}
