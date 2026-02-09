using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorepluginInterfaces;
using UseCases.interfaces;

namespace UseCases.TransactionsUseCases
{
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        private readonly ITransactionRepository transactionRepository;

        public RecordTransactionUseCase(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public void Execute(string cashierName, int qtyToSell, int productId)
        {
            transactionRepository.Add(cashierName, qtyToSell, productId);
        }
    }
}
