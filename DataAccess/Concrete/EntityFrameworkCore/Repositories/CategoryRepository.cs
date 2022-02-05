﻿using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class CategoryRepository : BaseRepository<Category,AppDbContext>, ICategoryRepository
    {
    }
}
