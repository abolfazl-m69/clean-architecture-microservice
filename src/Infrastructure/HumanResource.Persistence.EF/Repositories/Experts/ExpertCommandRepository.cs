using System.Threading;
using System.Threading.Tasks;
using HumanResource.Domain.Experts;
using HumanResource.Framework.Core;
using HumanResource.Framework.Core.Events;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Persistence.EF.Repositories.Experts;

public class ExpertCommandRepository : IExpertCommandRepository
{
    private readonly ExpertDbContext _expertDbContext;
    private readonly IEventPublisher _eventPublisher;

    public ExpertCommandRepository(ExpertDbContext expertDbContext, IEventPublisher eventPublisher)
    {
        _expertDbContext = expertDbContext;
        _eventPublisher = eventPublisher;
    }

    public async Task<Expert> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var expert = await _expertDbContext.Experts.FirstOrDefaultAsync(cancellationToken);
        expert?.SetPublisher(_eventPublisher);
        return expert;
    }

    public async Task CreateAsync(Expert expert, CancellationToken cancellationToken)
    {
        await _expertDbContext.Experts.AddAsync(expert, cancellationToken);
    }

    public async Task<long> GetNextIdAsync()
    {
        return await _expertDbContext.GetNextSequenceAsync("ExpertSeq");
    }
}