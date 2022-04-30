using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.Cards;
using DiscountCards.Core.Domains.Cards.Repositories;
using DiscountCards.Data.Context;
using DiscountCards.Data.Cards;

namespace DiscountCards.Data.Cards
{
    public class CardsRepository : ICardsRepository
    {
        private readonly DataContext db;

        public CardsRepository(DataContext db)
        {
            this.db = db;
        }

        public string Create(Card card)
        {
            var entity = new CardDbModel()
            {
                UserId = card.UserId,
                Number = card.Number
            };
            
            db.Cards.Add(entity);
            
            db.SaveChanges();
            
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {
            var model = db.Cards.FirstOrDefault(c => c.Id == id);

            if (model == null)
                throw new ObjectNotFoundException($"Карта с id={id} не найдена");
            
            db.Cards.Remove(model);
            
            db.SaveChanges();
            
            return id.ToString();
        }

        public Card Get(int id)
        {
            var model = db.Cards.FirstOrDefault(c => c.Id == id);

            if (model == null)
                throw new ObjectNotFoundException($"Карта с id={id} не найдена");
            
            var card = new Card() { 
                Id = model.Id, 
                Number = model.Number, 
                UserId = model.UserId 
            };
            
            db.SaveChanges();
            
            return card;
        }
    }
}
