using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using DiscountCards.Core.Domains.Cards.Services;
using DiscountCards.Core.Domains.Maps;
using DiscountCards.Core.Domains.Users.Services;
using DiscountCards.Core.Domains.ShopLocations.Services;
using DiscountCards.Core.Domains.Shops.Services;

namespace DiscountCards.Core
{
    public static class Bootstraps
    {
        public static IServiceCollection AddCore(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<IShopLocationsService, ShopLocationsService>()
                .AddScoped<ICardsService, CardsService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IShopService, ShopService>();
                
            return serviceCollection;
        }
    }
}
