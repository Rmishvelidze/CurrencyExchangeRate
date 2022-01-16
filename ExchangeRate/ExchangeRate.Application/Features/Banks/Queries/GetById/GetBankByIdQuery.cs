using AspNetCoreHero.Results;
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

            public GetBankByIdQueryHandler(IBankRepository bankRepository)
            {
                _bankRepository = bankRepository;
            }
            public async Task<Result<GetBankByIdResponce>> Handle(GetBankByIdQuery request, CancellationToken cancellationToken)
            {
                var bank = await _bankRepository.GetByIdAsync(request.Id);
                var getBankByIdResponce = new GetBankByIdResponce()
                {
                    Id = bank.Id,
                    BankCode = bank.BankCode,
                    BankName = bank.BankName
                };
                return await Result<GetBankByIdResponce>.SuccessAsync(getBankByIdResponce);
            }
        }
    }
}
