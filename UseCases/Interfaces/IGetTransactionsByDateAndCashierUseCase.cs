using CoreBusinessEntities;

namespace UseCases.TransactionsUseCases
{
    public interface IGetTransactionsByDateAndCashierUseCase
    {
        IEnumerable<Transaction> Execute(string cashierName, DateTime date);
    }
}