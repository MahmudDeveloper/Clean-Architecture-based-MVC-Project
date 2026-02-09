using System.ComponentModel.DataAnnotations;
using CoreBusiness;

namespace Infrastructure.ViewModels
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
