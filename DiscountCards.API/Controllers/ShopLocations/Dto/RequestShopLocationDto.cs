using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountCards.API.Controllers.ShopLocations.Dto
{
    public class RequestShopLocationDto
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Shop { get; set; }
    }
}
