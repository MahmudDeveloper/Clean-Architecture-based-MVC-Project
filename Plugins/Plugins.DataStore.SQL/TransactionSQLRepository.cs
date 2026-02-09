using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorepluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class TransactionSQLRepository : ITransactionRepository
    {
        private readonly MarketContext db;

        public TransactionSQLRepository(MarketContext db)
        {
            this.db = db;
        }

        public void Add(string cashierName, int qtyToSell, int productId)
        {
            var prod = db.Products.Find(productId);
            if(prod == null)
            {
                return;
            }
            var trans = new Transaction
            {
                ProductId = productId,
                ProductName = prod.Name,
                BeforeQuantity = prod.Quantity,
                CashierName = cashierName,
                SoldQuantity = qtyToSell,
                Price = prod.Price,
                TimeStamp = DateTime.Now
            };
            db.Transactions.Add(trans);
            db.SaveChanges();
        }

        public IEnumerable<Transaction> Search(string? cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return db.Transactions.Where(x=>x.TimeStamp.Date>=startDate.Date &&  x.TimeStamp.Date<=endDate.Date);
            }
            else
            {
                return db.Transactions.Where(x => x.CashierName.Contains(cashierName) && x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endDate.Date);
            }
        }
    }
}
