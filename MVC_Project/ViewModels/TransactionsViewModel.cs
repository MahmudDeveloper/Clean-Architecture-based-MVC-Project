using System.ComponentModel.DataAnnotations;
using MVC_Project.Models;

namespace MVC_Project.ViewModels
{
    public class TransactionsViewModel
    {
        [Display(Name ="Cashier Name")]
        public string? CashierName { get; set; } = "Cashier1";
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Today;
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; } = DateTime.Today;
        public IEnumerable<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
