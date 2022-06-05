using DiscountCards.Data.Shops;
using DiscountCards.Core.Domains.ShopLocations;

namespace DiscountCards.Data.ShopLocations
{
    public class ShopLocationDbModel
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitiude { get; set; }
        public string City { get; set; }
        public int ShopId { get; set; }
        public virtual ShopDbModel Shop{ get; set; }
        public double RequestLongitude { get; set; }
        public double RequestLatitude { get; set; }

        public ShopLocationDbModel() { }

        public ShopLocationDbModel(ShopLocation shopLocation, ShopLocationRequest request, int shopId)
        {
            Longitude = shopLocation.Coordinates.Longitude;
            Latitiude = shopLocation.Coordinates.Latitude;
            RequestLatitude = request.Coordinates.Latitude;
            RequestLongitude = request.Coordinates.Longitude;
            ShopId = shopId;
            City = shopLocation.City;
        } 
    }
}
