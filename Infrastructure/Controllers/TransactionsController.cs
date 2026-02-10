using Microsoft.AspNetCore.Mvc;
using Infrastructure.ViewModels;
using UseCases.interfaces;
using UseCases.TransactionsUseCases;
using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly ISearchTransactionUseCase searchTransactionUseCase;

        public TransactionsController(ISearchTransactionUseCase searchTransactionUseCase)
        {
            this.searchTransactionUseCase = searchTransactionUseCase;
        }

        [HttpGet]
        public IActionResult Index()
        {
            TransactionsViewModel transactionsViewModel = new TransactionsViewModel();
            return View(transactionsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(TransactionsViewModel transactionsViewModel)
        {
            var transactions = searchTransactionUseCase.Execute(transactionsViewModel.CashierName??string.Empty, transactionsViewModel.StartDate, transactionsViewModel.EndDate);

            transactionsViewModel.Transactions = transactions;
            return View("Index", transactionsViewModel);
        }
    }
}
