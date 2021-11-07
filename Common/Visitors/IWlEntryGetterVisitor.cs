using Common.Entry;
using System.Collections.Generic;

namespace Common.Visitors
{
    public interface IWlEntryGetterVisitor
    {
        public IEnumerable<WlEntry> Visit(WlEntry entry);


        public IEnumerable<WlEntry> Visit(WlDirectory directory);
    }
}
