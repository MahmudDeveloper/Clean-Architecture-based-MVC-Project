

using CoreBusiness;

namespace UseCases.DataStorepluginInterfaces
{
    public interface ITransactionRepository
    {
        void Add(string cashierName, int qtyToSell, int productId);
        IEnumerable<Transaction> Search(string? cashierName, DateTime startDate, DateTime endDate);
    }
}