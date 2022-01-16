using ExchangeRate.Application.DTOs.Banks;
using ExchangeRate.Application.Interfaces.Repositories;
using ExchangeRate.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExchangeRate.Infrastructure.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly IRepositoryAsync<Bank> _repository;

        public BankRepository(IRepositoryAsync<Bank> repository)
        {
            _repository = repository;
        }

        public IQueryable<Bank> Banks => _repository.Entities;
        
        public async Task<List<BanksDTO>> GetBanksAsync()
        {
            Expression<Func<Bank, BanksDTO>> expression = e => new BanksDTO
            {
                BankCode = e.BankCode,
                BankName = e.BankName,
                Currencies = e.BankCurrencies.Where(x => x.Id == e.Id).Select(x => x.Currency.CurrencyName)
            };

            var collection = Banks.Select(expression).ToListAsync();
            return await collection;
        }
    }
}
