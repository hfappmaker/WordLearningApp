using System;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using Common.Entry;
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
            var type = WlUtility.CurrentAssembly.GetType(childElement.Name.ToString());
            if (type == typeof(WlWord))
            {
                throw new InvalidOperationException();
            }

            return Activator.CreateInstance(type, childElement, this) as WlEntry;
        }
    }
}
