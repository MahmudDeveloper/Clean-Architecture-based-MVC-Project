using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;

namespace MVC_Project.ViewComponents
{
    public class TransactionsViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(string userName)
        {
            var transactions = TransactionsRepository.GetByDayAndCashier(userName, DateTime.Now);

            return View(transactions);
        }
    }
}
