using Microsoft.AspNetCore.Mvc;
using Infrastructure.ViewModels;
using UseCases.DataStorepluginInterfaces;
using UseCases.interfaces;
using UseCases.ProductsUseCases;
 
namespace Infrastructure.Controllers
{
    public class SalesController : Controller
    {
        private readonly IViewSelectedProductUseCase viewSelectedProductUseCase;
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly ISellProductUseCase sellProductUseCase;

        public SalesController(IViewSelectedProductUseCase viewSelectedProductUseCase,
                               IViewCategoriesUseCase viewCategoriesUseCase,
                               ISellProductUseCase sellProductUseCase)
        {
            this.viewSelectedProductUseCase = viewSelectedProductUseCase;
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.sellProductUseCase = sellProductUseCase;
        }
        public IActionResult Index()
        {
            var salesViewModel = new SalesViewModel
            {
                Categories = viewCategoriesUseCase.Execute()
            };
            return View(salesViewModel);
        }

        public IActionResult DetailsBySelectedProductPartial(int productId)
        {
            var product = viewSelectedProductUseCase.Execute(productId);
            return PartialView("_ProductDetails", product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sell(SalesViewModel salesViewModel)
        {
            var prod = viewSelectedProductUseCase.Execute(salesViewModel.SelectedProductId);

            if (ModelState.IsValid)
            {
                if (prod != null)
                {
                    sellProductUseCase.Execute("Cashier1", salesViewModel.QuantityToSell, salesViewModel.SelectedProductId);
                }
                return RedirectToAction(nameof(Index));
            }
            
            salesViewModel.SelectedCategoryId= (prod?.CategoryId==null)? 0:prod.CategoryId.Value;

            salesViewModel.Categories = viewCategoriesUseCase.Execute();
            return View("Index", salesViewModel);
        }
    }
}
