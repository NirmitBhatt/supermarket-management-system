using System.ComponentModel.DataAnnotations;

namespace Supermarket_Management_System.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;
    }
}
