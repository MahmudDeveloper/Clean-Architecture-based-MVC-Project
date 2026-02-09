namespace UseCases.interfaces
{
    public interface ISellProductUseCase
    {
        void Execute(string cashierName, int qtyToSell, int productId);
    }
}