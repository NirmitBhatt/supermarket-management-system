using CoreBusinessEntities;
using Supermarket_Management_System.ViewModels.CustomValidations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Supermarket_Management_System.ViewModels
{
    public class SalesViewModel
    {
        public int SelectedCategoryID { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public int SelectedProductID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Cannot add product with less than 1 quantity")]
        [Display(Name = "Quantity")]
        [SalesViewModel_EnsureProperQuantity]
        public int QuantityToSell { get; set; }
    }
}
