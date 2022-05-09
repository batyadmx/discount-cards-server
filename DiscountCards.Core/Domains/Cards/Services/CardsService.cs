﻿using System;
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
        
        public async Task<Card> Get(int id)
        {
            return await _cardsRepository.Get(id);
        }

        public async Task<IEnumerable<Card>> GetAllUserCards(string login)
        {
            return await _cardsRepository.GetAllUserCards(login);
        }

        public async Task<string> Create(Card card)
        {
            return await _cardsRepository.Create(card);
        }

        public async Task Delete(int id)
        {
            await _cardsRepository.Delete(id);
        }
    }
}
