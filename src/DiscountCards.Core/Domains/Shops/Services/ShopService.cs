using System.Collections.Generic;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.Shops.Repositories;

namespace DiscountCards.Core.Domains.Shops.Services
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;

        public ShopService(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public async Task<IEnumerable<Shop>> GetAllShopsAsync()
        {
            return await _shopRepository.GetAllShopsAsync();
        }
    }
}