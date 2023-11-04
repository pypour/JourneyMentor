using Domain.Airports;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Airports
{
    public interface IAirportRepository
    {
        Task AddAsync(Airport airport, CancellationToken cancellationToken);
    }
}