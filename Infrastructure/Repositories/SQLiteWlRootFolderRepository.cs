using System;
using WordLearning.Infrastructure.UnitOfWorks;
using WordLearning.Domain.Entry;
using WordLearning.Domain.Repositories;

namespace WordLearning.Infrastructure.Repositories
{
    public class SQLiteWlRootFolderRepository : SQLiteRepositoryBase<WlRootFolder>, IWlRootFolderRepository
    {
    }
}