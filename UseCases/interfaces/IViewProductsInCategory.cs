using CoreBusiness;

namespace UseCases.ProductsUseCases
{
    public interface IViewProductsInCategory
    {
        IEnumerable<Product> Execute(int categoryId);
    }
}