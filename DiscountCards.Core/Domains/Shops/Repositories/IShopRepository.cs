using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscountCards.Core.Domains.Shops.Repositories
{
    public interface IShopRepository
    {
        Task<IEnumerable<Shop>> GetAllShopsAsync();
        Task<string> GetShopName(int id);
    }
}