using ExchangeRate.Application.DTOs.Banks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRate.Application.Interfaces.Repositories
{
    public interface IBankByCurrencyRepository
    {
        Task<List<BankByCurrencyDTO>> GetBankByCurrenciesAsync
            (string firstCurrency, string second, ICollection<string> banks, DateTime stratDate, DateTime endDate);


    }
}
