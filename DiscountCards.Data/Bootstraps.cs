using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DiscountCards.Data.Context;
using Microsoft.Extensions.Configuration;
using DiscountCards.Core.Domains.Cards.Repositories;
using DiscountCards.Core.Domains.Users.Repositories;
using DiscountCards.Data.Cards;
using DiscountCards.Data.Users;
using DiscountCards.Data.MapAPI;
using DiscountCards.Core.Domains.Maps;
using DiscountCards.Data.ShopLocations;
using DiscountCards.Core.Domains.ShopLocations.Repositories;
using DiscountCards.Data.Shops;
using System.Net.Http;

namespace DiscountCards.Data
{
    public static class Bootstraps
    {
        public static IServiceCollection AddData(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<DataContext>(options => options
                .UseSnakeCaseNamingConvention()
                .UseNpgsql(configuration["ConnectionStringPostgresql"]));

            serviceCollection
                .AddScoped<ICardsRepository, CardsRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IMapService, YandexMapsAPI>()
                .AddScoped<IShopLocationsRepository, ShopLocationsRepository>()
                .AddScoped<ShopsRepository, ShopsRepository>();
            
            return serviceCollection;
        }
    }
}
