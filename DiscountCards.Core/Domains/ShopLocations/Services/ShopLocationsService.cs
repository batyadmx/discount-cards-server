using System;
using System.Collections.Generic;
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

            ShopLocation shopLocation = await _shopLocationsRepository.Get(request);

            if (shopLocation == null) 
            {
                shopLocation = await _mapService.GetShopLocation(request);
                await _shopLocationsRepository.Add(shopLocation);
            }
                
            return shopLocation;
        }
    }
}
