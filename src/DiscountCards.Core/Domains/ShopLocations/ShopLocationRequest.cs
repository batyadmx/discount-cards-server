using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.Maps;

namespace DiscountCards.Core.Domains.ShopLocations
{
    public class ShopLocationRequest
    {
        public GeoCoordinate Coordinates { get; set; }
        public string Shop { get; set; }
        public string City { get; set; }
    }
}
