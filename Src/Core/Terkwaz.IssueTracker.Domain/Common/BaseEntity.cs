namespace Terkwaz.IssueTracker.Domain.Common
{
    public class Entity : Entity<int> { }

    public class Entity<T>
    {
        public virtual T Id { get; set; }
    }
}