using AspNetCoreHero.Results;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetAllBanksQueryHandler(IBankRepository bankRepository, IMapper mapper)
        {
            _bank = bankRepository;
            _mapper = mapper;
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
            return Result<List<GetAllBanksResponce>>.Success(banksResponces);
        }
    }
}
