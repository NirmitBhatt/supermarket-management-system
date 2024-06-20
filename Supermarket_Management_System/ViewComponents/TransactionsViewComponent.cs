using Microsoft.AspNetCore.Mvc;
using Supermarket_Management_System.Models;

namespace Supermarket_Management_System.ViewComponents
{
    public class TransactionsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string userName)
        {
            var transactions = TransactionRepository.GetByDayAndCashier(userName, DateTime.Now);
            return View(transactions);
        }
    }
}
