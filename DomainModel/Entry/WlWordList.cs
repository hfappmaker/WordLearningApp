using Common.Entry;
using Common.Utility;
using System;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;

namespace WordLearning.Entry
{
    public class WlWordList : WlDirectory
    {
        public WlWordList(XElement element) : base(element)
        {
        }


        public WlWordList(string fileName)
            : base(new XElement(nameof(WlWordList), new XAttribute(nameof(Name), XmlConvert.EncodeName(fileName))))
        {
        }


        public WlWordList() : this(string.Empty) { }


        //public WlLanguage VoiceLanguageWord { get; set; }


        //public WlLanguage VoiceLanguageMeaning { get; set; }


        public int? SleepCount { get; set; }


        protected override WlEntry CreateChildEntry(XElement childElement)
            => CommonUtility.CreateInstance<WlWord>(
               Assembly.GetExecutingAssembly(), childElement.Name.ToString(), childElement);
    }
}
