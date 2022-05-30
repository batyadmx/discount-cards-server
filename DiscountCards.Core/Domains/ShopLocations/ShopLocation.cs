using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.Maps;

namespace DiscountCards.Core.Domains.ShopLocations
{
    public class ShopLocation
    {
        public GeoCoordinate Coordinates { get; set; }
        public string City { get; set; }
        public string Shop { get; set; }
        public GeoCoordinate RequestLocation { get; set; }
    }
}
