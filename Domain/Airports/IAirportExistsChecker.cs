namespace Domain.Airports
{
    public interface IAirportExistsChecker
    {
        bool IsExists(string iataCode);
    }
}