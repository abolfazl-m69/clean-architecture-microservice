using System.Threading;
using System.Threading.Tasks;
using HumanResource.Framework.Domain;

namespace HumanResource.Domain.Experts;

public interface IExpertCommandRepository : IRepository
{
    Task<Expert> GetByIdAsync(long id, CancellationToken cancellationToken);
    Task CreateAsync(Expert product, CancellationToken cancellationToken);
    Task<long> GetNextIdAsync();
}