using ExchangeRate.Application.DTOs.Banks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRate.Application.Interfaces.Repositories
{
    public interface IBankRepository
    {
        Task<List<BanksDTO>> GetBanksAsync();
    }
}
