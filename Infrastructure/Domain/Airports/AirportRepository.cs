using Application.Commands.Airports;
using Domain.Airports;
using Infrastructure.Database;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Domain.Airports
{
    public class AirportRepository : IAirportRepository
    {
        private readonly DataContext _dataContext;

        public AirportRepository(DataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task AddAsync(Airport airport, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return;

            await _dataContext.Airports.AddAsync(airport, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}