using Android.Content;
using Android.Views;
using Android.Widget;
using Common.Adapters;
using System;
using System.Collections;
using System.Collections.Generic;
using WordLearning.Activities;

namespace WordLearning.Adapter
{
    /// <summary>
    /// Array adapter board.
    /// </summary>
    public class PostAdapter : CustomArrayAdapter
    {
        private readonly List<(string, string, DateTime)> list;
        private readonly Question_bulletin_board question_Bulletin_Board;
        public PostAdapter(Context context, int resource, IList objects) : base(context, resource, objects)
        {
            list = (List<(string, string, DateTime)>)objects;
            question_Bulletin_Board = context as Question_bulletin_board;
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
                (string, string, DateTime) item = list[position];
                TextView text = view.FindViewById<TextView>(Resource.Id.tvRow_Post);
                TextView date = view.FindViewById<TextView>(Resource.Id.tvDate_row_Post);
                text.Text = item.Item1;
                date.Text = item.Item2 + "   " + item.Item3.ToLocalTime().ToString();
                return view;
            }
            return base.GetView(position, convertView, parent);
        }
    }
}
