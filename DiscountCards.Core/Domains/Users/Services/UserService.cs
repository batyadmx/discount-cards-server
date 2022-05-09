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

        public async Task<User> GetByLogin(string login)
        {
            return await _userRepository.GetByLogin(login);
        }
        
        public async Task<string> Create(User user)
        {
            if (string.IsNullOrEmpty(user.Login))
                throw new ValidationException("Логин не должен быть пустым");
            
            if (string.IsNullOrEmpty(user.Password))
                throw new ValidationException("Пароль не должен быть пустым");
            
            if (_userRepository.ContainsByLogin(user.Login))
                throw new ValidationException("Логин уже существует");
            
            return await _userRepository.Create(user);
        }

        public async Task Delete(int id)
        {
            await _userRepository.Delete(id);
        }

        public async Task<bool> Authentication(User user)
        {
            if (string.IsNullOrEmpty(user.Login))
                throw new ValidationException("Логин не должен быть пустым");
            
            if (string.IsNullOrEmpty(user.Password))
                throw new ValidationException("Пароль не должен быть пустым");
            
            return await _userRepository.Authentication(user);
        }
    }
}
