using System;

namespace Domain.Flights
{
    public interface IFlightExistsChecker
    {
        bool IsExists(DateOnly flightDate, string flightIATACode);
    }
}