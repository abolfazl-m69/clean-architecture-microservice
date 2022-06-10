using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HumanResource.Framework.Core
{
    public class EfUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _dbContext;
        private IDbContextTransaction _transaction;

        public EfUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken)
        {
            _transaction = await this._dbContext.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
            await _transaction.CommitAsync(cancellationToken);
        }

        public async Task RollBackAsync(CancellationToken cancellationToken)
        {
            await _transaction.RollbackAsync(cancellationToken);
        }

        public async void Dispose()
        {
            await _dbContext.DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }
}