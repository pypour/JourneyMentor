using Application.Commands.Airports;
using Domain.Airports;
using Domain.Flights;
using Infrastructure.Database;
using Infrastructure.Domain.Airports;
using Infrastructure.Domain.Flights;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Infrastructure
{
    public static class RegistrationExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:DBConnectionString"];

            services.AddDbContext<DataContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
            );

            services.AddScoped<IAirportRepository, AirportRepository>();
            services.AddScoped<IAirportExistsChecker, AirportExistsChecker>();

            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<IFlightExistsChecker, FlightExistsChecker>();
        }
    }
}
