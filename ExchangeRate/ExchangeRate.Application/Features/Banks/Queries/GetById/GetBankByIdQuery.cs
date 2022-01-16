using AspNetCoreHero.Results;
using AutoMapper;
using ExchangeRate.Application.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeRate.Application.Features.Banks.Queries.GetById
{
    public class GetBankByIdQuery : IRequest<Result<GetBankByIdResponce>>
    {
        public int Id { get; set; }

        public class GetBankByIdQueryHandler : IRequestHandler<GetBankByIdQuery, Result<GetBankByIdResponce>>
        {
            private readonly IBankRepository _bankRepository;
            private readonly IMapper _mapper;

            public GetBankByIdQueryHandler(IBankRepository bankRepository, IMapper mapper)
            {
                _bankRepository = bankRepository;
                _mapper = mapper;
            }
            public async Task<Result<GetBankByIdResponce>> Handle(GetBankByIdQuery request, CancellationToken cancellationToken)
            {
                var bank = await _bankRepository.GetByIdAsync(request.Id);
                var пetBankByIdResponce = new GetBankByIdResponce()
                {
                    Id = bank.Id,
                    BankCode = bank.BankCode,
                    BankName = bank.BankName
                };
                return Result<GetBankByIdResponce>.Success(пetBankByIdResponce);
            }
        }
    }
}
