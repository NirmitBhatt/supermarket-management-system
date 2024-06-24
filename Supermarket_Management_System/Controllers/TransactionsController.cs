using Microsoft.AspNetCore.Mvc;
using Supermarket_Management_System.Models;
using Supermarket_Management_System.ViewModels;

namespace Supermarket_Management_System.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult Index()
        {
            TransactionsViewModel transactionsViewModel = new TransactionsViewModel();
            return View(transactionsViewModel);
        }

        public IActionResult Search(TransactionsViewModel transactionsViewModel)
        {
            if (ModelState.IsValid)
            {
                var transactions = TransactionRepository.SearchTransaction(
                    transactionsViewModel.CashierName??string.Empty, 
                    transactionsViewModel.StartDate, 
                    transactionsViewModel.EndDate);

                transactionsViewModel.Transactions = transactions;
                return View("Index", transactionsViewModel);
            }
            return View("Index");
        }
    }
}
