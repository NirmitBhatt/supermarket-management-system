using CoreBusinessEntities;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITransactionsRepository
    {
        void AddTransaction(string cashierName, 
            int productID, 
            string productName, 
            double price, 
            int beforeQuantity, 
            int soldQuantity);
        IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date);
        IEnumerable<Transaction> SearchTransaction(string cashierName, DateTime startDate, DateTime endDate);
    }
}