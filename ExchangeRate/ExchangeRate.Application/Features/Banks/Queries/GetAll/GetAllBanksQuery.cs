using AspNetCoreHero.Results;
using ExchangeRate.Application.Interfaces.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeRate.Application.Features.Banks.Queries.GetAll
{
    public class GetAllBanksQuery : IRequest<Result<List<GetAllBanksResponce>>>
    {
        public GetAllBanksQuery()
        {

        }
    }

    public class GetAllBanksQueryHandler : IRequestHandler<GetAllBanksQuery, Result<List<GetAllBanksResponce>>>
    {
        private readonly IBankRepository _bank;

        public GetAllBanksQueryHandler(IBankRepository bankRepository)
        {
            _bank = bankRepository;
        }
        public async Task<Result<List<GetAllBanksResponce>>> Handle(GetAllBanksQuery request, CancellationToken cancellationToken)
        {

            var bankList = await _bank.GetAllAsync();
            var banksResponces = bankList.Select(x => new GetAllBanksResponce()
            {

                BankCode = x.BankCode,
                BankName = x.BankName,
                Currencies = x.BankCurrencies.Select(x => x.Currency.CurrencyName).ToList()
            }).ToList();
            return await Result<List<GetAllBanksResponce>>.SuccessAsync(banksResponces);
        }
    }
}
