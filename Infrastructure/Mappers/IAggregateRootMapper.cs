using System.Threading.Tasks;
using WordLearning.Domain.Aggregate;

namespace WordLearning.Infrastructure.Mappers
{
    internal interface IAggregateRootMapper<T> where T : IAggregateRoot
    {
        public Task<T> GetById(int id);
    }
}