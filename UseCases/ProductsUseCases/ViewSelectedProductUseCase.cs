using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorepluginInterfaces;
using UseCases.interfaces;

namespace UseCases.ProductsUseCases
{
    public class ViewSelectedProductUseCase : IViewSelectedProductUseCase
    {
        private readonly IProductRepository productRepository;

        public ViewSelectedProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product Execute(int productId, bool loadCategory = true)
        {
            return productRepository.GetProductById(productId, loadCategory);
        }
    }
}
