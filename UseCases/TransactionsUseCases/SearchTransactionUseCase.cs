using CoreBusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.TransactionsUseCases
{
    public class SearchTransactionUseCase : ISearchTransactionUseCase
    {
        private readonly ITransactionsRepository transactionsRepository;

        public SearchTransactionUseCase(ITransactionsRepository transactionsRepository)
        {
            this.transactionsRepository = transactionsRepository;
        }

        public IEnumerable<Transaction> Execute(string cashierName, DateTime startDate, DateTime endDate)
        {
            return transactionsRepository.SearchTransaction(cashierName, startDate, endDate);
        }
    }
}
