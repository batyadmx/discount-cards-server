using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.Cards;
using DiscountCards.Core.Domains.Cards.Repositories;
using DiscountCards.Data.Context;
using DiscountCards.Data.Users;
using Microsoft.EntityFrameworkCore;

namespace DiscountCards.Data.Cards
{
    public class CardsRepository : ICardsRepository
    {
        private readonly DataContext _context;

        public CardsRepository(DataContext db)
        {
            _context = db;
        }
        
        public async Task<Card> Get(int id)
        {
            var entity = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);

            if (entity == null)
                throw new ObjectNotFoundException($"Карта с id={id} не найдена");
            
            var card = new Card() { 
                Id = entity.Id, 
                UserId = entity.UserId,
                ShopId = entity.ShopId,
                Number = entity.Number,
                Standart = entity.Standart
            };

            return card;
        }

        public async Task<IEnumerable<Card>> GetAllUserCards(string login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(it => it.Login == login);

            if (user == null)
                throw new ObjectNotFoundException($"Пользователь с login={login} не найден");

            return await _context.Cards.Where(it => it.UserId == user.Id).Select(it => 
                new Card { 
                    Id = it.Id, 
                    UserId = it.UserId,
                    ShopId = it.ShopId,
                    Number = it.Number,
                    Standart = it.Standart
                }).ToListAsync();
        }

        public async Task<string> Create(Card card)
        {
            var shop = await _context.Shops.FirstOrDefaultAsync(it => it.Id == card.ShopId);

            if (shop == null)
                throw new ObjectNotFoundException($"Магазина с id={card.ShopId} не существует");

            var entity = new CardDbModel()
            {
                UserId = card.UserId,
                ShopId = card.ShopId,
                Number = card.Number,
                Standart = card.Standart
            };
            
            await _context.Cards.AddAsync(entity);
            
            await _context.SaveChangesAsync();
            
            return entity.Id.ToString();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);

            if (entity == null)
                throw new ObjectNotFoundException($"Карта с id={id} не найдена");
            
            _context.Cards.Remove(entity);
            
            await _context.SaveChangesAsync();
        }
    }
}
