using WordLearning.Domain.Entry.EntryCore;
using System.Collections.Generic;
using System.Linq;

namespace WordLearning.Domain.Entry.Visitors
{
    public class GetAllFolderVisitor : IWlEntryGetterVisitor
    {
        public IEnumerable<WlEntry> Visit(WlDirectory directory)
        {
            if (directory is WlFolder)
            {
                yield return directory;
            }
            else
            {
                yield break;
            }

            foreach (WlEntry entry in directory)
            {
                foreach (WlEntry item in entry.Accept(this))
                {
                    yield return item;
                }
            }
        }


        public IEnumerable<WlEntry> Visit(WlEntry entry)
        {
            return Enumerable.Empty<WlEntry>();
        }
    }
}
