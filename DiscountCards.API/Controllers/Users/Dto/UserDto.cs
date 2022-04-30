using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.Users;

namespace DiscountCards.API.Controllers.Users.Dto
{
    public class UserDto
    {
        public UserDto(User user)
        {
            CreatedAt = user.CreatedAt;
            Id = user.Id;
            Login = user.Login;
        }

        public DateTime CreatedAt { get; set; }
        public int Id { get; set; }
        public string Login { get; set; }
    }
}
