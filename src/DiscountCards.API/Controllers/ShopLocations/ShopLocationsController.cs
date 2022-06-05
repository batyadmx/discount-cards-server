using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountCards.API.Controllers.ShopLocations.Dto;
using DiscountCards.Core.Domains.ShopLocations.Services;
using DiscountCards.Core.Domains.ShopLocations;
using DiscountCards.Core.Domains.Maps;
using System.Device.Location;

namespace DiscountCards.API.Controllers.ShopLocations
{
    [ApiController]
    [Route("[controller]")]
    public class ShopLocationsController : Controller
    {
        private readonly IShopLocationsService _shopLocationsService;

        public ShopLocationsController(IShopLocationsService shopLocationsService)
        {
            _shopLocationsService = shopLocationsService;
        }
        
        [HttpPost]
        public async Task<ResponseShopLocationDto> GetShopLocation(RequestShopLocationDto request)
        {
            var shopLocationRequest = new ShopLocationRequest()
            {
                Coordinates = new GeoCoordinate() { Latitude = request.Latitude, Longitude = request.Longitude },
                Shop = request.Shop
            };

            var shopLocation = await _shopLocationsService.GetShopLocation(shopLocationRequest);

            return new ResponseShopLocationDto(shopLocation);
        }

    }
}
