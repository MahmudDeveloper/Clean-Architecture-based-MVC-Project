using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorepluginInterfaces;
using UseCases.interfaces;
using UseCases.TransactionsUseCases;

namespace UseCases.ProductsUseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IViewSelectedProductUseCase viewSelectedProductUseCase;
        private readonly IRecordTransactionUseCase recordTransactionUseCase;
        private readonly IEditProductUseCase editProductUseCase;

        public SellProductUseCase(IViewSelectedProductUseCase viewSelectedProductUseCase,
                                  IRecordTransactionUseCase recordTransactionUseCase,
                                  IEditProductUseCase editProductUseCase)
        {
            this.viewSelectedProductUseCase = viewSelectedProductUseCase;
            this.recordTransactionUseCase = recordTransactionUseCase;
            this.editProductUseCase = editProductUseCase;
        }

        public void Execute(string cashierName, int qtyToSell, int productId)
        {
            var product = viewSelectedProductUseCase.Execute(productId);
            if (product == null) { return; }

            recordTransactionUseCase.Execute(cashierName, qtyToSell, productId);

            product.Quantity -= qtyToSell;
            editProductUseCase.Execute(productId, product);
        }
    }
}
