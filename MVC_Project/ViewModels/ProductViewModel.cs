using CoreBusiness;

namespace Infrastructure.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Category> categories { get; set; } = Enumerable.Empty<Category>();
        public Product? product { get; set; }
    }
}