﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountCards.API.Controllers.Cards.Dto;
using DiscountCards.Core.Domains.Cards;
using DiscountCards.Core.Domains.Cards.Services;
using DiscountCards.Core.Domains.Users.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

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
                ShopId = model.ShopId,
                Number = model.Number
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
                ShopId = model.ShopId,
                Number = model.Number
            });
        }

        [HttpPost]
        public async Task<string> Create(CreateCardDto model)
        {
            var user = await  _userService.GetByLogin(model.UserLogin);
                
            return await _cardsService.Create(new Card
            {
                UserId = user.Id,
                ShopId = model.ShopId,
                Number = model.Number
            });
        }

        [HttpDelete("{id:int}")] 
        public async Task Delete(int id)
        {
            await _cardsService.Delete(id);
        }
    }
}
