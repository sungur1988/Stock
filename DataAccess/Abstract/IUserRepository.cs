using Core.DataAccessLayer;
using Core.EntityLayer.Concrete.AuthorizationEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserRepository : IBaseRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
