using Core.EntityLayer.Concrete.AuthorizationEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class UserRepository : BaseRepository<User, AppDbContext>, IUserRepository
    {
        public List<OperationClaimDto> GetClaims(User user)
        {
            using (var context = new AppDbContext())
            {
                return context.OperationClaims.Where(x => x.UserId == user.Id).Select(y => new OperationClaimDto { Id = y.Id, Name = y.Name }).ToList();
            }
        }
    }
}
