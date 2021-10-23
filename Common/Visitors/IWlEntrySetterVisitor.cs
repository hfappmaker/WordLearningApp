using System;
using Common.Entry;

namespace Common.Visitors
{
    public interface IWlEntrySetterVisitor
    {
        public void Visit(WlEntry entry);


        public void Visit(WlDirectory directory);
    }
}
