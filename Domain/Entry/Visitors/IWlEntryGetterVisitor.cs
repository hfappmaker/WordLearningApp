using WordLearning.Domain.Entry.EntryCore;
using System.Collections.Generic;

namespace WordLearning.Domain.Entry.Visitors
{
    public interface IWlEntryGetterVisitor
    {
        public IEnumerable<WlEntry> Visit(WlEntry entry);


        public IEnumerable<WlEntry> Visit(WlDirectory directory);
    }
}
