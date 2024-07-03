using CoreBusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TransactionsInMemoryRepository : ITransactionsRepository
    {
        private static List<Transaction> _transactions = new List<Transaction>();
        public void AddTransaction(string cashierName, 
            int productID, 
            string productName, 
            double price, 
            int beforeQuantity, 
            int soldQuantity)
        {
            var transaction = new Transaction
            {
                ProductID = productID,
                ProductName = productName,
                Timestamp = DateTime.Now,
                Price = price,
                BeforeQuantity = beforeQuantity,
                SoldQuantity = soldQuantity,
                CashierName = cashierName,
            };

            if (_transactions != null && _transactions.Count > 0)
            {
                var maxID = _transactions.Max(x => x.TransactionID);
                transaction.TransactionID = maxID + 1;
            }
            else
            {
                transaction.TransactionID = 1;
            }
            _transactions?.Add(transaction);
        }

        public IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return _transactions.Where(x => x.Timestamp.Date == date.Date);
            }
            else
            {
                return _transactions.Where(x =>
                    x.CashierName.ToLower().Contains(cashierName.ToLower()) &&
                    x.Timestamp.Date == date.Date);
            }
        }

        public IEnumerable<Transaction> SearchTransaction(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return _transactions.Where(x => x.Timestamp >= startDate.Date && x.Timestamp <= endDate.Date.AddDays(1).Date);
            }
            else
            {
                return _transactions.Where(x =>
                    x.CashierName.ToLower().Contains(cashierName.ToLower()) &&
                    x.Timestamp >= startDate.Date && x.Timestamp <= endDate.Date.AddDays(1).Date);
            }
        }
    }
}
