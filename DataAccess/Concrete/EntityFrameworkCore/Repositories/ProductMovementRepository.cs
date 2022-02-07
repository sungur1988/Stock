using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class ProductMovementRepository : BaseRepository<ProductMovement, AppDbContext>, IProductMovementRepository
    {
        public IEnumerable<StockTotalDto> GetStockTotals()
        {
            using (var context = new AppDbContext())
            {
                var data = from pm in context.ProductMovements
                           join p in context.Products
                           on pm.ProductId equals p.Id
                           select new { ProductId = p.Id, ProductName = p.ProductName, Stock = pm.Amount };
                var result = data.GroupBy(a => a.ProductName)
                     .Select(a => new StockTotalDto { ProductName = a.Key, Stock = a.Sum(b => b.Stock) });
                return result.ToList();

            }
        }
    }
}
