using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.Cards;
using DiscountCards.Core.Domains.Cards.Repositories;
using DiscountCards.Data.Context;
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
                Name = entity.Name,
                ImageSource = entity.ImageSource,
                Number = entity.Number
            };

            return card;
        }

        public async Task<IEnumerable<Card>> GetAllUserCards(int userId)
        {
            return await _context.Cards.Where(it => userId == it.UserId).Select(it => 
                new Card { 
                    Id = it.Id, 
                    UserId = it.UserId,
                    Name = it.Name,
                    ImageSource = it.ImageSource,
                    Number = it.Number
                }).ToListAsync();
        }

        public async Task<string> Create(Card card)
        {
            var entity = new CardDbModel()
            {
                UserId = card.UserId,
                Name = card.Name,
                ImageSource = card.ImageSource,
                Number = card.Number
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
