using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Business;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.ValidationAspect;


namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;
        private IProductMovementService _productMovementService;
        public ProductManager(IProductRepository productRepository, IProductMovementService productMovementService)
        {
            _productRepository = productRepository;
            _productMovementService = productMovementService;
        }
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            _productRepository.Add(product);
            return new SuccessResult(Messages.ProductAdded);

        }

        public IResult Delete(Product product, int userId)
        {
            var result = RuleEngine.Run(CheckAddedUser(product, userId), CheckProductMovementWithThisProduct(userId, product.Id));
            if (result != null)
            {
                return result;
            }
            _productRepository.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }
        public IDataResult<IEnumerable<Product>> GetListByCategoryId(int userId, int categoryId)
        {
            return new SuccessDataResult<IEnumerable<Product>>(_productRepository.GetAll(x => x.CategoryId == categoryId&&x.Id==userId), Messages.ProductListed);
        }
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            _productRepository.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
        public IDataResult<IEnumerable<Product>> GetList(int userId)
        {
            return new SuccessDataResult<IEnumerable<Product>>(_productRepository.GetAll(x => x.Id == userId), Messages.ProductListed);
        }
        private IResult CheckAddedUser(Product product, int userId)
        {

            if (!(product.CreatedUserId == userId))
            {
                return new ErrorResult(Messages.DifferentUserAddedCategory);

            }
            return new SuccessResult();

        }
        private IResult CheckProductMovementWithThisProduct(int userId, int productId)
        {
            var result = _productMovementService.GetListByProductId(userId, productId).Data.Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductMovementExistWithThisProduct);
            }
            return new SuccessResult();
        }

        public IDataResult<Product> GetProductById(int productId)
        {
            var product = _productRepository.Get(x => x.Id == productId);
            if (product == null)
            {
                return new ErrorDataResult<Product>(Messages.ProductNotFound);
            }
            return new SuccessDataResult<Product>(product);
        }
    }
}
