using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.Users.Repositories;

namespace DiscountCards.Core.Domains.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<User> Get(int id)
        {
            return await _userRepository.Get(id);
        }
        
        public async Task<string> Create(User user)
        {
            if (user.Password != user.ConfirmPassword)
                throw new ArgumentException("Пароли должны совпадать");

            if (_userRepository.ContainsByLogin(user.Login))
                throw new ArgumentException("Логин уже существует");
            
            return await _userRepository.Create(user);
        }

        public async Task Delete(int id)
        {
            await _userRepository.Delete(id);
        }
    }
}
