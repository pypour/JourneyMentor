using Domain.Flights;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Airports
{
    public interface IFlightRepository
    {
        Task<Flight> GetFlightAsync(DateOnly flightDate, string flightInfoIataCode, CancellationToken cancellationToken);
        Task AddAsync(Flight flight, CancellationToken cancellationToken);
        Task UpdateAsync(Flight newFlight, CancellationToken cancellationToken);
    }
}