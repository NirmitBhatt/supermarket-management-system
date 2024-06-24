using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Transactions;

namespace Supermarket_Management_System.ViewModels
{
    public class TransactionsViewModel
    {
        [Required]
        [Display(Name = "Cashier's Name")]
        public string CashierName { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }   
        public Transaction? Transaction { get; set; }
    }
}
