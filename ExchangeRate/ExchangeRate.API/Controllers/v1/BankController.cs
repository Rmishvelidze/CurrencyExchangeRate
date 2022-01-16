using ExchangeRate.Application.Features.Banks.Queries.GetAll;
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

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var bank = await _mediator.Send(new GetBankByIdQuery() { Id = id });
        //    return Ok(bank);
        //}

        //// POST api/<controller>
        //[HttpPost]
        //public async Task<IActionResult> Post(CreateBrandCommand command)
        //{
        //    return Ok(await _mediator.Send(command));
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, UpdateBrandCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(await _mediator.Send(command));
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return Ok(await _mediator.Send(new DeleteBrandCommand { Id = id }));
        //}
    }
}
