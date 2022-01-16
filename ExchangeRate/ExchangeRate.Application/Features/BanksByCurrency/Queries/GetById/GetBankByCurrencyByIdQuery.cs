using AspNetCoreHero.Results;
using ExchangeRate.Application.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeRate.Application.Features.BanksByCurrency.Queries.GetById
{
    public class GetBankByCurrencyByIdQuery : IRequest<Result<GetBankByCurrencyByIdResponce>>
    {
        public int Id { get; set; }

        public class GetBankByCurrencyByIdQueryHandler : IRequestHandler<GetBankByCurrencyByIdQuery, Result<GetBankByCurrencyByIdResponce>>
        {
            private readonly IBankByCurrencyRepository _bankByCurrencyRepository;
            public GetBankByCurrencyByIdQueryHandler(IBankByCurrencyRepository bankByCurrencyRepository)
            {
                _bankByCurrencyRepository = bankByCurrencyRepository;
            }
            public async Task<Result<GetBankByCurrencyByIdResponce>> Handle(GetBankByCurrencyByIdQuery request, CancellationToken cancellationToken)
            {
                var bankByCurrency = await _bankByCurrencyRepository.GetByIdAsync(request.Id);
                var getBankByCurrencyByIdResponce = new GetBankByCurrencyByIdResponce()
                {
                    BankCode = bankByCurrency.Bank.BankCode,
                    BuyRate = bankByCurrency.BuyRate,
                    SellRate = bankByCurrency.SellRate,
                    Date = bankByCurrency.Date
                };

                return await Result<GetBankByCurrencyByIdResponce>.SuccessAsync(getBankByCurrencyByIdResponce);
            }
        }
    }
}
