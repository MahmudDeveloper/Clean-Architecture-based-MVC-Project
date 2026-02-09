using CoreBusiness;

namespace UseCases.interfaces
{
    public interface IViewProductsUseCase
    {
        IEnumerable<Product> execute(bool loadCategory);
    }
}