using AspNetCoreHero.EntityFrameworkCore.AuditTrail;
using ExchangeRate.Application.Interfaces.Contexts;
using ExchangeRate.Domain.Entities.BaseEntities;
using ExchangeRate.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeRate.Infrastructure.DbContext
{
    public class ApplicationDbContext : AuditableContext, IApplicationDbContext
    {

        public ApplicationDbContext
            (DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<BankCurrency> BankCurrencies { get; set; }
        public DbSet<ExchangeRateData> ExchangeRateDatas { get; set; }

        public IDbConnection Connection => Database.GetDbConnection();

        public bool HasChanges => ChangeTracker.HasChanges();

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = DateTime.Now;
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BankCurrency>()
               .HasOne(p => p.Bank)
               .WithMany(b => b.BankCurrencies)
               .HasForeignKey(p => p.BankId);

            builder.Entity<BankCurrency>()
                .HasOne(x => x.Currency)
                .WithMany(x => x.BankCurrencys)
                .HasForeignKey(x => x.CurrencyId);

            builder.Entity<ExchangeRateData>()
                .HasOne(x => x.Bank)
                .WithMany(x => x.ExchangeRateDatas)
                .HasForeignKey(x => x.BankId);

            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }
            base.OnModelCreating(builder);
        }
    }
}
