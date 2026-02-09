using CoreBusiness;
using Microsoft.AspNetCore.Mvc;
using UseCases.interfaces;

namespace Infrastructure.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly IEditCategoryUseCase editCategoryUseCase;
        private readonly IDeleteCategoryUseCase deleteCategoryUseCase;
        private readonly IAddCategoryUseCase addCategoryUseCase;
        private readonly IViewSelectedCategoryUseCase viewSelectedCategoryUseCase;

        public CategoriesController(IViewCategoriesUseCase viewCategoriesUseCase,
                                    IEditCategoryUseCase editCategoryUseCase,
                                    IDeleteCategoryUseCase deleteCategoryUseCase,
                                    IAddCategoryUseCase addCategoryUseCase,
                                    IViewSelectedCategoryUseCase viewSelectedCategoryUseCase)
        {
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.editCategoryUseCase = editCategoryUseCase;
            this.deleteCategoryUseCase = deleteCategoryUseCase;
            this.addCategoryUseCase = addCategoryUseCase;
            this.viewSelectedCategoryUseCase = viewSelectedCategoryUseCase;
        }
        public IActionResult Index()
        {
            var categories = viewCategoriesUseCase.Execute();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "edit";

            Category? category = viewSelectedCategoryUseCase.Execute(id.HasValue?id.Value:0);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                editCategoryUseCase.Execute(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "edit";
            return View(category);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "add";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add([FromForm]Category category)
        {
            if (ModelState.IsValid)
            {
                addCategoryUseCase.Execute(category);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "add";
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            deleteCategoryUseCase.Execute(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
