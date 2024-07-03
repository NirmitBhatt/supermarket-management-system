using Supermarket_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Supermarket_Management_System.ViewModels.CustomValidations
{
    public class SalesViewModel_EnsureProperQuantity : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var salesViewModel = validationContext.ObjectInstance as SalesViewModel;
            if(salesViewModel == null)
            {
                return ValidationResult.Success;
            }
            if(salesViewModel.QuantityToSell <= 0)
            {
                return new ValidationResult("The quantity to sell has to be greater than zero.");
            }
            var product = ProductRepository.GetProductByID(salesViewModel.SelectedProductID);
            if(product == null)
            {
                return new ValidationResult("The selected product does not exist.");
            }
            if (salesViewModel.QuantityToSell > product.Quantity)
            {
                return new ValidationResult($"{product.ProductName} only has {product.Quantity} left in stock. Cannot sell {salesViewModel.QuantityToSell} of the same.");
            }
            return ValidationResult.Success;
        }
    }
}
