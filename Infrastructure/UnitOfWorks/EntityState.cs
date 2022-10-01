using System;

namespace WordLearning.Infrastructure.UnitOfWorks
{
    [Flags]
    public enum EntityState
    {
        Added,
        Deleted,
        Detached,
        Modified,
        Unchanged,
    }
}