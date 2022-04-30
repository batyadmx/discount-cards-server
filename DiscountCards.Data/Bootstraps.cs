using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DiscountCards.Data.Context;
using Microsoft.Extensions.Configuration;
using DiscountCards.Core.Domains.Cards.Repositories;
using DiscountCards.Data.Cards;

namespace DiscountCards.Data
{
    public static class Bootstraps
    {
        public static IServiceCollection AddData(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<DataContext>(options => options
                .UseSnakeCaseNamingConvention()
                .UseNpgsql(configuration["ConnectionStringPostgresql"]));
            
            serviceCollection.AddScoped<ICardsRepository, CardsRepository>();
            
            return serviceCollection;
        }
    }
}
