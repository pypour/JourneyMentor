using Application.Commands.Dto;
using SampleProject.Application.Configuration.Queries;
using System.Collections.Generic;

namespace Application.Queries.Flights.SearchFlight
{
    public class GetFlightsQuery : IQuery<List<FlightDto>>
    {
        public SearchFlightDto SearchFlightDto { get; }

        public GetFlightsQuery(SearchFlightDto searchFlightDto)
        {
            this.SearchFlightDto = searchFlightDto;
        }
    }
}