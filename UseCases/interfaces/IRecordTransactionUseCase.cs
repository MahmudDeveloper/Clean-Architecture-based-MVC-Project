namespace UseCases.interfaces
{
    public interface IRecordTransactionUseCase
    {
        void Execute(string cashierName, int qtyToSell, int productId);
    }
}