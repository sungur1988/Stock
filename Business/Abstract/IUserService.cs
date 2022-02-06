using Core.EntityLayer.Concrete.AuthorizationEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
        List<User> GetUser();
        void Delete(User user);
    }
}
