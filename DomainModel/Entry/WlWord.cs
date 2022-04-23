using Common.Entry;
using System.Xml;
using System.Xml.Linq;

namespace WordLearning.Entry
{
    public class WlWord : WlEntry
    {
        public string Word { get => GetElementValue(); internal set => SetElementValue(value); }

        public string WordMeaning { get => GetElementValue(); internal set => SetElementValue(value); }

        public string Memo { get => GetElementValue(); internal set => SetElementValue(value); }


        public WlWord(XElement element) : base(element)
        {
        }


        public WlWord(string word, string wordMeaning, string memo)
            : this(new XElement(nameof(WlWord),
                new XAttribute(nameof(Word), XmlConvert.EncodeName(word)),
                new XAttribute(nameof(WordMeaning), XmlConvert.EncodeName(wordMeaning)),
                new XAttribute(nameof(Memo), XmlConvert.EncodeName(memo))))
        {
        }
    }
}
