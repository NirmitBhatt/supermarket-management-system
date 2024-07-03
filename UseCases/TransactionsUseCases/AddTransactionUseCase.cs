using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.TransactionsUseCases
{
    public class AddTransactionUseCase : IAddTransactionUseCase
    {
        private readonly ITransactionsRepository transactionsRepository;

        public AddTransactionUseCase(ITransactionsRepository transactionsRepository)
        {
            this.transactionsRepository = transactionsRepository;
        }

        public void Execute(string cashierName, int productID, string productName, double price, int beforeQuantity, int soldQuantity)
        {
            transactionsRepository.AddTransaction(cashierName, productID, productName, price, beforeQuantity, soldQuantity);
        }
    }
}
