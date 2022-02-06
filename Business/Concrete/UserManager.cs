using Business.Abstract;
using Core.EntityLayer.Concrete.AuthorizationEntities;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userRepository.Get(x => x.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userRepository.GetClaims(user);
        }

        public List<User> GetUser()
        {
            return _userRepository.GetAll().ToList();
        }

        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }
    }
}
