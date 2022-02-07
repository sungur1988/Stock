using Core.Utilities.Results;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product, int userId);
        IDataResult<IEnumerable<Product>> GetListByCategoryId(int userId,int categoryId);
        IDataResult<IEnumerable<Product>> GetList(int userId);
        IDataResult<Product> GetProductById(int productId);
    }
}
