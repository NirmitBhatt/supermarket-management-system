using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreBusinessEntities
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
        [Range(0.01, int.MaxValue, ErrorMessage ="The price of the product should be greater than 0")]
        public double? Price { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Cannot add product with less than 1 quantity")]
        public int? Quantity {  get; set; }

        //navigation property for ef core
        public Category? Category { get; set; }
    }
}
