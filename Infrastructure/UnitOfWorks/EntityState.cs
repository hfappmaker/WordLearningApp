using System;

namespace WordLearning.Infrastructure.UnitOfWorks
{
    [Flags]
    internal enum EntityState
    {
        Added,
        Deleted,
        Detached,
        Modified,
        Unchanged,
    }
}