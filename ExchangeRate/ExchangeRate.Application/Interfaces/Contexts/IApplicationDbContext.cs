using ExchangeRate.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeRate.Application.Interfaces.Contexts
{
    public interface IApplicationDbContext
    {
        IDbConnection Connection { get; }
        bool HasChanges { get; }

        EntityEntry Entry(object entity);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        DbSet<Bank> Banks { get; set; }
        DbSet<Currency> Currencies { get; set; }
        DbSet<BankCurrency> BankCurrencies { get; set;}
        DbSet<ExchangeRateData> ExchangeRateDatas { get; set; }
    }
}
