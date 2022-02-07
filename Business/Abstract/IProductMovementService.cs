using Core.Utilities.Results;
using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductMovementService
    {
        IResult Add(ProductMovement productMovement);
        IDataResult<IEnumerable<ProductMovement>> GetList(int userId);
        IDataResult<IEnumerable<StockTotalDto>> GetStockTotals();
        IDataResult<IEnumerable<ProductMovement>> GetListByProductId(int userId,int productId);
        IDataResult<ProductMovement> GetProductMovementById(int productMovementId);
    }
}
