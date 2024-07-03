namespace Supermarket_Management_System.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime Timestamp { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; } = "";
        public double Price { get; set; }
        public int BeforeQuantity { get; set; }
        public int SoldQuantity { get; set; }
        public string CashierName { get; set; } = "";

    }
}
