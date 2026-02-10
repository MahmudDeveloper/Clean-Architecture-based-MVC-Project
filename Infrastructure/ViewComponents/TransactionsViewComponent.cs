using Microsoft.AspNetCore.Mvc;
using UseCases.interfaces;

    namespace Infrastructure.ViewComponents
{
    public class TransactionsViewComponent:ViewComponent
    {
        private readonly ISearchTransactionUseCase searchTransactionUseCase;

        public TransactionsViewComponent(ISearchTransactionUseCase searchTransactionUseCase)
        {
            this.searchTransactionUseCase = searchTransactionUseCase;
        }

        public IViewComponentResult Invoke(string userName)
        {
            var transactions = searchTransactionUseCase.Execute(userName, DateTime.Today, DateTime.Now);

            return View(transactions);
        }
    }
}
