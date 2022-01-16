using ExchangeRate.Application.Interfaces.Repositories;
using ExchangeRate.Domain.Entities.Catalog;
using ExchangeRate.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExchangeRate.Infrastructure.Repositories
{
    public class EchangeRateRepository : RepositoryAsync<ExchangeRateData>, IBankByCurrencyRepository
    {
        public EchangeRateRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public override async Task<IEnumerable<ExchangeRateData>> ReadAsync(Expression<Func<ExchangeRateData, bool>> predicate)
        {
            return await ExchangeRateDatas.Where(predicate).ToListAsync();
        }
        public override async Task<ExchangeRateData> GetByIdAsync(int id)
        {
            return await ExchangeRateDatas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<ExchangeRateData> ExchangeRateDatas => Entities.Include(x => x.Bank);

    }
}
