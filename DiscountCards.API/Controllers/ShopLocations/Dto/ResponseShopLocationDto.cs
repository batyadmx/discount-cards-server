using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.ShopLocations;

namespace DiscountCards.API.Controllers.ShopLocations.Dto
{
    public class ResponseShopLocationDto
    {
        public float Longtitude { get; set; }
        public float Latitude { get; set; }

        public ResponseShopLocationDto(ShopLocation location)
        {
            Longtitude = location.Coordinates.Longtitude;
            Latitude = location.Coordinates.Latitude;
        }
    }
}
