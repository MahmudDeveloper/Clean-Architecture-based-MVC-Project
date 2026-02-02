using MVC_Project.Models;

namespace MVC_Project.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Category> categories { get; set; } = Enumerable.Empty<Category>();
        public Product? product { get; set; }
    }
}