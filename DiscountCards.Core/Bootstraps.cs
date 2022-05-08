using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using DiscountCards.Core.Domains.Cards.Services;
using DiscountCards.Core.Domains.Users.Services;

namespace DiscountCards.Core
{
    public static class Bootstraps
    {
        public static IServiceCollection AddCore(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<ICardsService, CardsService>()
                .AddScoped<IUserService, UserService>();
            
            return serviceCollection;
        }
    }
}
