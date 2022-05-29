using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountCards.API.Controllers.Cards.Dto;
using DiscountCards.Core.Domains.Cards;
using DiscountCards.Core.Domains.Cards.Services;
using DiscountCards.Core.Domains.Users.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiscountCards.API.Controllers.Cards
{
    [ApiController]
    [Route("[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly ICardsService _cardsService;
        private readonly IUserService _userService;

        public CardsController(ICardsService cardsService, IUserService userService)
        {
            _userService = userService;
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
                ShopName = model.ShopName,
                Number = model.Number,
                Standart = model.Standart
            };
        }
        
        [HttpGet("user/{login}")]
        public async Task<IEnumerable<CardDto>> GetAllUserCards(string login)
        {
            var cards = await _cardsService.GetAllUserCards(login);

            return cards.Select(model => new CardDto()
            {
                Id = model.Id,
                UserId = model.UserId,
                ShopName = model.ShopName,
                Number = model.Number,
                Standart = model.Standart
            });
        }

        [HttpPost]
        public async Task<int> Create(CreateCardDto model)
        {
            var user = await  _userService.GetByLogin(model.UserLogin);
                
            return await _cardsService.Create(new Card
            {
                UserId = user.Id,
                ShopName = model.ShopName,
                Number = model.Number,
                Standart = model.Standart
            });
        }

        [HttpDelete("{number}")] 
        public async Task DeleteByNumber(string number)
        {
            await _cardsService.Delete(number);
        }
    }
}
