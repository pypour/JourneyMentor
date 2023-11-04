using Application.Commands.Dto;
using Application.Queries.Airports.SearchAirport;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/airport")]
    [ApiController]
    public class AirportController : Controller
    {
        private readonly IMediator _mediator;

        public AirportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(List<AirportDto>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Search([FromQuery] string searchKey, int limit, int offset)
        {
            var orders = await _mediator.Send(new GetAirportsQuery(searchKey, limit, offset));

            return Ok(orders);
        }
    }
}
