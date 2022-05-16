using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DiscountCards.Data.Context;
using Microsoft.Extensions.Configuration;
using DiscountCards.Core.Domains.Cards.Repositories;
using DiscountCards.Core.Domains.Users.Repositories;
using DiscountCards.Data.Cards;
using DiscountCards.Data.Users;

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
                .AddScoped<IUserRepository, UserRepository>();
            
            return serviceCollection;
        }
    }
}
