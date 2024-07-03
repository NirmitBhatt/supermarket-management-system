using CoreBusinessEntities;

namespace UseCases.TransactionsUseCases
{
    public interface ISearchTransactionUseCase
    {
        IEnumerable<Transaction> Execute(string cashierName, DateTime startDate, DateTime endDate);
    }
}