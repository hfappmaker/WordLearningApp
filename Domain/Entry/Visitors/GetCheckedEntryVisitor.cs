﻿using WordLearning.Domain.Entry.EntryCore;
using System.Collections.Generic;

namespace WordLearning.Domain.Entry.Visitors
{
    public class GetCheckedEntryVisitor : IWlEntryGetterVisitor
    {
        public IEnumerable<WlEntry> Visit(WlDirectory directory)
        {
            if (directory.IsChecked)
            {
                yield return directory;
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
            if (entry.IsChecked)
            {
                yield return entry;
            }
        }
    }
}
