using System;
using System.Collections.Generic;
using System.Linq;
using Common.Entry;

namespace Common.Visitors
{
    public class GetCheckedEntryVisitor : IWlEntryGetterVisitor
    {
        public IEnumerable<WlEntry> Visit(WlDirectory directory)
        {
            if (directory.IsChecked) yield return directory;
            foreach (var entry in directory.EntryIterator)
            {
                foreach (var item in entry.Accept(this))
                {
                    yield return item;
                }
            }
        }


        public IEnumerable<WlEntry> Visit(WlEntry entry)
        {
            if (entry.IsChecked) yield return entry;
        }
    }
}
