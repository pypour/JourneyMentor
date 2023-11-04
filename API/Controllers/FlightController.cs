using Application.Commands.Dto;
using Application.Queries.Flights.SearchFlight;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/flight")]
    [ApiController]
    public class FlightController : Controller
    {
        private readonly IMediator _mediator;

        public FlightController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(List<FlightDto>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Search([FromQuery] SearchFlightDto searchDto, int limit, int offset)
        {
            var orders = await _mediator.Send(new GetFlightsQuery(searchDto));

            return Ok(orders);
        }
    }
}
