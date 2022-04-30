using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.Users.Services;
using DiscountCards.API.Controllers.Users.Dto;
using DiscountCards.Core.Domains.Users;

namespace DiscountCards.API.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public string Create(CreateUserDto user)
        {
            return userService.Create(new User() { Login = user.Login, Password = user.Password });
        }

        [HttpGet("{id}")]
        public UserDto Get(int id)
        {
            return new UserDto(userService.Get(id));
        }
    }
}
