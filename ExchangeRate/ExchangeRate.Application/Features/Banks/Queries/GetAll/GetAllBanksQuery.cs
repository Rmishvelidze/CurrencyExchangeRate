using AspNetCoreHero.Results;
using AutoMapper;
using ExchangeRate.Application.Interfaces.Repositories;
using MediatR;
using System.Collections.Generic;
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

        public GetAllBanksQueryHandler(IBankRepository bank, IMapper mapper)
        {
            _bank = bank;
            _mapper = mapper;
        }
        public async Task<Result<List<GetAllBanksResponce>>> Handle(GetAllBanksQuery request, CancellationToken cancellationToken)
        {
            var bankList = await _bank.GetBanksAsync();
            var mappedBanks = _mapper.Map<List<GetAllBanksResponce>>(bankList);
            return Result<List<GetAllBanksResponce>>.Success(mappedBanks);
        }
    }
}
