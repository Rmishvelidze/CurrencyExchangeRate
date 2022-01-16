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

        public IQueryable<ExchangeRateData> ExchangeRateDatas => Entities;

        public async Task<List<BankByCurrencyDTO>> GetBankByCurrenciesAsync
            (string firstCurrency, string secondCurrency, IEnumerable<string> banks, DateTime stratDate, DateTime endDate)
        {
            Expression<Func<ExchangeRateData, BankByCurrencyDTO>> expression = e => new BankByCurrencyDTO
            {
                BankCode = e.Bank.BankCode,
                Date = e.Date,
                BuyRate = e.BuyRate,
                SellRate = e.SellRate 
            };

            var bankCurrecny = _dbContext.BankCurrencies;
            //missing sume validations
            var bankCurrencies = bankCurrecny.Select(x => x.Currency.CurrencyName);
            var exchangeRateDatas = ExchangeRateDatas.Where
                (x => x.Date >= stratDate && x.Date <= endDate &&
                banks.Contains(x.Bank.BankName) && x.BuyCurrencyId == bankCurrecny.Where(c=>c.Currency.CurrencyName == firstCurrency).Select(x=>
                x.Id).FirstOrDefault()
                && x.SellCurrencyId == bankCurrecny.Where(c => c.Currency.CurrencyName == secondCurrency).Select(x => x.Id).FirstOrDefault());
                //x.BuyCurrencyId == Currency.Currencies
                //.Where(x=>x.CurrencyName==firstCurrency).Select(x=>x.Id).FirstOrDefault();
            var collection = exchangeRateDatas.Select(expression).ToListAsync();


            return await collection;


            //var exchangeRateData = _repository.Entities.Where
            //    (x => x.Date >= stratDate && x.Date <= endDate &&
            //    x.BuyCurrency.CurrencyName == firstCurrency && x.SellCurrency.CurrencyName == secondCurrency);
            //var collection = exchangeRateData.Select(expression).ToListAsync();
            //return  await collection;
        }
    }
}
