using CoreBusiness;
using Microsoft.AspNetCore.Mvc;
//using Infrastructure.Models;
using Infrastructure.ViewModels;
using UseCases.interfaces;
using UseCases.ProductsUseCases;

namespace Infrastructure.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IAddProductUseCase addProductUseCase;
        private readonly IDeleteProductUseCase deleteProductUseCase;
        private readonly IViewProductsUseCase viewProductsUseCase;
        private readonly IViewSelectedProductUseCase viewSelectedProductUseCase;
        private readonly IEditProductUseCase editProductUseCase;
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly IViewProductsInCategory viewProductsInCategory;

        public ProductsController(IAddProductUseCase addProductUseCase,
                                  IDeleteProductUseCase deleteProductUseCase,
                                  IViewProductsUseCase viewProductsUseCase,
                                  IViewSelectedProductUseCase viewSelectedProductUseCase,
                                  IEditProductUseCase editProductUseCase,
                                  IViewCategoriesUseCase viewCategoriesUseCase,
                                  IViewProductsInCategory viewProductsInCategory)
        {
            this.addProductUseCase = addProductUseCase;
            this.deleteProductUseCase = deleteProductUseCase;
            this.viewProductsUseCase = viewProductsUseCase;
            this.viewSelectedProductUseCase = viewSelectedProductUseCase;
            this.editProductUseCase = editProductUseCase;
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.viewProductsInCategory = viewProductsInCategory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = viewProductsUseCase.execute(loadCategory: true);
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "add";
            ProductViewModel productViewModel = new ProductViewModel()
            {
                categories = viewCategoriesUseCase.Execute()
            };
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Add([FromForm] ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                addProductUseCase.Execute(productViewModel.product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "add";

            productViewModel.categories = viewCategoriesUseCase.Execute();
            return View(productViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "edit";

            var productViewModel = new ProductViewModel
            {
                product = viewSelectedProductUseCase.Execute(id.HasValue?id.Value:0),
                categories = viewCategoriesUseCase.Execute()
            };
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {

            if (ModelState.IsValid && productViewModel.product!=null)
            {
                var product = new Product
                {
                    ProductId=productViewModel.product.ProductId,
                    Quantity=productViewModel.product.Quantity,
                    Price=productViewModel.product.Price,
                    CategoryId=productViewModel.product.CategoryId,
                    Name=productViewModel.product.Name
                };

                editProductUseCase.Execute(productViewModel.product.ProductId, productViewModel.product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "edit";

            productViewModel.categories = viewCategoriesUseCase.Execute();
            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            deleteProductUseCase.Execute(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProductsByCategoryPartial(int categoryId)
        {
            var products = viewProductsInCategory.Execute(categoryId);
            return PartialView("_Products", products);
        }

    }
}