using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var data = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            return Ok(data);
        }
        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var loginResult = _authService.Login(userForLoginDto);
            if (!loginResult.Success)
            {
                return BadRequest(loginResult.Message);
            }
            var token = _authService.CreateAccessToken(loginResult.Data);
            if (!token.Success)
            {
                return BadRequest(token.Message);
            }
            return Ok(token.Data);
        }
        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userToCheck = _authService.UserExist(userForRegisterDto.Email);
            if (!userToCheck.Success)
            {
                return BadRequest(userToCheck.Message);
            }
            var registerResult = _authService.Register(userForRegisterDto);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
