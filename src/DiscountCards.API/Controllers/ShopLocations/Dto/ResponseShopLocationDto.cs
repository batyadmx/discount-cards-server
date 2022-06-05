using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.ShopLocations;

namespace DiscountCards.API.Controllers.ShopLocations.Dto
{
    public class ResponseShopLocationDto
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Shop { get; set; }

        public ResponseShopLocationDto(ShopLocation location)
        {
            Longitude = location.Coordinates.Longitude;
            Latitude = location.Coordinates.Latitude;
            Shop = location.Shop;
        }
    }
}
