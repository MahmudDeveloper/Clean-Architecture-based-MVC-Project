using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace MVC_Project.ViewModels.Validations
{
    public class SalesViewModel_EnsureProperQuantity: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var salesViewModel = validationContext.ObjectInstance as SalesViewModel;

            if(salesViewModel != null)
            {
                if (salesViewModel.QuantityToSell <= 0)
                {
                    return new ValidationResult("Verkaufende Menge sollte hoher als null sein!");
                }
                else
                {
                    var prod = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);
                    if (prod != null)
                    {
                        if (salesViewModel.QuantityToSell > prod.Quantity)
                        {
                            return new ValidationResult($"Verkaufende Product hat nicht genuge Menge. {prod.Name} hat nur {prod.Quantity} verlasst!");
                        }
                    }
                    else
                    {
                        return new ValidationResult($"Das Produkt existiert nicht.");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
