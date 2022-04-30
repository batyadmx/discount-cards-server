﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiscountCards.Data.Cards;
using Microsoft.EntityFrameworkCore.Design;

namespace DiscountCards.Data.Context
{
    public class DataContext : DbContext 
    {
        public DbSet<CardDbModel> Cards { get; set; }

        public DataContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CardDbModel>().HasData(new CardDbModel() { Id = -1, Number = "1234567", UserId = -1}
                                                 ,new CardDbModel() { Id = -2, Number = "7654321", UserId = -2 });  
            
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
            var options = new DbContextOptionsBuilder()
                .UseNpgsql("FakeConnectionStringOnlyForMigrations")
                .Options;

            return new DataContext(options);
        }
    }
}