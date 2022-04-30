using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCards.Core.Domains.Cards.Services
{
    public interface ICardsService
    {
        string Create(Card card);
        Card Get(int id);
        string Delete(int id);
    }
}
