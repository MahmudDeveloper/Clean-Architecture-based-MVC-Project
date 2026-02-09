using CoreBusiness;

namespace UseCases.interfaces
{
    public interface IViewSelectedProductUseCase
    {
        Product Execute(int productId, bool loadCategory = false);
    }
}