using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiscountCards.Data.Cards;
using DiscountCards.Data.Shops;
using DiscountCards.Data.Users;
using DiscountCards.Data.ShopLocations;
using Microsoft.EntityFrameworkCore.Design;

namespace DiscountCards.Data.Context
{
    public class DataContext : DbContext 
    {
        public DbSet<CardDbModel> Cards { get; set; }
        public DbSet<UserDbModel> Users { get; set; }
        public DbSet<ShopDbModel> Shops { get; set; }
        public DbSet<ShopLocationDbModel> ShopLocations { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
            
            base.OnModelCreating(builder);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
            
            base.OnConfiguring(optionsBuilder);
        }
    }

    public class Factory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseNpgsql("Host=localhost;Port=5432;Database=DiscountCards;Username=discount_cards;Password=qwerty12345")
                .Options;

            return new DataContext(options);
        }
    }
}
