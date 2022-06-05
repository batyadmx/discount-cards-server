using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCards.Core.Domains.Users.Repositories
{
    public interface IUserRepository
    {
        Task<User> Get(int id);
        Task<User> GetByLogin(string login);
        Task<string> Create(User user);
        Task Delete(int id);
        Task Update(User user);
        Task<bool> Authentication(User user);
        bool ContainsByLogin(string login);
    }
}
