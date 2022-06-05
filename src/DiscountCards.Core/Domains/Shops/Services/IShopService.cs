using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscountCards.Core.Domains.Shops.Services
{
    public interface IShopService
    {
        Task<IEnumerable<Shop>> GetAllShopsAsync();
    }
}