using WordLearning.Domain.Entry.EntryCore;
using System.Collections.Generic;

namespace WordLearning.Domain.Entry.Visitors
{
    public class GetHierarchicalEntryVisitor : IWlEntryGetterVisitor
    {
        private readonly HashSet<WlEntry> _exceptedEntries;

        public GetHierarchicalEntryVisitor(IEnumerable<WlEntry> exceptedEntries)
        {
            _exceptedEntries = new HashSet<WlEntry>(exceptedEntries);
        }

        public IEnumerable<WlEntry> Visit(WlDirectory directory)
        {
            if (!_exceptedEntries.Contains(directory))
            {
                yield return directory;
                if (directory.IsExpanded)
                {
                    foreach (WlEntry entry in directory)
                    {
                        foreach (WlEntry item in entry.Accept(this))
                        {
                            yield return item;
                        }
                    }
                }
            }
        }


        public IEnumerable<WlEntry> Visit(WlEntry entry)
        {
            if (!_exceptedEntries.Contains(entry))
            {
                yield return entry;
            }
        }
    }
}
