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
using System.Device.Location;

namespace DiscountCards.Data.ShopLocations
{
    public class ShopLocationsRepository : IShopLocationsRepository
    {
        private DataContext _db;
        public ShopLocationsRepository(DataContext db)
        {
            _db = db;
        }
        public async Task Add(ShopLocation shopLocation, ShopLocationRequest request)
        {
            var shop = await _db.Shops.FirstOrDefaultAsync(s => s.Name == shopLocation.Shop);

            if (shop == null)
                throw new ObjectNotFoundException($"Магазин с именем {shopLocation.Shop} не найден");

            var entity = new ShopLocationDbModel(shopLocation, request, shop.Id);

            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ShopLocation>> GetAll(ShopLocationRequest request)
        {
            var shop = await _db.Shops.FirstOrDefaultAsync(s => s.Name == request.Shop);

            if (shop == null)
                throw new ObjectNotFoundException($"Магазин с именем {request.Shop} не найден");

            var reqShopLocations = await _db.ShopLocations.Where(sl => sl.Shop.Name == request.Shop).ToListAsync();

            return reqShopLocations.Select(
                e => new ShopLocation() { 
                    Shop = e.Shop.Name, 
                    Coordinates = new GeoCoordinate(e.Latitiude, e.Longitude),
                    City = e.City,
                    RequestLocation = new GeoCoordinate(e.RequestLatitude, e.RequestLongitude)
                }
                ).ToList();
        }
    }
}
