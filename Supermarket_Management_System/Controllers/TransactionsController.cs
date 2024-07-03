using Microsoft.AspNetCore.Mvc;
using CoreBusinessEntities;
using Supermarket_Management_System.ViewModels;
using UseCases.TransactionsUseCases;

namespace Supermarket_Management_System.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ISearchTransactionUseCase searchTransactionUseCase;

        public TransactionsController(ISearchTransactionUseCase searchTransactionUseCase)
        {
            this.searchTransactionUseCase = searchTransactionUseCase;
        }
        public IActionResult Index()
        {
            TransactionsViewModel transactionsViewModel = new TransactionsViewModel();
            return View(transactionsViewModel);
        }

        public IActionResult Search(TransactionsViewModel transactionsViewModel)
        {
            if (ModelState.IsValid)
            {
                var transactions = searchTransactionUseCase.Execute(
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
