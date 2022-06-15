using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.ShopLocations.Repositories;
using DiscountCards.Core.Domains.Maps;

namespace DiscountCards.Core.Domains.ShopLocations.Services
{
    public class ShopLocationsService : IShopLocationsService
    {
        private readonly IShopLocationsRepository _shopLocationsRepository;
        private readonly IMapService _mapService;

        public ShopLocationsService(IShopLocationsRepository repository, IMapService mapService)
        {
            _shopLocationsRepository = repository;
            _mapService = mapService;
        }

        public async Task<ShopLocation> GetShopLocation(ShopLocationRequest request)
        {
            //request.City = await _mapService.GetCityByCoordinates(request.Coordinates);

            var shopLocations = await _shopLocationsRepository.GetAll(request);
            
            var shopsInSpn = shopLocations.Where(e => request.Coordinates.GetDistanceTo(e.RequestLocation) < 10000).ToList();

            var abc = shopLocations.Select(x => request.Coordinates.GetDistanceTo(x.RequestLocation)).ToList();

            if (shopsInSpn.Count == 0) 
            {
                shopsInSpn = await _mapService.GetAllShopLocations(request, 0.1, 0.1);
                foreach (var el in shopsInSpn)
                    await _shopLocationsRepository.Add(el, request);
            }
            
            return GetClosestShop(shopsInSpn, request);
        }

        private ShopLocation GetClosestShop(List<ShopLocation> shops, ShopLocationRequest request)
        {
            var min = double.MaxValue;
            ShopLocation closestShop = null;

            foreach (var shop in shops)
            {
                var dist = request.Coordinates.GetDistanceTo(shop.Coordinates);
                if (dist < min)
                {
                    min = dist;
                    closestShop = shop;
                }
            }

            if (closestShop == null)
                return new ShopLocation()
                {
                    Coordinates = new GeoCoordinate()
                    {
                        Latitude = -1,
                        Longitude = -1
                    }
                };
            
            return closestShop;
        }
    }
}
