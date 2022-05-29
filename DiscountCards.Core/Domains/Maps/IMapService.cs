using System.Device.Location;
using System.Threading.Tasks;
using DiscountCards.Core.Domains.ShopLocations;

namespace DiscountCards.Core.Domains.Maps
{
    public interface IMapService
    {
        Task<ShopLocation> GetShopLocation(ShopLocationRequest request);
        Task<string> GetCityByCoordinates(GeoCoordinate coords);
    }
}
