using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCards.Core.Domains.Cards.Services
{
    public interface ICardsService
    {
        Task<Card> Get(int id);
        Task<IEnumerable<Card>> GetAllUserCards(int userId);
        Task<string> Create(Card card);
        Task Delete(int id);
    }
}
