using MVC_Project.Models;
using MVC_Project.ViewModels.Validations;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project.ViewModels
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
