using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Graphics.Drawable;
using System.Linq;
using System.Reactive.Disposables;
using WordLearning.Domain.Colors;
using WordLearning.Domain.Entry;
using WordLearning.Domain.Adapters.AdapterCore;

namespace WordLearning.Domain.Adapters
{
    // <summary>
    /// Array adapter edit wordlist.
    /// </summary>
    public class Edit_WordListAdapter : CustomArrayAdapter<WlWord>
    {
        private readonly CompositeDisposable _adapterDisposable = new();

        public WlWordList CurrentWordList { get; }

        public Edit_WordListAdapter(Context context, int resource, WlWordList wordList) : base(context, resource, wordList)
        {
            _adapterDisposable.Add(wordList.RegisterCollectionChanged((entries, e) =>
                        {
                            Clear();
                            AddAll(entries);
                            NotifyDataSetChanged();
                        }));

            CurrentWordList = wordList;
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view;
            bool isConvertView = convertView != null;
            if (isConvertView)
            {
                view = convertView;
            }
            else
            {
                view = Inflater.Inflate(LayoutID, null);
                view.SetPaddingRelative(48, 48, 48, 48);
            }

            WlWord item = GetItem(position) as WlWord;
            TextView wordText = view.FindViewById<TextView>(Resource.Id.tvWord_row_Latest);
            wordText.Text = item.Word;
            TextView wordMeaningText = view.FindViewById<TextView>(Resource.Id.tvWordmeaning_row_Latest);
            wordMeaningText.Text = item.WordMeaning;
            ImageButton optionButton = view.FindViewById<ImageButton>(Resource.Id.ibrow_Latest);
            GridLayout gridLayout = view.FindViewById<GridLayout>(Resource.Id.gl_Taglist_row_Latest);
            gridLayout.RemoveAllViews();
            foreach ((TagColor tagColor, int index) in TagColorCollection.Instance.Select((tagColor, index) => (tagColor, index)))
            {
                ImageView imageView = new ImageView(Context);
                VectorDrawable drawable = Context.GetDrawable(tagColor.Shape.Id) as VectorDrawable;
                drawable.Mutate();
                DrawableCompat.SetTintList(drawable, new ColorStateList(new int[][] { new int[] { } }, new int[] { tagColor.WlColor }));
                imageView.SetImageDrawable(drawable);
                GridLayout.LayoutParams param = new GridLayout.LayoutParams
                {
                    ColumnSpec = GridLayout.InvokeSpec(TagColorCollection.Instance.Count - index)
                };
                imageView.LayoutParameters = param;
                gridLayout.AddView(imageView);
            }

            return view;
        }
    }


}
