using Domain.Airports;
using Infrastructure.Database;
using System.Linq;

namespace Infrastructure.Domain.Airports
{
    public class AirportExistsChecker : IAirportExistsChecker
    {
        private readonly DataContext _dataContext;

        public AirportExistsChecker(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool IsExists(string iataCode)
        {
            return _dataContext.Airports.Any(x => x.IATACode == iataCode);
        }
    }
}