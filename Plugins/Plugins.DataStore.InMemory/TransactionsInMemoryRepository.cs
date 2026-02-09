using CoreBusiness;
using UseCases.DataStorepluginInterfaces;
using UseCases.interfaces;

namespace MVC_Project.Models
{
    public  class TransactionsInMemoryRepository:ITransactionRepository
    {
        public TransactionsInMemoryRepository(IViewSelectedProductUseCase viewSelectedProductUseCase)
        {
            this.viewSelectedProductUseCase = viewSelectedProductUseCase;
        }

        private  List<Transaction> transactions = new List<Transaction>();
        private readonly IViewSelectedProductUseCase viewSelectedProductUseCase;

        public  IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(x => x.TimeStamp.Date == date.Date);
            else
                return transactions.Where(x =>
                    x.CashierName.ToLower().Contains(cashierName.ToLower()) &&
                    x.TimeStamp.Date == date.Date);
        }

        public  IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
            else
                return transactions.Where(x =>
                    x.CashierName.ToLower().Contains(cashierName.ToLower()) &&
                    x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
        }

        public void Add(string cashierName, int qtyToSell, int productId)
        {
            var product = viewSelectedProductUseCase.Execute(productId);
            var transaction = new Transaction
            {
                ProductId = product.ProductId,
                ProductName = product.Name,
                TimeStamp = DateTime.Now,
                Price = product.Price,
                BeforeQuantity = product.Quantity,
                SoldQuantity = qtyToSell,
                CashierName = "Cashier1"
            };

            if (transactions != null && transactions.Count > 0)
            {
                var maxId = transactions.Max(x => x.TransactionId);
                transaction.TransactionId = maxId + 1;
            }
            else
            {
                transaction.TransactionId = 1;
            }

            transactions?.Add(transaction);
        }
    }
}