using CoreBusiness;
using UseCases.DataStorepluginInterfaces;
using UseCases.interfaces;

namespace UseCases.TransactionsUseCases
{
    public class SearchTransactionUseCase : ISearchTransactionUseCase
    {
        private readonly ITransactionRepository transactionRepository;

        public SearchTransactionUseCase(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> Execute(string? CashierName, DateTime StartDate, DateTime EndDate)
        {
            return transactionRepository.Search(CashierName, StartDate, EndDate);
        }
    }
}
