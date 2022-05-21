using DiscountCards.Data.Shops;
using DiscountCards.Core.Domains.ShopLocations;

namespace DiscountCards.Data.ShopLocations
{
    public class ShopLocationDbModel
    {
        public int Id { get; set; }
        public float Longtitude { get; set; }
        public float Latitiude { get; set; }
        public string City { get; set; }
        public int ShopId { get; set; }
        public virtual ShopDbModel Shop{ get; set; }

        public ShopLocationDbModel() { }

        public ShopLocationDbModel(ShopLocation shopLocation)
        {
            Longtitude = shopLocation.Coordinates.Longtitude;
            Latitiude = shopLocation.Coordinates.Latitude;
            City = shopLocation.City;
            ShopId = shopLocation.ShopId;
        } 
    }
}
