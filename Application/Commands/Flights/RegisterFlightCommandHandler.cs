using Application.Commands.Airports;
using Domain.Flights;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Flights
{
    public class RegisterFlightCommandHandler : ICommandHandler<RegisterFlightCommand>
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IFlightExistsChecker _flightExistsChecker;

        public RegisterFlightCommandHandler(
            IFlightRepository flightRepository, 
            IFlightExistsChecker flightExistsChecker)
        {
            _flightRepository = flightRepository;
            _flightExistsChecker = flightExistsChecker;
        }

        public async Task Handle(RegisterFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = await _flightRepository.GetFlightAsync(request.Flight.FlightDate, request.Flight.FlightInfo.Iata, cancellationToken);

            if (cancellationToken.IsCancellationRequested)
                return;

            var newFlight = request.Flight.ToModel();
            if (flight == null)
            {
                await _flightRepository.AddAsync(newFlight, cancellationToken);
            }
            else
            {
                newFlight.Id = flight.Id;
                await _flightRepository.UpdateAsync(newFlight, cancellationToken);
            }
        }
    }
}