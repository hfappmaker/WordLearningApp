using WordLearning.Domain.Entry.EntryCore;
using System.Linq;

namespace WordLearning.Domain.Entry.Visitors
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
                foreach (WlEntry entry in directory.ToList())
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
