using Domain.Flights;
using Infrastructure.Database;
using System;
using System.Linq;

namespace Infrastructure.Domain.Flights
{
    public class FlightExistsChecker : IFlightExistsChecker
    {
        private readonly DataContext _dataContext;

        public FlightExistsChecker(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool IsExists(DateOnly flightDate, string flightIATACode)
        {
            return _dataContext.Flights.Any(x => x.FlightDate == flightDate && x.FlightInfo.Iata == flightIATACode);
        }
    }
}