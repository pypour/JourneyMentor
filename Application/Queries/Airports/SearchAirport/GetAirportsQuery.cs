using Application.Commands.Dto;
using SampleProject.Application.Configuration.Queries;
using System.Collections.Generic;

namespace Application.Queries.Airports.SearchAirport
{
    public class GetAirportsQuery : IQuery<List<AirportDto>>
    {
        public string searchKey { get; }
        public int limit { get; }
        public int offset { get; }

        public GetAirportsQuery(string searchKey, int limit, int offset)
        {
            this.searchKey = searchKey;
            this.limit = limit;
            this.offset = offset;
        }
    }
}