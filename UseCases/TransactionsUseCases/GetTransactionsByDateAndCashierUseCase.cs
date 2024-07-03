using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusinessEntities;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.TransactionsUseCases
{
    public class GetTransactionsByDateAndCashierUseCase : IGetTransactionsByDateAndCashierUseCase
    {
        private readonly ITransactionsRepository transactionsRepository;

        public GetTransactionsByDateAndCashierUseCase(ITransactionsRepository transactionsRepository)
        {
            this.transactionsRepository = transactionsRepository;
        }

        public IEnumerable<Transaction> Execute(string cashierName, DateTime date)
        {
            return transactionsRepository.GetByDayAndCashier(cashierName, date);
        }
    }
}
