using ExchangeRate.Application.DTOs.Banks;
using ExchangeRate.Domain.Entities.Catalog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRate.Application.Interfaces.Repositories
{
    public interface IBankRepository : IRepositoryAsync<Bank>
    {
    }
}
