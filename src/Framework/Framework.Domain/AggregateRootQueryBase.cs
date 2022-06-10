using System;

namespace HumanResource.Framework.Domain
{
    public abstract class AggregateRootQueryBase<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreateOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ActionTime { get; set; }
        public long? ActionUserId { get; set; }
        public string ActionUserName { get; set; }
        public bool IsActive { get; set; }
        public byte[] RowVersion { get; set; }
    }
}