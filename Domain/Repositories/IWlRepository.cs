using WordLearning.Domain.Aggregate;

namespace WordLearning.Domain.Repositories
{
    public interface IWlRepository<T>
        where T : IAggregateRoot
    {
        T GetById(int id);

        void Delete(T aggregateRoot);

        void Update(T aggregateRoot);

        void Insert(T aggregateRoot);

        void Save();

        T Create();

        //IEnumerable<T> GetAll();

        //IEnumerable<T> FindAll();

        //IEnumerable<T> FindByName(string name);

        //IEnumerable<T> FindById(long id);

        //IEnumerable<T> FindByNameIgnoreCase(string name);
    }
}