namespace UseCases.TransactionsUseCases
{
    public interface IAddTransactionUseCase
    {
        void Execute(string cashierName, 
            int productID, 
            string productName, 
            double price, 
            int beforeQuantity, 
            int soldQuantity);
    }
}