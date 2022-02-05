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
                return context.ProductMovements
                    .GroupBy(x => x.ProductId)
                    .Select(y => new StockTotalDto
                    {
                        ProductId = y.First().ProductId,
                        ProductName = y.First().Product.ProductName,
                        Stock = y.Sum(z => z.Amount)
                    });
            }
        }
    }
}
