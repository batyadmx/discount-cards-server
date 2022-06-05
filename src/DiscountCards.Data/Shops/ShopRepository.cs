using DiscountCards.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.Shops;
using DiscountCards.Core.Domains.Shops.Repositories;

namespace DiscountCards.Data.Shops
{
    public class ShopRepository : IShopRepository
    {
        private readonly DataContext _db;
        
        public ShopRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<string> GetShopName(int id)
        {
            var shopName = await _db.Shops.FirstOrDefaultAsync(shop => shop.Id == id);

            if (shopName is null)
                throw new ObjectNotFoundException($"Shop с таким {id} не найден");

            return shopName.Name;
        }

        public async Task<IEnumerable<Shop>> GetAllShopsAsync()
        {
            return await _db.Shops.Select(x => new Shop()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }
    }
}
