using Domain.Airports;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Airports
{
    public class RegisterAirportCommandHandler : ICommandHandler<RegisterAirportCommand>
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IAirportExistsChecker _airportExistsChecker;

        public RegisterAirportCommandHandler(
            IAirportRepository airportRepository, 
            IAirportExistsChecker airportExistsChecker)
        {
            _airportRepository = airportRepository;
            _airportExistsChecker = airportExistsChecker;
        }

        public async Task Handle(RegisterAirportCommand request, CancellationToken cancellationToken)
        {
            if (_airportExistsChecker.IsExists(request.Airport.IATACode))
                return;

            var airport = request.Airport.ToModel();
            await _airportRepository.AddAsync(airport, cancellationToken);
        }
    }
}