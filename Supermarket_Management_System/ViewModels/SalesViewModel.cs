using Supermarket_Management_System.Models;

namespace Supermarket_Management_System.ViewModels
{
    public class SalesViewModel
    {
        public int SelectedCategoryID { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
