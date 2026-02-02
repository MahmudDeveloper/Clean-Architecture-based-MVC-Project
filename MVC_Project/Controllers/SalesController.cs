using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using MVC_Project.ViewModels;
using System.Reflection;
using WebApp.Models;

namespace MVC_Project.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            var salesViewModel = new SalesViewModel
            {
                Categories = CategoriesRepository.GetCategories()
            };
            return View(salesViewModel);
        }

        public IActionResult DetailsBySelectedProductPartial(int productId)
        {
            var product = ProductsRepository.GetProductById(productId);
            return PartialView("_ProductDetails", product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult sell(SalesViewModel salesViewModel)
        {
            var prod = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);
            if (ModelState.IsValid)
            {
                if (prod != null)
                {
                    TransactionsRepository.Add("Cashier1",
                                                salesViewModel.SelectedProductId,
                                                prod.Name,
                                                prod.Price.HasValue?prod.Price.Value:0,
                                                prod.Quantity.HasValue?prod.Quantity.Value:0,
                                                salesViewModel.QuantityToSell);

                    prod.Quantity -= salesViewModel.QuantityToSell;
                    ProductsRepository.UpdateProduct(salesViewModel.SelectedProductId, prod);
                }
                return RedirectToAction(nameof(Index));
            }
            
            salesViewModel.SelectedCategoryId= (prod?.CategoryId==null)? 0:prod.CategoryId.Value;

            salesViewModel.Categories = CategoriesRepository.GetCategories();
            return View("Index", salesViewModel);
        }
    }
}
