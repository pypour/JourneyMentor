using Application.Commands.Airports;
using Application.Commands.Dto;
using Application.Commands.Flights;
using Application.Queries.Airports.SearchAirport;
using Application.Queries.Flights.SearchFlight;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Application
{
    public static class RegistrationExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegistrationExtensions).Assembly));

            services.AddScoped<IRequestHandler<GetAirportsQuery, List<AirportDto>>, GetAirportsQueryHandler>();
            services.AddScoped<IRequestHandler<RegisterAirportCommand>, RegisterAirportCommandHandler>();

            services.AddScoped<IRequestHandler<GetFlightsQuery, List<FlightDto>>, GetFlightsQueryHandler>();
            services.AddScoped<IRequestHandler<RegisterFlightCommand>, RegisterFlightCommandHandler>();
        }
    }
}
