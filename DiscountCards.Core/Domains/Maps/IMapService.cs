using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.ShopLocations;

namespace DiscountCards.Core.Domains.Maps
{
    public interface IMapService
    {
        Task<ShopLocation> GetShopLocation(ShopLocationRequest request);
        Task<string> GetCityByCoordinates(GeoCoordinate coords);
        Task<List<ShopLocation>> GetAllShopLocations(ShopLocationRequest request, double spnLat, double spnLon);
    }
}
