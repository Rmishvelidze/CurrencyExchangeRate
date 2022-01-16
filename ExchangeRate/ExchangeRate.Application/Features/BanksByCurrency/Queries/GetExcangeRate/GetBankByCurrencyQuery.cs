using AspNetCoreHero.Results;
using AutoMapper;
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
                var bankByCurrency = await _bankByCurrency.GetBankByCurrenciesAsync
                    (query.FristCurrency, query.SecondCurrency, query.Banks, query.StartDate, query.EndDate);

                var bankByCurrencyResponce = bankByCurrency.Select(x => new GetBankByCurrencyResponce()
                {
                    Date = x.Date,
                    BankCode = x.BankCode,  
                    BuyRate = x.BuyRate,
                    SellRate = x.SellRate
                }).ToList();
                return Result<List<GetBankByCurrencyResponce>>.Success(bankByCurrencyResponce);

                //var bankByCurrency = await _bankByCurrency.GetBankByCurrenciesAsync
                //    (query.FristCurrency,query.SecondCurrency, query.Banks, query.StartDate, query.EndDate);
                //var mappedBankByCurrency = _mapper.Map< GetBankByCurrencyResponce>(bankByCurrency);
                //return Result<GetBankByCurrencyResponce>.Success(mappedBankByCurrency);
            }
        }
    }
}
