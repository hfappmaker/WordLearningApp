using Android.Content;
using Android.Views;
using Android.Widget;
using System.Collections;
using System.Collections.Generic;

namespace Common.Adapters
{
    public abstract class CustomArrayAdapter : ArrayAdapter
    {
        public int layoutid;
        public LayoutInflater Inflater;
        protected CustomArrayAdapter(Context context, int resource, IEnumerable objects) : base(context, resource, GetObjects(objects))
        {

            layoutid = resource;
            Inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            return base.GetView(position, convertView, parent);
        }


        private static IList GetObjects(IEnumerable objects)
        {
            List<object> list = new();
            foreach (object item in objects)
            {
                list.Add(item);
            }

            return list;
        }
    }

}
