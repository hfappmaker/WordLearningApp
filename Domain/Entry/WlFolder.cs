using System.Collections.Generic;
using System.Linq;
using WordLearning.Domain.Entry.EntryCore;

namespace WordLearning.Domain.Entry
{
    public class WlFolder : WlDirectory, IEnumerable<WlDirectory>
    {
        public WlFolder(string name) : base(name, Enumerable.Empty<WlEntry>()) { }


        IEnumerator<WlDirectory> IEnumerable<WlDirectory>.GetEnumerator()
        {
            return (IEnumerator<WlDirectory>)GetEnumerator();
        }
    }
}
