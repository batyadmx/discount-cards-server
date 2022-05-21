using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.Maps;

namespace DiscountCards.Core.Domains.ShopLocations
{
    public class ShopLocationRequest
    {
        public GeographicalCoordinates Coordinates { get; set; }
        public int ShopId { get; set; }
        public string City { get; set; }
    }
}
