using DiscountCards.Core;
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
using DiscountCards.Core.Domains.Shops.Repositories;

namespace DiscountCards.Data
{
    public static class Bootstraps
    {
        public static IServiceCollection AddData(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddScoped<ICardsRepository, CardsRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IShopRepository, ShopRepository>()
                .AddScoped<IMapService, YandexMapsAPI>()
                .AddScoped<IShopLocationsRepository, ShopLocationsRepository>();
            
            serviceCollection.AddDbContext<DataContext>(options => options
                .UseSnakeCaseNamingConvention()
                .UseNpgsql(configuration["ConnectionStringPostgresql"]));

            return serviceCollection;
        }
    }
}
