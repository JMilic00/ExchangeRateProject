using ExchangeRate.Domain.Dtos.ExchangeRateDto;
using ExchangeRate.Domain.Features.ExchngeRates.Requests.Commands;
using ExchangeRate.Domain.Features.ExchngeRates.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRate.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRateController : ControllerBase
    {
        public readonly IMediator _mediator;

        public ExchangeRateController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<ExchangeRateController>
        [HttpGet]
        public async Task<ActionResult<List<ExchangeRateDto>>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetExchangeRateRequest());
            return Ok(leaveTypes);
        }
        /*
        [HttpGet("ByDate")]
        public async Task<ActionResult<List<ExchangeRateDto>>> GetByDate([FromQuery] DateTime StartDate, [FromQuery] DateTime EndDate)
        {
            var query = new GetExchangeRateRequestDate { StartDate = StartDate, EndDate = EndDate };
            var exchangeRates = await _mediator.Send(query);
            return Ok(exchangeRates);
        }
        */
        // POST api/<ExchangeRateController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateExchangeRateDto exchangeRate)
        {
            var command = new CreateExchangeRateCommand { ExchangeRateDto = exchangeRate };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
