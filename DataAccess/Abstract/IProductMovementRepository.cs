﻿using Core.DataAccessLayer;
using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductMovementRepository : IBaseRepository<ProductMovement>
    {
        IEnumerable<StockTotalDto> GetStockTotals();
    }
}
