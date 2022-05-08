using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<CardDto> Get(int id)
        {
            var model = await _cardsService.Get(id);
            
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
        public async Task<IEnumerable<CardDto>> GetAllUserCards(int userId)
        {
            var cards = await _cardsService.GetAllUserCards(userId);

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
        public async Task<string> Create(CreateCardDto cardInfo)
        {
            return await _cardsService.Create(new Card
            {
                UserId = cardInfo.UserId,
                Name = cardInfo.Name,
                ImageSource = cardInfo.ImageSource,
                Number = cardInfo.Number
            });
        }

        [HttpDelete("{id:int}")] 
        public async Task Delete(int id)
        {
            await _cardsService.Delete(id);
        }
    }
}
