using System;
using System.Collections.Generic;
using System.Linq;
using DiscountCards.API.Controllers.Cards.Dto;
using DiscountCards.Core.Domains.Cards;
using DiscountCards.Core.Domains.Cards.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DiscountCards.API.Controllers.Cards
{
    [ApiController]
    [Route("[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly ICardsService _cardsService;

        public CardsController(ICardsService cardsService)
        {
            _cardsService = cardsService;
        }
        
        [HttpGet("{id:int}")]
        public CardDto Get(int id)
        {
            var model = _cardsService.Get(id);
            
            return new CardDto()
            {
                Id = model.Id,
                UserId = model.UserId,
                Name = model.Name,
                ImageSource = model.ImageSource,
                Number = model.Number
            };
        }
        
        [HttpGet("user/{userId:int}")]
        public IEnumerable<CardDto> GetAllUserCards(int userId)
        {
            var cards = _cardsService.GetAllUserCards(userId);

            return cards.Select(model => new CardDto()
            {
                Id = model.Id,
                UserId = model.UserId,
                Name = model.Name,
                ImageSource = model.ImageSource,
                Number = model.Number
            });
        }

        [HttpPost]
        public string Create(CreateCardDto cardInfo)
        {
            return _cardsService.Create(new Card
            {
                UserId = cardInfo.UserId,
                Name = cardInfo.Name,
                ImageSource = cardInfo.ImageSource,
                Number = cardInfo.Number
            });
        }

        [HttpDelete("{id:int}")] 
        public void Delete(int id)
        {
            _cardsService.Delete(id);
        }
    }
}
