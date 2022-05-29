using DiscountCards.Data.Shops;
using DiscountCards.Core.Domains.ShopLocations;

namespace DiscountCards.Data.ShopLocations
{
    public class ShopLocationDbModel
    {
        public int Id { get; set; }
        public double Longtitude { get; set; }
        public double Latitiude { get; set; }
        public string City { get; set; }
        public int ShopId { get; set; }
        public virtual ShopDbModel Shop{ get; set; }

        public ShopLocationDbModel() { }

        public ShopLocationDbModel(ShopLocation shopLocation)
        {
            Longtitude = shopLocation.Coordinates.Longitude;
            Latitiude = shopLocation.Coordinates.Latitude;
            City = shopLocation.City;
        } 
    }
}
