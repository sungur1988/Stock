using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.EntityLayer.Concrete.AuthorizationEntities;
using Core.Utilities.Results;
using Core.Utilities.Security.HashHelpers;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var token = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(token, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.PasswordHash,userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }
        [SecuredOperationAspect("admin")]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var createdUser = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(createdUser);
            return new SuccessDataResult<User>(createdUser, Messages.UserRegistered);
        }

        public IResult UserExist(string email)
        {
    
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }
            return new SuccessResult();
        }
        [SecuredOperationAspect("admin")]
        public IDataResult<IEnumerable<User>> GetAllUser()
        {
            return new SuccessDataResult<IEnumerable<User>>(_userService.GetUser(), Messages.UsersListed);
        }
        [SecuredOperationAspect("admin")]
        public IResult Delete(string email)
        {
            var userToDelete = _userService.GetByMail(email);
            if (userToDelete==null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            _userService.Delete(userToDelete);
            return new SuccessResult();
        }
    }
}
