using System.Threading;
using System.Threading.Tasks;

namespace HumanResource.Framework.Core
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync(CancellationToken cancellationToken);
        Task CommitAsync(CancellationToken cancellationToken);
        Task RollBackAsync(CancellationToken cancellationToken);
    }
}