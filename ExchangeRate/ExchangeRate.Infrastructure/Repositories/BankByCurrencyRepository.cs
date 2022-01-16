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

            //missing sume validations
            var exchangeRateDatas = ExchangeRateDatas.Where
                (x => x.Date >= stratDate && x.Date <= endDate &&
                banks.Contains(x.Bank.BankName));
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
