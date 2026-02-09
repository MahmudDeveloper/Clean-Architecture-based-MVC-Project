using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorepluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class CategorySQLRepository : ICategoryRepository
    {
        private readonly MarketContext db;

        public CategorySQLRepository(MarketContext db)
        {
            this.db = db;
        }

        public void AddCategory(Category category)
        {
            db.Add(category);
            db.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var prod = db.Categories.Find(categoryId);
            if(prod == null) { return; }

            db.Categories.Remove(prod);
            db.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Category? GetCategoryById(int categoryId)
        {
            return db.Categories.Find(categoryId);
        }

        public void UpdateCategory(int categoryId, Category category)
        {
            if(categoryId != category.CategoryId) { return; }

            var cat = db.Categories.Find(categoryId);
            if (cat == null) { return; }

            cat.CategoryName = category.CategoryName;
            cat.CategoryDescription = category.CategoryDescription;
            db.SaveChanges(); 
        }
    }
}
