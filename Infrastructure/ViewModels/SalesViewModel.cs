using CoreBusiness;
using Infrastructure.ViewModels.Validations;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.ViewModels
{
    public class SalesViewModel
    {
        public int? SelectedCategoryId { get; set; }
        public int SelectedProductId { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        [Display(Name = "Quantity")]
        [Range(0,int.MaxValue)]
        [SalesViewModel_EnsureProperQuantity]
        public int QuantityToSell { get; set; }
    }
}
