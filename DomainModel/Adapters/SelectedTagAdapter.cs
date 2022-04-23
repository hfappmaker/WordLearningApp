using Android.Content;
using Android.Views;
using Android.Widget;
using Common.Adapters;
using DomainModel;
using System.Collections.Generic;
using System.Linq;
using WordLearning.Colors;

namespace WordLearning.Adapter
{
    /// <summary>
    /// Array adapter selected tag.
    /// </summary>
    public class SelectedTagAdapter : CustomArrayAdapter
    {
        public List<(int, int[], string, string, bool)> list;
        public SelectedTagAdapter(Context context, int resource) : base(context, resource, TagColorCollection.Instance.ToList())
        {
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //bool convertflag;
            //(int, int[], string,string, bool) item1;
            ListView listView = (ListView)parent;
            if (list != null)
            {
                View view;
                //if (convertView != null)
                //{
                //convertflag = true;
                view = convertView;
                //}
                //else
                //{
                //convertflag = false;
                view = Inflater.Inflate(layoutid, null);
                view.SetPaddingRelative(48, 48, 48, 48);
                //}
                TagColor tagColor = TagColorCollection.Instance[position];
                //TextView text = null;
                //ImageView imageView = null;
                //CheckBox checkBox = null;
                switch (layoutid)
                {
                    case Resource.Layout.row_SelectedTag:
                        //view.SetTag(Constant.FreeTagKey,position);
                        //text = view.FindViewById<TextView>(Resource.Id.tvMeaning_row_SelectedTag);
                        //imageView = view.FindViewById<ImageView>(Resource.Id.iv_row_SelectedTag);
                        //checkBox = view.FindViewById<CheckBox>(Resource.Id.chk_row_SelectedTag);
                        //checkBox.SetTag(Constant.FreeTagKey, position);
                        //checkBox.Checked = item1.Item5;
                        //text.Text = item1.Item3;
                        //view.Click += (s, e) => { checkBox.Checked = !checkBox.Checked; };
                        //var drawable = Context.GetDrawable((int)tagColor.Shape);
                        //drawable.Mutate();
                        //drawable.SetColorFilter(new BlendModeColorFilter(tagColor.WlColor, BlendMode.Multiply));
                        //imageView.SetImageDrawable(drawable);
                        //if (!convertflag)
                        //{
                        //    checkBox.CheckedChange += (s, e) => 
                        //    {
                        //        int pst = int.Parse(((CheckBox)s).GetTag(Constant.FreeTagKey).ToString());
                        //        list[pst] = new ValueTuple<int, int[], string,string, bool>(list[pst].Item1, list[pst].Item2, list[pst].Item3, list[pst].Item4,!list[pst].Item5);
                        //    };
                        //}
                        //imageView.Visibility = ViewStates.Visible;
                        //if (item1.Item1 == 5)
                        //{
                        //    imageView.Visibility = ViewStates.Invisible;
                        //}
                        break;
                }
                return view;
            }
            return base.GetView(position, convertView, parent);
        }
    }
}
