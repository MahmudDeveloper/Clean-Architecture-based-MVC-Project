using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using MVC_Project.ViewModels;
using WebApp.Models;

namespace MVC_Project.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductsRepository.GetProducts(loadCategory: true);
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "add";
            ProductViewModel productViewModel = new ProductViewModel()
            {
                categories = CategoriesRepository.GetCategories()
            };
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Add([FromForm] ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.AddProduct(productViewModel.product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "add";

            productViewModel.categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "edit";

            var productViewModel = new ProductViewModel
            {
                product = ProductsRepository.GetProductById(id.HasValue?id.Value:0),
                categories = CategoriesRepository.GetCategories()
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

                ProductsRepository.UpdateProduct(productViewModel.product.ProductId, productViewModel.product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "edit";

            productViewModel.categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromForm] int id)
        {
            ProductsRepository.DeleteProduct(id);
            return RedirectToAction(nameof(Index)); 
        }

        public IActionResult ProductsByCategoryPartial(int categoryId)
        {
            var products = ProductsRepository.GetProductsByCategory(categoryId);
            return PartialView("_Products", products);
        }

    }
}