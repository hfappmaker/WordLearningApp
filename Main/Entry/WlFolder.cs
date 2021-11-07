using Common.Entry;
using System;
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


        public WlFolder(XElement element) : base(element)
        {

        }


        protected override WlEntry CreateChildEntry(XElement childElement)
        {
            Type type = WlUtility.CurrentAssembly.GetType(childElement.Name.ToString());
            if (type == typeof(WlWord))
            {
                throw new InvalidOperationException();
            }

            return Activator.CreateInstance(type, childElement, this) as WlEntry;
        }
    }
}
