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
        private readonly ICardsRepository cardsRepository;

        public CardsService(ICardsRepository cardsRepository)
        {
            this.cardsRepository = cardsRepository;
        }

        public string Create(Card card)
        {
            return cardsRepository.Create(card);
        }

        public string Delete(int id)
        {
            return cardsRepository.Delete(id);
        }

        public Card Get(int id)
        {
            return cardsRepository.Get(id);
        }
    }
}
