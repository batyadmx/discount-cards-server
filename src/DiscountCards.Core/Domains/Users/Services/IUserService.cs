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
        Task<User> GetByLogin(string login);
        Task<string> Create(User user);
        Task Delete(int id);
        Task<bool> Authentication(User user);
        Task ChangePassword(ChangePassword changePasswordModel);
    }
}
