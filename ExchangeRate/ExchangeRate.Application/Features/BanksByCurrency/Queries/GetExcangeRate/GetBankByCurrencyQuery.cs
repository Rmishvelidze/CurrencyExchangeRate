using AspNetCoreHero.Results;
using ExchangeRate.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeRate.Application.Features.BanksByCurrency.Queries.GetExcangeRate
{
    public class GetBankByCurrencyQuery : IRequest<Result<List<GetBankByCurrencyResponce>>>
    {
        public string FristCurrency { get; set; }
        public string SecondCurrency { get; set; }
        public IEnumerable<string> Banks { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public class GetBankByCurrencyQueryHandler : IRequestHandler<GetBankByCurrencyQuery, Result<List<GetBankByCurrencyResponce>>>
        {
            private readonly IBankByCurrencyRepository _bankByCurrency;

            public GetBankByCurrencyQueryHandler(IBankByCurrencyRepository bankByCurrency)
            {
                _bankByCurrency = bankByCurrency;
            }

            public async Task<Result<List<GetBankByCurrencyResponce>>> Handle(GetBankByCurrencyQuery query, CancellationToken cancellationToken)
            {
                var bankByCurrency = await _bankByCurrency.ReadAsync(x => x.Date >= query.StartDate
               && x.Date <= query.EndDate
               && query.Banks.Contains(x.Bank.BankName)
               && x.BuyCurrency.CurrencyName == query.FristCurrency
               && x.SellCurrency.CurrencyName == query.SecondCurrency);

                var bankByCurrencyResponce = bankByCurrency.Select(x => new GetBankByCurrencyResponce()
                {
                    Date = x.Date,
                    BankCode = x.Bank?.BankCode,
                    BuyRate = x.BuyRate,
                    SellRate = x.SellRate
                }).ToList();
                return await Result<List<GetBankByCurrencyResponce>>.SuccessAsync(bankByCurrencyResponce);
            }
        }
    }
}
