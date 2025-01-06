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
            // Configure precision and scale for decimal properties
            modelBuilder.Entity<ExchangeRateEntity>()
                .Property(e => e.BuyRate)
                .HasColumnType("decimal(18, 6)");  // Precision 18, Scale 6

            modelBuilder.Entity<ExchangeRateEntity>()
                .Property(e => e.MidRate)
                .HasColumnType("decimal(18, 6)");  // Precision 18, Scale 6

            modelBuilder.Entity<ExchangeRateEntity>()
                .Property(e => e.SellRate)
                .HasColumnType("decimal(18, 6)");  // Precision 18, Scale 6

            base.OnModelCreating(modelBuilder);
        }
    }
}