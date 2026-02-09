using CoreBusiness;

namespace UseCases.interfaces
{
    public interface ISearchTransactionUseCase
    {
        IEnumerable<Transaction> Execute(string? CashierName, DateTime StartDate, DateTime EndDate);
    }
}