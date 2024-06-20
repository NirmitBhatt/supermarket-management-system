namespace Supermarket_Management_System.Models
{
    public class TransactionRepository
    {
        private static List<Transaction> _transactions = new List<Transaction>();
        public static void AddTransaction(string cashierName, int productID, string productName, double price, int beforeQuantity, int soldQuantity)
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

            if(_transactions != null && _transactions.Count > 0)
            {
                var maxID = _transactions.Max(x => x.TransactionID);
                transaction.TransactionID = maxID +1;
            }
            else
            {
                transaction.TransactionID = 1;
            }
            _transactions?.Add(transaction);
        }
    }
}
