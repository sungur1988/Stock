using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IProductService _productService;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IResult Add(Category category)
        {
            _categoryRepository.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IDataResult<IEnumerable<Category>> GetList(int userId)
        {
            return new SuccessDataResult<IEnumerable<Category>>(_categoryRepository.GetAll(x => x.CreatedUserId == userId), Messages.CategoryListed);
        }

        public IResult Update(Category category)
        {
            return new SuccessResult(Messages.CategoryUpdated);
        }

        public IResult Delete(Category category,int userId)
        {
            var result = RuleEngine.Run(CheckAddedUser(category, userId), CheckProductExistInThisCategory(category.Id));
            if (result!=null)
            {
                return result;
            }
            _categoryRepository.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        private IResult CheckAddedUser(Category category,int userId)
        {

            if (category.CreatedUserId==userId)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.DifferentUserAddedCategory);
        }
        private IResult CheckProductExistInThisCategory(int categoryId)
        {
            var productsExist = _productService.GetListByCategoryId(categoryId).Data.Any();
            if (productsExist)
            {
                return new ErrorResult(Messages.ProductExistInThisCategory);
            }
            return new SuccessResult();
        }
    }
}
