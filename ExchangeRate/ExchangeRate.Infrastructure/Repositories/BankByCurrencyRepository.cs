using ExchangeRate.Application.DTOs.Banks;
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
    public class BankByCurrencyRepository : RepositoryAsync<ExchangeRateData>,IBankByCurrencyRepository
    {
        public BankByCurrencyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
   
        }
        public override async Task<IEnumerable<ExchangeRateData>> ReadAsync(Expression<Func<ExchangeRateData, bool>> predicate)
        {
            return await ExchangeRateDatas.Where(predicate).ToListAsync();
        }

        public IQueryable<ExchangeRateData> ExchangeRateDatas => Entities.Include(x => x.Bank);

        public async Task<List<BankByCurrencyDTO>> GetBankByCurrenciesAsync
            (string firstCurrency, string secondCurrency, IEnumerable<string> banks, DateTime stratDate, DateTime endDate
            
            )
        {
            Expression<Func<ExchangeRateData, BankByCurrencyDTO>> expression = e => new BankByCurrencyDTO
            {
                BankCode = e.Bank.BankCode,
                Date = e.Date,
                BuyRate = e.BuyRate,
                SellRate = e.SellRate 
            };

            var bankCurrecny = _dbContext.BankCurrencies;

            var bankCurrencies = bankCurrecny.Select(x => x.Currency.CurrencyName);
            var exchangeRateDatas = ExchangeRateDatas.Where
                (x => x.Date >= stratDate && x.Date <= endDate &&
                banks.Contains(x.Bank.BankName) && x.BuyCurrency.CurrencyName == firstCurrency
                && x.SellCurrency.CurrencyName == secondCurrency);

            var collection = exchangeRateDatas.Select(expression).ToListAsync();


            return await collection;

        }
    }
}
