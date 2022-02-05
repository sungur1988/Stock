using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductMovementManager : IProductMovementService
    {
        private IProductMovementRepository _productMovementRepository;
        public ProductMovementManager(IProductMovementRepository productMovementRepository)
        {
            _productMovementRepository = productMovementRepository;
        }
        public IResult Add(ProductMovement productMovement)
        {
            _productMovementRepository.Add(productMovement);
            return new SuccessResult(Messages.ProductMovementAdded);
        }

        public IDataResult<IEnumerable<ProductMovement>> GetList(int userId)
        {
            return new SuccessDataResult<IEnumerable<ProductMovement>>(_productMovementRepository
                .GetAll(x => x.CreatedUserId == userId)
                .OrderByDescending(y => y.CreatedDate)
                , Messages.ProductMovementListed);
        }

        public IDataResult<IEnumerable<StockTotalDto>> GetStockTotals()
        {
            return new SuccessDataResult<IEnumerable<StockTotalDto>>(_productMovementRepository.GetStockTotals(), Messages.StockTotalListed);
        }

        public IDataResult<IEnumerable<ProductMovement>> GetListByProductId(int userId, int productId)
        {
            return new SuccessDataResult<IEnumerable<ProductMovement>>(_productMovementRepository
                .GetAll(x => x.CreatedUserId == userId && x.ProductId == productId)
                .OrderByDescending(y => y.CreatedDate)
                , Messages.ProductMovementListed);
        }
    }
}
