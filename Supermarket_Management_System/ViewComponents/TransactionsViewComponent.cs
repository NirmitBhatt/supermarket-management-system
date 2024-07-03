using Microsoft.AspNetCore.Mvc;
using CoreBusinessEntities;
using UseCases.TransactionsUseCases;

namespace Supermarket_Management_System.ViewComponents
{
    public class TransactionsViewComponent : ViewComponent
    {
        private readonly IGetTransactionsByDateAndCashierUseCase getTransactionsByDateAndCashierUseCase;

        public TransactionsViewComponent(IGetTransactionsByDateAndCashierUseCase getTransactionsByDateAndCashierUseCase)
        {
            this.getTransactionsByDateAndCashierUseCase = getTransactionsByDateAndCashierUseCase;
        }
        public IViewComponentResult Invoke(string userName)
        {
            var transactions = getTransactionsByDateAndCashierUseCase.Execute(userName, DateTime.Now);//TransactionRepository.GetByDayAndCashier(userName, DateTime.Now);
            return View(transactions);
        }
    }
}
