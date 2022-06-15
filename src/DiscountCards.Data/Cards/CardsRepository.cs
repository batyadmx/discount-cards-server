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

            var shop = await _context.Shops.FirstOrDefaultAsync(c => c.Id == entity.ShopId);
            
            if (shop == null)
                throw new ObjectNotFoundException($"Магазин с id={entity.ShopId} не найден");
            
            var card = new Card() { 
                Id = entity.Id, 
                UserId = entity.UserId,
                ShopName = shop.Name,
                Number = entity.Number,
                Standart = entity.Standart
            };

            return card;
        }

        public async Task<IEnumerable<Card>> GetAllUserCards(string login)
        {
            return await _context.Cards.Include(x => x.User).Where(x => x.User.Login == login).Select(cardDbModel => new Card
            {
                Id = cardDbModel.Id,
                UserId = cardDbModel.UserId,
                ShopName = cardDbModel.Shop.Name,
                Number = cardDbModel.Number,
                Standart = cardDbModel.Standart
            }).ToListAsync();
        }

        public async Task<int> Create(Card card)
        {
            var shop = await _context.Shops.FirstOrDefaultAsync(it => it.Name == card.ShopName);

            if (shop == null)
                throw new ObjectNotFoundException($"Магазина с name={card.ShopName} не существует");

            var entity = new CardDbModel()
            {
                UserId = card.UserId,
                ShopId = shop.Id,
                Number = card.Number,
                Standart = card.Standart
            };
            
            await _context.Cards.AddAsync(entity);
            
            await _context.SaveChangesAsync();
            
            return entity.Id;
        }

        public async Task Delete(string number)
        {
            var entity = await _context.Cards.FirstOrDefaultAsync(c => c.Number == number);

            if (entity == null)
                throw new ObjectNotFoundException($"Карта с number={number} не найдена");
            
            _context.Cards.Remove(entity);
            
            await _context.SaveChangesAsync();
        }
    }
}
