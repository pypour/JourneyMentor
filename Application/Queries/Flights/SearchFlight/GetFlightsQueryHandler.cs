using Application.Commands.Dto;
using Application.Commands.Flights;
using Application.Configs;
using MediatR;
using Microsoft.Extensions.Options;
using SampleProject.Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Flights.SearchFlight
{
    public sealed class GetFlightsQueryHandler : IQueryHandler<GetFlightsQuery, List<FlightDto>>
    {
        private readonly HttpClientHelper _httpClientHelper;
        private readonly AviationStackOption _aviationStackOption;
        private readonly IMediator _mediator;

        public GetFlightsQueryHandler(HttpClientHelper httpClientHelper,
            IMediator mediator,
            IOptions<AviationStackOption> aviationStackOption)
        {
            _httpClientHelper = httpClientHelper;
            _aviationStackOption = aviationStackOption.Value;
            _aviationStackOption.BaseUrl = _aviationStackOption.BaseUrl.TrimEnd('/');
            _mediator = mediator;
        }

        public async Task<List<FlightDto>> Handle(GetFlightsQuery request, CancellationToken cancellationToken)
        {
            request.SearchFlightDto.access_key = _aviationStackOption.AccessKey;
            var result = await _httpClientHelper.CallApi<ExternalApiResult<FlightDto>>(HttpMethod.Get, 
                url: $"{_aviationStackOption.BaseUrl}/flights", request.SearchFlightDto, 
                requestType: HttpRequestTypeEnum.QueryString, 
                cancellationToken: cancellationToken);

            foreach (var airport in result.Data)
            {
                try
                {
                    await _mediator.Send(new RegisterFlightCommand(airport), cancellationToken);
                }
                catch(Exception ex)
                {
                    //Log exception
                }
            }

            return result.Data;
        }
    }
}