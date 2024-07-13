using CoreBusinessEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Plugins.DataStore.SQL
{
    public class TransactionsSQLRepository : ITransactionsRepository
    {
        private readonly MarketContext db;

        public TransactionsSQLRepository(MarketContext db)
        {
            this.db = db;
        }
        public void AddTransaction(string cashierName, int productID, string productName, double price, int beforeQuantity, int soldQuantity)
        {
            var transaction = new Transaction
            {
                ProductID = productID,
                ProductName = productName,
                Timestamp = DateTime.Now,
                Price = price,
                BeforeQuantity = beforeQuantity,
                SoldQuantity = soldQuantity,
                CashierName = cashierName
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date)
        {
            if(string.IsNullOrWhiteSpace(cashierName))
            {
                return db.Transactions.Where(x => 
                x.Timestamp == date.Date);
            }
            else
            {
                return db.Transactions.Where(x =>
                EF.Functions.Like(x.CashierName, $"%{cashierName}%") &&
                x.Timestamp == date.Date);
            }
        }

        public IEnumerable<Transaction> SearchTransaction(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return db.Transactions.Where(x => 
                x.Timestamp >= startDate.Date &&
                x.Timestamp.Date <= endDate.Date);
            }
            else
            {
                return db.Transactions.Where(x =>
                EF.Functions.Like(x.CashierName, $"%{cashierName}%") &&
                x.Timestamp.Date >= startDate.Date &&
                x.Timestamp.Date <= endDate.Date);
            }
        }
    }
}
