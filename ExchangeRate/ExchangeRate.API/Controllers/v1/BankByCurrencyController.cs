using ExchangeRate.Application.Features.BanksByCurrency.Queries.GetExcangeRate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRate.API.Controllers.V1
{
    public class BankByCurrencyController : BaseApiController<BankByCurrencyController>
    {
        //[HttpGet("{}")]
        //public async Task<IActionResult> GetExchangeRate
        //    (string firstCurrency, string secondCurrency, IEnumerable<string> banks, DateTime startDate, DateTime endDate)
        //{
        //    var exchangeRate = await _mediator.Send(new GetBankByCurrencyQuery() 
        //        {
        //            FristCurrency = firstCurrency,
        //            SecondCurrency = secondCurrency,
        //            Banks = banks,
        //            StartDate = startDate,
        //            EndDate = endDate
        //        });
        //    return Ok(exchangeRate);
        //}
        
    }
}
