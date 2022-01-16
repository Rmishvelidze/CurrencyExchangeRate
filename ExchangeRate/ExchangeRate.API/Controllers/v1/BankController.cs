using ExchangeRate.Application.Features.Banks.Queries.GetAll;
using ExchangeRate.Application.Features.Banks.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExchangeRate.API.Controllers.V1
{
    public class BankController : BaseApiController<BankController>
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var banks = await _mediator.Send(new GetAllBanksQuery());
            return Ok(banks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var bank = await _mediator.Send(new GetBankByIdQuery() { Id = id });
            return Ok(bank);
        }
    }
}
