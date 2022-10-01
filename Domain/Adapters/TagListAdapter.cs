using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using System.Linq;
using WordLearning.Domain.Adapters.AdapterCore;
using WordLearning.Domain.Colors;

namespace WordLearning.Domain.Adapters
{
    /// <summary>
    /// Array adapter taglist.
    /// </summary>
    public class TagListAdapter : CustomArrayAdapter<TagColor>
    {
        private readonly Context edit_Wordlist;
        public TagListAdapter(Context context, int resource) : base(context, resource, TagColorCollection.Instance.ToList())
        {
            edit_Wordlist = context;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            TagColor tagColor = TagColorCollection.Instance[position];
            ListView listView = (ListView)parent;
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
            TextView text = null;
            ImageView imageView = null;
            text = view.FindViewById<TextView>(Resource.Id.tvMeaning_row_Taglist);
            text.Text = tagColor.Meaning;
            imageView = view.FindViewById<ImageView>(Resource.Id.iv_row_Taglist);
            Android.Graphics.Drawables.Drawable drawable = edit_Wordlist.GetDrawable((int)tagColor.Shape.Id);
            drawable.Mutate();
            drawable.SetColorFilter(new BlendModeColorFilter(tagColor.WlColor, BlendMode.Multiply));
            imageView.SetImageDrawable(drawable);
            return view;
            //return base.GetView(position, convertView, parent);
        }
    }
}
