using WordLearning.Domain.Entry.EntryCore;

namespace WordLearning.Domain.Entry
{
    public class WlWord : WlEntry
    {
        public string Word { get => GetValue<string>(); internal set => SetValue(value); }

        public string WordMeaning { get => GetValue<string>(); internal set => SetValue(value); }

        public string Memo { get => GetValue<string>(); internal set => SetValue(value); }

        public WlWord(string word, string wordMeaning, string memo)
        {
            Word = word;
            WordMeaning = wordMeaning;
            Memo = memo;
        }
    }
}
