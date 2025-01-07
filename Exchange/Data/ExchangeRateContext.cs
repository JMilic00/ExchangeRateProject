using ExchangeRate.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExchangeRate.Api.Data
{
    public class ExchangeRateContext : DbContext
    {
        public ExchangeRateContext(DbContextOptions<ExchangeRateContext> options) : base(options) { }

        public DbSet<ExchangeRateEntity> ExchangeRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExchangeRateEntity>()
                .Property(e => e.BuyRate)
                .HasColumnType("decimal(18, 6)"); 

            modelBuilder.Entity<ExchangeRateEntity>()
                .Property(e => e.MidRate)
                .HasColumnType("decimal(18, 6)");  

            modelBuilder.Entity<ExchangeRateEntity>()
                .Property(e => e.SellRate)
                .HasColumnType("decimal(18, 6)");  

            base.OnModelCreating(modelBuilder);
        }
    }
}