using WordLearning.Domain.Aggregate;

namespace WordLearning.Infrastructure.Stores
{
    internal interface IAggregateRootStore<T> where T : IAggregateRoot
    {
        public int Insert(T root);

        public void Update(int id, T root);

        public void Delete(int id);

    }
}