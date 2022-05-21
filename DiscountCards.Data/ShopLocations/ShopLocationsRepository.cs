using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.ShopLocations;
using DiscountCards.Core.Domains.ShopLocations.Repositories;
using DiscountCards.Data.Context;
using Microsoft.EntityFrameworkCore;
using DiscountCards.Core.Domains.Maps;

namespace DiscountCards.Data.ShopLocations
{
    public class ShopLocationsRepository : IShopLocationsRepository
    {
        private DataContext _db;
        public ShopLocationsRepository(DataContext db)
        {
            _db = db;
        }
        public async Task Add(ShopLocation shopLocation)
        {
            var shop = await _db.Shops.FirstOrDefaultAsync(s => s.Id == shopLocation.ShopId);

            if (shop == null)
                throw new ObjectNotFoundException($"Магазин с id {shopLocation.ShopId} не найден");

            var entity = new ShopLocationDbModel(shopLocation);

            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<ShopLocation> Get(ShopLocationRequest request)
        {
            var shop = await _db.Shops.FirstOrDefaultAsync(s => s.Id == request.ShopId);

            if (shop == null)
                throw new ObjectNotFoundException($"Магазин с id {request.ShopId} не найден");

            var reqShopLocations = await _db.ShopLocations.Where(sl => sl.ShopId == request.ShopId).ToListAsync();

            ShopLocationDbModel closestShop = null;
            float minDistance = float.MaxValue;
            foreach (var shopLocation in reqShopLocations)
            {
                var distance = request.Coordinates.DistanceTo(new GeographicalCoordinates(shopLocation.Longtitude, shopLocation.Latitiude));
                if (distance < minDistance)
                    closestShop = shopLocation;
            }
                                                
            
            return closestShop is null ? null : new ShopLocation() {
                                                                        ShopId = closestShop.ShopId,
                                                                        City = closestShop.City,
                                                                        Coordinates = new GeographicalCoordinates(closestShop.Longtitude, closestShop.Latitiude)
                                                                    };
        }
    }
}
