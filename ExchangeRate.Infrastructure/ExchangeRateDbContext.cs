using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Infrastructure
{
    public class ExchangeRateDbContext : DbContext
    {
        public ExchangeRateDbContext(DbContextOptions<ExchangeRateDbContext> options)
             : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExchangeRateDbContext).Assembly);

            //modelBuilder.Entity<ExchangeRateEntity>().ToTable("ExchangeRateEntities");
            //modelBuilder.Entity<ExchangeRateEntity>().Property(e => e.BuyRate).HasColumnType("decimal(18,4)");

            modelBuilder.Entity<ExchangeRateEntity>()
                 .Property(e => e.BuyRate)
                 .HasColumnType("decimal(18, 4)"); // Set precision and scale for BuyRate

            modelBuilder.Entity<ExchangeRateEntity>()
                .Property(e => e.MidRate)
                .HasColumnType("decimal(18, 4)");  // Set precision and scale for MidRate

            modelBuilder.Entity<ExchangeRateEntity>()
                .Property(e => e.SellRate)
                .HasColumnType("decimal(18, 4)"); // Set precision and scale for SellRate

            modelBuilder.Entity<ExchangeRateEntity>()
                .Property(e => e.BrojTecajnice)
                .IsRequired();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<ExchangeRateEntity> ExchangeRate { get; set; }
       
    }
}
