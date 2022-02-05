using Core.DataAccessLayer;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
    }
}
