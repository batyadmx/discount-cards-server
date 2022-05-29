using DiscountCards.Core.Domains.Maps;
using DiscountCards.Core.Domains.ShopLocations;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;
using DiscountCards.Core.Domains.Shops.Repositories;
using System.Device.Location;

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
            var api_key = _configuration["SecretYandexApiKey"];

            var response = await _httpClient.GetAsync($"https://search-maps.yandex.ru/v1/?text={coords}&apikey={api_key}&lang=ru_RU&results=1");
            var rawJson = await response.Content.ReadAsStringAsync();

            string city;

            using (JsonDocument document = JsonDocument.Parse(rawJson))
            {
                var root = document.RootElement;

                var shopInfo = root.GetProperty("features")
                                     .EnumerateArray()
                                     .ElementAt(0);

                var address = shopInfo.GetProperty("properties")
                                      .GetProperty("description")
                                      .GetRawText();

                city = address.Split(',')[address.Split(',').Length - 3].Trim();
            }

            return city;
        }

        public async Task<ShopLocation> GetShopLocation(ShopLocationRequest request)
        {
            var api_key = _configuration["SecretYandexApiKey"];
            var coords = request.Coordinates;
            var shop = request.Shop;

            var response = await _httpClient.GetAsync($"https://search-maps.yandex.ru/v1/?text={shop}&apikey={api_key}&lang=ru_RU&ll={coords}&results=1");
            var rawJson = await response.Content.ReadAsStringAsync();

            var shopCoords = GetShopCoordinatesFromJson(rawJson);

            return new ShopLocation() { Shop = request.Shop, City = "Арстотска", Coordinates = shopCoords};
        }

        private static GeoCoordinate GetShopCoordinatesFromJson(string rawJson)
        {
            List<double> shopCoords;

            using (JsonDocument document = JsonDocument.Parse(rawJson))
            {
                var root = document.RootElement;

                if (root.GetProperty("features").EnumerateArray().Count() == 0)
                    throw new Exception($"Магазин не найден на карте");

                var shopInfo = root.GetProperty("features")
                                     .EnumerateArray()
                                     .ElementAt(0);

                shopCoords = shopInfo.GetProperty("geometry")
                                     .GetProperty("coordinates")
                                     .EnumerateArray()
                                     .ToList()
                                     .Select(je => je.GetDouble())
                                     .ToList();
            }

            return new GeoCoordinate(shopCoords[0], shopCoords[1]);
        }
    }
}
