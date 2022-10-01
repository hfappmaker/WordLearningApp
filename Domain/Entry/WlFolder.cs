using System.Collections.Generic;
using System.Linq;
using WordLearning.Domain.Entry.EntryCore;

namespace WordLearning.Domain.Entry
{
    public class WlFolder : WlDirectory, IEnumerable<WlDirectory>
    {
        public WlFolder(string fileName) : base(Enumerable.Empty<WlEntry>())
        {
            Name = fileName;
        }

        public WlFolder() : this(string.Empty) { }


        IEnumerator<WlDirectory> IEnumerable<WlDirectory>.GetEnumerator()
        {
            return (IEnumerator<WlDirectory>)GetEnumerator();
        }
    }
}
