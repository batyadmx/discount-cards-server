using DiscountCards.Core.Domains.Maps;
using DiscountCards.Core.Domains.ShopLocations;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;
using System.Device.Location;
using DiscountCards.Core.Domains.Shops.Repositories;

namespace DiscountCards.Data.MapAPI
{
    public class YandexMapsAPI : IMapService
    {
        private HttpClient _httpClient;
        private IConfiguration _configuration;
        private IShopRepository _shopRepository;

        public YandexMapsAPI(HttpClient httpClient, IConfiguration configuration, IShopRepository shopRepository)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _shopRepository = shopRepository;
        }

        public async Task<string> GetCityByCoordinates(GeoCoordinate coords)
        {
            return "";
        }

        public async Task<ShopLocation> GetShopLocation(ShopLocationRequest request)
        {
            var api_key = _configuration["SecretYandexApiKey"];
            var coords = $"{request.Coordinates.Longitude},{request.Coordinates.Latitude}";
            var shop = request.Shop;

            var response = await _httpClient.GetAsync($"https://search-maps.yandex.ru/v1/?text={shop}&apikey={api_key}&lang=ru_RU&ll={coords}&results=1");
            var rawJson = await response.Content.ReadAsStringAsync();

            var shopCoords = GetAllShopCoordinatesFromJson(rawJson);

            return new ShopLocation() { Shop = request.Shop, City = "Екатеринбург", Coordinates = shopCoords[0] };
        }

        private static List<GeoCoordinate> GetAllShopCoordinatesFromJson(string rawJson)
        {
            List<GeoCoordinate> allShopCoords = new List<GeoCoordinate>();

            using (JsonDocument document = JsonDocument.Parse(rawJson))
            {
                var root = document.RootElement;

                if (root.GetProperty("features").EnumerateArray().Count() == 0)
                    return new List<GeoCoordinate>();
                    // throw new Exception($"Магазин не найден на карте");

                foreach (var shopInfo in root.GetProperty("features").EnumerateArray())
                {
                    var shopCoords = shopInfo.GetProperty("geometry")
                                           .GetProperty("coordinates")
                                           .EnumerateArray()
                                           .ToList()
                                           .Select(je => je.GetDouble())
                                           .ToList();
                    allShopCoords.Add(new GeoCoordinate(shopCoords[1], shopCoords[0]));
                }
            }

            return allShopCoords;
        }

        public async Task<List<ShopLocation>> GetAllShopLocations(ShopLocationRequest request, double spnLat, double spnLon)
        {
            var format = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            var api_key = _configuration["SecretYandexApiKey"];
            var coords = $"{request.Coordinates.Longitude.ToString(format)},{request.Coordinates.Latitude.ToString(format)}";
            var shop = request.Shop;
            var apiReq = $"https://search-maps.yandex.ru/v1/?text={shop}&apikey={api_key}&spn={spnLat.ToString(format)},{spnLon.ToString(format)}&lang=ru_RU&ll={coords}&results=500&rspn=1";

            var resp = await _httpClient.GetAsync(apiReq);

            var allShopCoords = GetAllShopCoordinatesFromJson(await resp.Content.ReadAsStringAsync());

            return allShopCoords.Select(c => new ShopLocation() { Shop = shop, Coordinates = c, City = "Екатеринбург"}).ToList();
        }
    }
}
