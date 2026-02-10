using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.CategoriesUseCases;
using UseCases.DataStorepluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class ProductSQLRepository : IProductRepository
    {
        private readonly MarketContext db;

        public ProductSQLRepository(MarketContext db)
        {
            this.db = db;
        }

        public void AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();   
        }

        public void DeleteProduct(int productId)
        {
            var prod = db.Products.Find(productId);
            if(prod == null) { return; }

            db.Products.Remove(prod);
            db.SaveChanges();
        }

        public Product GetProductById(int productId, bool loadCategory = false)
        {
            if (loadCategory)
            {
                return
                    db.Products
                    .Include(x => x.Category)
                    .FirstOrDefault(x => x.ProductId == productId);
            }
            else
            {
                return
                    db.Products
                    .FirstOrDefault(x => x.ProductId == productId);
            }
        }

        public IEnumerable<Product> GetProducts(bool loadCategory)
        {
            if (loadCategory == false)
            {
                return db.Products.ToList();
            }
            else
            {
                
                return db.Products
                     .Include(x => x.Category).ToList() ?? new List<Product>();
            }
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return db.Products.Where(x=> x.CategoryId == categoryId).ToList();
        }

        public void UpdateProduct(int productId, Product product)
        {
            if(productId != product.ProductId) { return; }

            var prod = db.Products.Find(productId);
            prod.Name = product.Name;
            prod.Price = product.Price;
            prod.Quantity = product.Quantity;
            prod.CategoryId = product.CategoryId;
            db.SaveChanges();
        }
    }
}
