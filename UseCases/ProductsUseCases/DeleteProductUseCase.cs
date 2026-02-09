using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorepluginInterfaces;
using UseCases.interfaces;

namespace UseCases.ProductsUseCases
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepository productRepository;

        public DeleteProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Execute(int productId)
        {
            productRepository.DeleteProduct(productId);
        }
    }
}
