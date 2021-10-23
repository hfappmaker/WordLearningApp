using System;
using System.Collections.Generic;
using Common.Entry;

namespace Common.Visitors
{
    public interface IWlEntryGetterVisitor
    {
        public IEnumerable<WlEntry> Visit(WlEntry entry);


        public IEnumerable<WlEntry> Visit(WlDirectory directory);
    }
}
