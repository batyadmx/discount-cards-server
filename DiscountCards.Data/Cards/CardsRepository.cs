using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using DiscountCards.Core.Domains.Cards;
using DiscountCards.Core.Domains.Cards.Repositories;
using DiscountCards.Core.Domains.Users;
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
        
        public Card Get(int id)
        {
            var entity = _context.Cards.FirstOrDefault(c => c.Id == id);

            if (entity == null)
                throw new ObjectNotFoundException($"Карта с id={id} не найдена");
            
            var card = new Card() { 
                Id = entity.Id, 
                UserId = entity.UserId,
                Name = entity.Name,
                ImageSource = entity.ImageSource,
                Number = entity.Number
            };
            
            _context.SaveChanges();
            
            return card;
        }

        public IEnumerable<Card> GetAllUserCards(int userId)
        {
            return _context.Cards.Where(it => userId == it.UserId).Select(it => 
                new Card { 
                    Id = it.Id, 
                    UserId = it.UserId,
                    Name = it.Name,
                    ImageSource = it.ImageSource,
                    Number = it.Number
                }).ToList();
        }

        public string Create(Card card)
        {
            var entity = new CardDbModel()
            {
                UserId = card.UserId,
                Name = card.Name,
                ImageSource = card.ImageSource,
                Number = card.Number
            };
            
            _context.Cards.Add(entity);
            
            _context.SaveChanges();
            
            return entity.Id.ToString();
        }

        public void Delete(int id)
        {
            var entity = _context.Cards.FirstOrDefault(c => c.Id == id);

            if (entity == null)
                throw new ObjectNotFoundException($"Карта с id={id} не найдена");
            
            _context.Cards.Remove(entity);
            
            _context.SaveChanges();
        }
    }
}
