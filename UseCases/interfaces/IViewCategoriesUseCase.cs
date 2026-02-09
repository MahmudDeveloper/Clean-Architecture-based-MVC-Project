using CoreBusiness;

namespace UseCases.interfaces
{
    public interface IViewCategoriesUseCase
    {
        IEnumerable<Category> Execute();
    }
}