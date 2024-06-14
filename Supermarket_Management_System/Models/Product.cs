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
        public string ProductName {  get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue)]
        public double? Price { get; set; }

        [Required]
        public int? Quantity {  get; set; }

        public Category? Category {  get; set; } 
    }
}
