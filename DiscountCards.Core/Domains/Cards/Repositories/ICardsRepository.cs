using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCards.Core.Domains.Cards.Repositories
{
    public interface ICardsRepository
    {
        Card Get(int id);
        IEnumerable<Card> GetAllUserCards(int userId);
        string Create(Card card);
        void Delete(int id);
    }
}
