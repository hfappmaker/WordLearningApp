using WordLearning.Domain.Entry.EntryCore;
using System.Collections.Generic;
using System.Linq;

namespace WordLearning.Domain.Entry
{
    public class WlWordList : WlDirectory, IEnumerable<WlWord>
    {
        public WlWordList(string fileName)
            : base(Enumerable.Empty<WlEntry>())
        {
            Name = fileName;
        }

        public WlWordList() : this(string.Empty) { }

        //public WlLanguage VoiceLanguageWord { get; set; }

        //public WlLanguage VoiceLanguageMeaning { get; set; }

        public int? SleepCount { get; set; }

        IEnumerator<WlWord> IEnumerable<WlWord>.GetEnumerator()
        {
            return (IEnumerator<WlWord>)GetEnumerator();
        }
    }
}
