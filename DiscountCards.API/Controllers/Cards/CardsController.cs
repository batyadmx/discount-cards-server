using DiscountCards.API.Controllers.Cards.Dto;
using DiscountCards.Core.Domains.Cards;
using DiscountCards.Core.Domains.Cards.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiscountCards.API.Controllers.Cards
{
    public class CardsController : ControllerBase
    {
        private readonly ICardsService cardsService;

        public CardsController(ICardsService cardsService)
        {
            this.cardsService = cardsService;
        }

        [HttpPost]
        [Route("cards/create")]
        public string Create(CreateCardDto cardInfo)
        {
            return cardsService.Create(new Card() { Number = cardInfo.Number, UserId = cardInfo.UserId});
        }

        [HttpGet]
        [Route("cards/{id}")]
        public CardDto Get(int id)
        {
            return new CardDto(cardsService.Get(id));
        }
    }
}
