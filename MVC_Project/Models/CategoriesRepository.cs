using AspNetCoreGeneratedDocument;

namespace MVC_Project.Models
{
    public class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category{CategoryId = 1, CategoryName= "Beverage", CategoryDescription="Beverage"},
            new Category{CategoryId = 2, CategoryName= "Bakery", CategoryDescription="Bakery"},
            new Category{CategoryId = 3, CategoryName= "Meat", CategoryDescription="Meat"}
        };

        public static void AddCategory(Category category)
        {
            var maxId = 1;
            if (_categories.Count > 0)
            {
                maxId = _categories.Max(x=> x.CategoryId);
            }
            category.CategoryId = maxId + 1;
            _categories.Add(category);
        }

        public static List<Category> GetCategories() => _categories;

        public static Category? GetCategoryById(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if(category != null)
            {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    CategoryDescription = category.CategoryDescription
                };
            }
            return null;
        }

        public static void UpdateCategory(int categoryId, Category newCategory)
        {
            if (newCategory.CategoryId != categoryId) return;

            var categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == categoryId); 
            if (categoryToUpdate != null)
            {
                categoryToUpdate.CategoryName = newCategory.CategoryName;
                categoryToUpdate.CategoryDescription = newCategory.CategoryDescription;
            }
        }
        
        public static void DeleteCategory(int categoryId)
        {
            var categoryToDelete = _categories.FirstOrDefault(x=>x.CategoryId==categoryId);

            if( categoryToDelete != null )
            {
                _categories.Remove(categoryToDelete);
            }
        }
    }
}
