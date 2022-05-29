<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
﻿using System.Threading.Tasks;
>>>>>>> 7ea2102d49b461fbb19414479d2bf751fe2c2ca3
using DiscountCards.Core.Domains.ShopLocations;

namespace DiscountCards.Core.Domains.Maps
{
    public interface IMapService
    {
        Task<ShopLocation> GetShopLocation(ShopLocationRequest request);
        Task<string> GetCityByCoordinates(GeoCoordinate coords);
    }
}
