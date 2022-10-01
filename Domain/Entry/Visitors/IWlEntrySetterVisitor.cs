using WordLearning.Domain.Entry.EntryCore;

namespace WordLearning.Domain.Entry.Visitors
{
    public interface IWlEntrySetterVisitor
    {
        public void Visit(WlEntry entry);


        public void Visit(WlDirectory directory);
    }
}
