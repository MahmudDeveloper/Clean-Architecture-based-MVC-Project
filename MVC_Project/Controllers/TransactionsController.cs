using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using MVC_Project.ViewModels;

namespace MVC_Project.Controllers
{
    public class TransactionsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            TransactionsViewModel transactionsViewModel = new TransactionsViewModel();
            return View(transactionsViewModel);
        }

        [HttpPost]
        public IActionResult Search(TransactionsViewModel transactionsViewModel)
        {
            var transactions = TransactionsRepository.Search(transactionsViewModel.CashierName??string.Empty, transactionsViewModel.StartDate, transactionsViewModel.EndDate);

            transactionsViewModel.Transactions = transactions;
            return View("Index", transactionsViewModel);
        }
    }
}
