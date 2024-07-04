using System.ComponentModel.DataAnnotations;

namespace CoreBusinessEntities
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        //navigation property for ef core
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
