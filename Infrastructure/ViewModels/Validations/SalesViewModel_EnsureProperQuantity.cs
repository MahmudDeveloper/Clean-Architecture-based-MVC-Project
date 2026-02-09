using Infrastructure.ViewModels;
using System.ComponentModel.DataAnnotations;
using UseCases.interfaces;

namespace Infrastructure.ViewModels.Validations
{
    public class SalesViewModel_EnsureProperQuantity : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var salesViewModel = validationContext.ObjectInstance as SalesViewModel;

            if (salesViewModel == null)
                return ValidationResult.Success;

            if (salesViewModel.QuantityToSell <= 0)
                return new ValidationResult("The quantity to sell has to be greater than zero.");

            var useCase = validationContext
                .GetService(typeof(IViewSelectedProductUseCase))
                as IViewSelectedProductUseCase;

            if (useCase == null)
                return new ValidationResult("System error.");

            var product = useCase.Execute(salesViewModel.SelectedProductId);

            if (product == null)
                return new ValidationResult("The selected product doesn't exist.");

            if (product.Quantity < salesViewModel.QuantityToSell)
                return new ValidationResult($"{product.Name} only has {product.Quantity} left.");

            return ValidationResult.Success;
        }
    }
}
