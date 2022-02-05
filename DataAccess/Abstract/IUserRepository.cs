using Core.DataAccessLayer;
using Core.EntityLayer.Concrete.AuthorizationEntities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserRepository : IBaseRepository<User>
    {
        List<OperationClaimDto> GetClaims(User user);
    }
}
