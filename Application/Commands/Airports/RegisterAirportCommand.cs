using Application.Commands.Dto;

namespace Application.Commands.Airports
{
    public class RegisterAirportCommand : ICommand
    {
        public AirportDto Airport { get; }

        public RegisterAirportCommand(AirportDto airport)
        {
            Airport = airport;
        }
    }
}