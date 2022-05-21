using DiscountCards.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCards.Data.Shops
{
    public class ShopsRepository
    {
        private readonly DataContext _db;
        
        public ShopsRepository(DataContext db)
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
    }
}
