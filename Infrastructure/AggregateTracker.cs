using WordLearning.Domain.Aggregate;
using WordLearning.Infrastructure.UnitOfWorks;

namespace WordLearning.Infrastructure
{
    internal class AggregateTracker<T> where T : IAggregateRoot
    {
        public T Value { get; }

        public EntityState State { get; set; }


        public AggregateTracker(T value, EntityState state)
        {
            Value = value;
            State = state;
        }
    }
}