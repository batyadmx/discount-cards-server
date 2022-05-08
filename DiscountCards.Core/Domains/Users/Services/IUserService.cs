using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCards.Core.Domains.Users.Services
{
    public interface IUserService
    {
        Task<User> Get(int id);
        Task<string> Create(User user);
        Task Delete(int id);
    }
}
