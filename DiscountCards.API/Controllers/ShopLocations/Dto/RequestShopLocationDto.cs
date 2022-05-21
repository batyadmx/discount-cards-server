using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountCards.API.Controllers.ShopLocations.Dto
{
    public class RequestShopLocationDto
    {
        public float Longtitude { get; set; }
        public float Latitude { get; set; }
        public int ShopId { get; set; }
    }
}
