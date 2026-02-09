using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorepluginInterfaces;
using UseCases.interfaces;

namespace UseCases.ProductsUseCases
{
    public class EditProductUseCase : IEditProductUseCase
    {
        private readonly IProductRepository productRepository;

        public EditProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Execute(int productId, Product product)
        {
            productRepository.UpdateProduct(productId, product);
        }
    }
}
