using Android.Content;
using Android.Views;
using Android.Widget;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WordLearning.Domain.Adapters.AdapterCore
{
    public abstract class CustomArrayAdapter<TItem> : ArrayAdapter
        where TItem : Java.Lang.Object
    {
        protected int LayoutID { get; }

        protected LayoutInflater Inflater { get; }

        protected CustomArrayAdapter(Context context, int resource, IEnumerable<TItem> objects) : base(context, resource, objects.ToArray())
        {

            LayoutID = resource;
            Inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            return base.GetView(position, convertView, parent);
        }
    }

}
