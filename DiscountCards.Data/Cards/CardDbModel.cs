using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.Cards;

namespace DiscountCards.Data.Cards
{
    public class CardDbModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int UserId { get; set; }

        public CardDbModel()
        {
        }

        public CardDbModel(Card card)
        {
            Number = card.Number;
            UserId = card.UserId;
        }
    }
}
