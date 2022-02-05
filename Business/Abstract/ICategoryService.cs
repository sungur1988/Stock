using Core.Utilities.Results;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(Category category);
        IResult Update(Category category);
        IDataResult<IEnumerable<Category>> GetList(int userId);
        IResult Delete(Category category);
    }
}
