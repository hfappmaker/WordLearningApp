using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WordLearning.Utility;

namespace WordLearning.Colors
{
    public class TagColorCollection : IReadOnlyList<TagColor>
    {
        private IReadOnlyList<TagColor> TagCollection { get; }


        public TagColorCollection()
        {
            TagCollection = WlUtility.RootElement.Element(nameof(TagColorCollection)).Elements().Select(tag => new TagColor(tag)).ToList();
        }

        private static TagColorCollection _instance;


        public static TagColorCollection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TagColorCollection();
                }

                return _instance;
            }
        }

        public IEnumerator<TagColor> GetEnumerator() => TagCollection.GetEnumerator();


        IEnumerator IEnumerable.GetEnumerator() => TagCollection.GetEnumerator();


        public int Count => TagCollection.Count;


        public TagColor this[int index] => TagCollection[index];
    }
}
