using Common.Entry;
using System;
using System.Xml;
using System.Xml.Linq;
using WordLearning.Language;
using WordLearning.Utility;

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


        public WlLanguage VoiceLanguageWord { get; set; }


        public WlLanguage VoiceLanguageMeaning { get; set; }


        public int? SleepCount { get; set; }


        protected override WlEntry CreateChildEntry(XElement childElement)
        {
            Type type = WlUtility.CurrentAssembly.GetType(childElement.Name.ToString());
            if (type != typeof(WlWord))
            {
                throw new InvalidOperationException();
            }

            return Activator.CreateInstance(type, childElement, this) as WlEntry;
        }
    }
}
