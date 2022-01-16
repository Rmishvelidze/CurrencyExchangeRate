using ExchangeRate.Application.DTOs.Banks;
using ExchangeRate.Application.Interfaces.Repositories;
using ExchangeRate.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExchangeRate.Infrastructure.Repositories
{
    public class BankByCurrencyRepository : IBankByCurrencyRepository
    {
        private readonly IRepositoryAsync<ExchangeRateData> _repository;
        private readonly IDistributedCache _distributedCache;

        public BankByCurrencyRepository(IRepositoryAsync<ExchangeRateData> repository, IDistributedCache distributedCache)
        {
            _repository = repository;   
            _distributedCache = distributedCache;
        }

        public IQueryable<ExchangeRateData> ExchangeRateDatas => _repository.Entities;
        public async Task<List<BankByCurrencyDTO>> GetBankByCurrenciesAsync
            (string firstCurrency, string secondCurrency, ICollection<string> banks, DateTime stratDate, DateTime endDate)
        {
            Expression<Func<ExchangeRateData, BankByCurrencyDTO>> expression = e => new BankByCurrencyDTO
            {
                BankCode = e.Bank.BankCode,
                Date = e.Date,
                BuyRate = e.BuyRate,
                SellRate = e.SellRate
            };

            return await Task.Run(() => new List<BankByCurrencyDTO>());
            //var exchangeRateData = _repository.Entities.Where
            //    (x => x.Date >= stratDate && x.Date <= endDate &&
            //    x.BuyCurrency.CurrencyName == firstCurrency && x.SellCurrency.CurrencyName == secondCurrency);
            //var collection = exchangeRateData.Select(expression).ToListAsync();
            //return  await collection;
        }
    }
}
