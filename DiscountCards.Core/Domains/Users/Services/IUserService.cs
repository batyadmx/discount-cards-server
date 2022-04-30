using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCards.Core.Domains.Users.Services
{
    public interface IUserService
    {
        string Create(User user);
        User Get(int id);
        string Delete(int id);
    }
}
