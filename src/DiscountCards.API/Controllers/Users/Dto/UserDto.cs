using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.Users;

namespace DiscountCards.API.Controllers.Users.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
    }
}
