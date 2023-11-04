using Application.Commands.Dto;

namespace Application.Commands.Flights
{
    public class RegisterFlightCommand : ICommand
    {
        public FlightDto Flight { get; }

        public RegisterFlightCommand(FlightDto flight)
        {
            Flight = flight;
        }
    }
}