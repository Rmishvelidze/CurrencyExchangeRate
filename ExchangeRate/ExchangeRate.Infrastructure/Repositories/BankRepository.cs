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
    public class BankRepository : RepositoryAsync<Bank>, IBankRepository
    {

        public BankRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Bank> Banks => Entities.Include(x => x.BankCurrencies).ThenInclude(x => x.Currency);

        public override async Task<List<Bank>> GetAllAsync()
        {
            return await Banks.ToListAsync();
        }

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
