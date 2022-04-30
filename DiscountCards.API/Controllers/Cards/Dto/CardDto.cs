using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.Cards;

namespace DiscountCards.API.Controllers.Cards.Dto
{
    public class CardDto
    {
        public CardDto(Card card)
        {
            Id = card.Id;
            Number = card.Number;
            UserId = card.UserId;
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public int UserId { get; set; }
    }
}
