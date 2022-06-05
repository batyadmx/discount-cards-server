using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCards.Core.Domains.Cards.Repositories
{
    public interface ICardsRepository
    {
        Task<Card> Get(int id);
        Task<IEnumerable<Card>> GetAllUserCards(string login);
        Task<int> Create(Card card);
        Task Delete(string number);
    }
}
