using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public String Error()
        {
            return "Ich habe fehler hier";
        }
    }
}
