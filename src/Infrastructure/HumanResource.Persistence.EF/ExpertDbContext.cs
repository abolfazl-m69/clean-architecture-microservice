using System.Threading.Tasks;
using HumanResource.Domain.Experts;
using HumanResource.Framework.Core.Events.ConsumerRequestContext;
using HumanResource.Persistence.EF.DomainModelConfigs.Experts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HumanResource.Persistence.EF
{
    public class ExpertDbContext : DbContext
    {
        private IDbContextTransaction _dbContextTransaction;
        private readonly IRequestContext _requestContext;

        public IDbContextTransaction GetCurrentTransaction() => _dbContextTransaction;

        public ExpertDbContext(DbContextOptions<ExpertDbContext> options, IRequestContext requestContext) : base(options)
        {
            _requestContext = requestContext;
            SavingChanges += OnSavingChanges;
        }

        public DbSet<Expert> Experts { get; set; }
        

        #region for event source 

        private void OnSavingChanges(object sender, SavingChangesEventArgs e)
        {
            //AddToProcessedMessages();
            //AddToOutBoxItems();
        }
        /// <summary>
        /// for event source outbox pattern 
        /// </summary>
        /// <returns></returns>
        //private void AddToProcessedMessages()
        //{
        //    ConsumerProcessedMessages.Add(new ConsumerProcessedMessage(_requestContext.GetCommandId()));
        //    _requestContext.ClearContext();
        //}
        //private void AddToOutBoxItems()
        //{
        //    var aggregateRoots = ChangeTracker.Entries()
        //        .Where(a => a.State != EntityState.Unchanged)
        //        .Select(a => a.Entity)
        //        .OfType<IAggregateRoot>()
        //        .ToList();
        //    var itemsToAddIntoOutbox = OutboxItemFactory.CreateOutboxItemsFromAggregateRoots(aggregateRoots);
        //    itemsToAddIntoOutbox.ForEach(a => OutboxItems.Add(a));
        //}

        //public DbSet<ConsumerProcessedMessage> ConsumerProcessedMessages { get; set; }
        //private DbSet<OutboxItem> OutboxItems { get; set; }

        #endregion

        public async Task BeginTransactionAsync()
        {
            _dbContextTransaction ??= await Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_dbContextTransaction != null)
                await _dbContextTransaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            if (_dbContextTransaction != null)
                await _dbContextTransaction.RollbackAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasSequence("ExpertSeq");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExpertConfig).Assembly);

            modelBuilder.Entity<Expert>().HasQueryFilter(r => !r.IsDeleted);

        }
    }
}
