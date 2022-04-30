using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.Cards.Repositories;

namespace DiscountCards.Core.Domains.Cards.Services
{
    class CardsService : ICardsService
    {
        private readonly ICardsRepository _cardsRepository;

        public CardsService(ICardsRepository cardsRepository)
        {
            _cardsRepository = cardsRepository;
        }
        
        public Card Get(int id)
        {
            return _cardsRepository.Get(id);
        }

        public IEnumerable<Card> GetAllUserCards(int userId)
        {
            return _cardsRepository.GetAllUserCards(userId);
        }

        public string Create(Card card)
        {
            return _cardsRepository.Create(card);
        }

        public void Delete(int id)
        {
            _cardsRepository.Delete(id);
        }
    }
}
