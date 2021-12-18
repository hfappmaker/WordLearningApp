using Common.Entry;
using Common.Utility;
using System;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using WordLearning.Utility;

namespace WordLearning.Entry
{
    public class WlFolder : WlDirectory
    {


        public WlFolder(string fileName) : base(new XElement(nameof(WlFolder), new XAttribute(nameof(Name), XmlConvert.EncodeName(fileName))))
        {
        }


        public WlFolder() : this(string.Empty) { }



        public WlFolder(XElement element) : base(element)
        {

        }


        protected override WlEntry CreateChildEntry(XElement childElement)
            => CommonUtility.CreateInstance<WlDirectory>(WlUtility.CurrentAssembly, childElement.Name.ToString(), childElement);
    }
}
