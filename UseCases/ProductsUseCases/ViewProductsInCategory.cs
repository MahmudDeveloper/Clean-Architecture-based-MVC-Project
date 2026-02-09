using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorepluginInterfaces;

namespace UseCases.ProductsUseCases
{
    public class ViewProductsInCategory : IViewProductsInCategory
    {
        private readonly IProductRepository productRepository;

        public ViewProductsInCategory(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> Execute(int categoryId)
        {
            var _products = productRepository.GetProductsByCategory(categoryId);
            return _products;
        }
    }
}
