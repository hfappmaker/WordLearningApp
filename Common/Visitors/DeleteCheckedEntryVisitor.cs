using System;
using System.Linq;
using Common.Entry;

namespace Common.Visitors
{
    public class DeleteCheckedEntryVisitor : IWlEntrySetterVisitor
    {
        public void Visit(WlDirectory directory)
        {
            if (directory.IsChecked)
            {
                directory.Delete();
            }
            else
            {
                foreach (WlEntry entry in directory.EntryIterator.ToList())
                {
                    entry.Accept(this);
                }
            }
        }

        public void Visit(WlEntry entry)
        {
            if (entry.IsChecked)
            {
                entry.Delete();
            }
        }
    }
}
