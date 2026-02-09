using CoreBusiness;

namespace UseCases.interfaces
{
    public interface IEditProductUseCase
    {
        void Execute(int productId, Product product);
    }
}