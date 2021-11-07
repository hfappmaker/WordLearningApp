using Android.Content;
using Android.Views;
using Android.Widget;
using Common.Adapters;
using System.Collections;
using System.Collections.Generic;

namespace WordLearning.Adapter
{
    public class SelectedTagGridViewAdapter : CustomArrayAdapter
    {
        public List<ImageView> list;
        public SelectedTagGridViewAdapter(Context context, int resource, IList objects) : base(context, resource, objects)
        {
            list = (List<ImageView>)objects;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (list != null)
            {
                View view;
                if (convertView != null)
                {
                    view = convertView;
                }
                else
                {
                    view = Inflater.Inflate(layoutid, null);
                    view.SetPaddingRelative(48, 48, 48, 48);
                }

                return view;
            }
            return base.GetView(position, convertView, parent);
        }
    }
}
