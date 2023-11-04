using Application.Commands.Airports;
using Domain.Flights;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Domain.Flights
{
    public class FlightRepository : IFlightRepository
    {
        private readonly DataContext _dataContext;

        public FlightRepository(DataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task<Flight> GetFlightAsync(DateOnly flightDate, string flightInfoIataCode, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return null;

            return await _dataContext.Flights.FirstOrDefaultAsync(x => x.FlightDate == flightDate && 
                    x.FlightInfo.Iata == flightInfoIataCode, cancellationToken);
        }

        public async Task AddAsync(Flight flight, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return;

            await _dataContext.Flights.AddAsync(flight, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Flight flight, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return;

            await _dataContext.Flights.AddAsync(flight, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}