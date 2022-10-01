using Android.Content;
using Android.Views;
using Android.Widget;
using System;
using System.Collections;
using System.Collections.Generic;
using WordLearning.Domain.Adapters.AdapterCore;

namespace WordLearning.Domain.Adapters
{
    /// <summary>
    /// Array adapter board.
    /// </summary>
    public class ArrayAdapter_Title : CustomArrayAdapter<Java.Lang.Object>
    {
        private readonly List<(string, DateTime)> list;
        public ArrayAdapter_Title(Context context, int resource, IList objects) : base(context, resource, (IEnumerable<Java.Lang.Object>)objects)
        {
            list = (List<(string, DateTime)>)objects;
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
                    view = Inflater.Inflate(LayoutID, null);
                    view.SetPaddingRelative(48, 48, 48, 48);
                }
                (string, DateTime) item = list[position];
                TextView text = view.FindViewById<TextView>(Resource.Id.tvRow_Post);
                TextView date = view.FindViewById<TextView>(Resource.Id.tvDate_row_Post);
                text.Text = item.Item1;
                date.Text = item.Item2.ToLocalTime().ToString();
                return view;
            }
            return base.GetView(position, convertView, parent);
        }
    }
}
