namespace HumanResource.Framework.Domain
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; protected set; }

        protected BaseEntity() { }
        protected BaseEntity(TKey id)
        {
            this.Id = id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;

            var entity = obj as BaseEntity<TKey>;
            return Id.Equals(entity.Id);
        }
    }
}