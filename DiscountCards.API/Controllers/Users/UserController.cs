using Microsoft.AspNetCore.Mvc;
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
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<string> Create(CreateUserDto user)
        {
            return await _userService.Create(new User() 
                { 
                    Login = user.Login, 
                    Password = user.Password,
                    ConfirmPassword = user.ConfirmPassword
                });
        }

        [HttpGet("{id}")]
        public async Task<UserDto> Get(int id)
        {
            var model = await _userService.Get(id);
            
            return new UserDto()
            {
                Id = model.Id,
                Login = model.Login
            };
        }
    }
}
