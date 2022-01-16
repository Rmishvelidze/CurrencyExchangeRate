using ExchangeRate.Application.Features.BanksByCurrency.Queries.GetById;
using ExchangeRate.Application.Features.BanksByCurrency.Queries.GetExcangeRate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRate.API.Controllers.V1
{
    public class BankByCurrencyController : BaseApiController<BankByCurrencyController>
    {


        [HttpGet("{firstCurrency}/{secondCurrency}/{startDate}/{endDate}")]
        public async Task<IActionResult> GetExchangeRate
            (string firstCurrency, string secondCurrency, [FromQuery]IEnumerable<string> banks, DateTime startDate, DateTime endDate)
        {
            var exchangeRates = await _mediator.Send(new GetBankByCurrencyQuery()
            {
                FristCurrency = firstCurrency,
                SecondCurrency = secondCurrency,
                Banks = banks,
                StartDate = startDate,
                EndDate = endDate
            });
            return Ok(exchangeRates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var exchangeRate = await _mediator.Send(new GetBankByCurrencyByIdQuery() { Id = id });
            return Ok(exchangeRate);
        }

    }
}
