using System;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.Users;
using DiscountCards.Core.Domains.Users.Repositories;
using DiscountCards.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DiscountCards.Data.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext db)
        {
            _context = db;
        }
        
        public async Task<User> Get(int id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);

            if (entity == null)
                throw new ObjectNotFoundException($"Пользователь с id={id} не найден");

            return new User()
            {
                Id = entity.Id,
                Login = entity.Login,
                Password = entity.Password
            };
        }

        public async Task<User> GetByLogin(string login)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(c => c.Login == login);
            
            if (entity == null)
                throw new ObjectNotFoundException($"Пользователь с login={login} не найден");
            
            return new User()
            {
                Id = entity.Id,
                Login = entity.Login,
                Password = entity.Password
            };
        }

        public async Task<string> Create(User user)
        {
            var entity = new UserDbModel()
            {
                Login = user.Login,
                Password = user.Password,
                CreatedAt = DateTime.Now
            };
            
            await _context.Users.AddAsync(entity);
            
            await _context.SaveChangesAsync();
            
            return entity.Id.ToString();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);

            if (entity == null)
                throw new ObjectNotFoundException($"Пользователь с id={id} не найден");
            
            _context.Users.Remove(entity);
            
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(it => it.Id == user.Id);

            if (entity == null)
                throw new ObjectNotFoundException($"Пользователь с Id = {user.Id} не найден");

            entity.Login = user.Login;
            entity.Password = user.Password;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Authentication(User user)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(c => c.Login == user.Login);
            
            if (entity == null)
                throw new ObjectNotFoundException($"Пользователь с id={user.Id} не найден");

            return entity.Password == user.Password;
        }

        public bool ContainsByLogin(string login) => _context
            .Users
            .Any(user => user.Login == login);
    }
}