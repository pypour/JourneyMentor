using Application.Commands;
using Application.Commands.Airports;
using Application.Commands.Dto;
using Application.Configs;
using MediatR;
using Microsoft.Extensions.Options;
using SampleProject.Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Airports.SearchAirport
{
    public sealed class GetAirportsQueryHandler : IQueryHandler<GetAirportsQuery, List<AirportDto>>
    {
        private readonly HttpClientHelper _httpClientHelper;
        private readonly AviationStackOption _aviationStackOption;
        private readonly IMediator _mediator;

        public GetAirportsQueryHandler(HttpClientHelper httpClientHelper,
            IMediator mediator,
            IOptions<AviationStackOption> aviationStackOption)
        {
            _httpClientHelper = httpClientHelper;
            _aviationStackOption = aviationStackOption.Value;
            _aviationStackOption.BaseUrl = _aviationStackOption.BaseUrl.TrimEnd('/');
            _mediator = mediator;
        }

        public async Task<List<AirportDto>> Handle(GetAirportsQuery request, CancellationToken cancellationToken)
        {
            var result = await _httpClientHelper.CallApi<ExternalApiResult<AirportDto>>(HttpMethod.Get, url: $"{_aviationStackOption.BaseUrl}/airports", new
            {
                access_key = _aviationStackOption.AccessKey,
                search = request.searchKey,
                limit = request.limit,
                offset = request.offset
            }, requestType: HttpRequestTypeEnum.QueryString, cancellationToken: cancellationToken);

            foreach (var airport in result.Data)
            {
                try
                {
                    await _mediator.Send(new RegisterAirportCommand(airport), cancellationToken);
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