using ExchangeRate.Application.DTOs.Banks;
using ExchangeRate.Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRate.Application.Interfaces.Repositories
{
    public interface IBankByCurrencyRepository : IRepositoryAsync<ExchangeRateData>
    {
        Task<List<BankByCurrencyDTO>> GetBankByCurrenciesAsync
            (string firstCurrency, string second, IEnumerable<string> banks, DateTime stratDate, DateTime endDate);
    }
}
