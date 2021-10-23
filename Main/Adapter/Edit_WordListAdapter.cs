using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Subjects;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Graphics.Drawable;
using Common.Adapters;
using WordLearning.Colors;
using WordLearning.Dialog;
using WordLearning.Entry;

namespace WordLearning.Adapter
{
    // <summary>
    /// Array adapter edit wordlist.
    /// </summary>
    public class Edit_WordListAdapter: CustomArrayAdapter
    {
        private readonly CompositeDisposable _adapterDisposable = new();

        public WlWordList CurrentWordList { get; }

        public Edit_WordListAdapter(Context context, int resource, WlWordList wordList) : base(context, resource, wordList.EntryIterator)
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
            var isConvertView = convertView != null;
            if (isConvertView)
            {
                view = convertView;
            }
            else
            {
                view = Inflater.Inflate(layoutid, null);
                view.SetPaddingRelative(48, 48, 48, 48);
            }

            var item = GetItem(position) as WlWord;
            switch (layoutid)
            {
                case Resource.Layout.row_Latest:
                   var wordText = view.FindViewById<TextView>(Resource.Id.tvWord_row_Latest);
                    wordText.Text = item.Word;
                    var wordMeaningText = view.FindViewById<TextView>(Resource.Id.tvWordmeaning_row_Latest);
                    wordMeaningText.Text = item.WordMeaning;
                    var optionButton = view.FindViewById<ImageButton>(Resource.Id.ibrow_Latest);
                    var gridLayout = view.FindViewById<GridLayout>(Resource.Id.gl_Taglist_row_Latest);
                    gridLayout.RemoveAllViews();
                    foreach (var (tagColor, index) in TagColorCollection.Instance.Select((tagColor, index) => (tagColor, index)))
                    {
                        var imageView = new ImageView(Context);
                        var drawable = Context.GetDrawable((int)tagColor.Shape) as VectorDrawable;
                        drawable.Mutate();
                        DrawableCompat.SetTintList(drawable, new ColorStateList(new int[][] { new int[] { } }, new int[] { tagColor.WlColor }));
                        imageView.SetImageDrawable(drawable);
                        var param = new GridLayout.LayoutParams
                        {
                            ColumnSpec = GridLayout.InvokeSpec(TagColorCollection.Instance.Count - index)
                        };
                        imageView.LayoutParameters = param;
                        gridLayout.AddView(imageView);
                    }

                    //if (imagebuttonflag)
                    //{
                    //    imageButton.Click += (_, _) =>
                    //    {
                    //        if (edit_Wordlist.basetoolbarResID == Resource.Id.tbEdit_Wordlist_Init)
                    //        {
                    //            var menu = new PopupMenu(edit_Wordlist, imageButton);
                    //            menu.Inflate(Resource.Menu.menu_popup_Dialog_EditTag);
                    //            menu.MenuItemClick += (_, e) =>
                    //            {
                    //                switch (e.Item.ItemId)
                    //                {
                    //                    case Resource.Id.menuitem_EditTag_Dialog_EditTag:
                    //                        new EditWordTagDialogBuilder(Context).Show();
                    //                        break;
                    //                    case Resource.Id.menuitem_EditMemo_Dialog_EditTag:
                    //                        new EditWordMemoDialogBuilder(Context).Show();
                    //                        break;
                    //                }
                    //            };
                    //            menu.Show();
                    //        }
                    //    };
                    //}
                    break;
                case Android.Resource.Layout.SimpleListItemMultipleChoice:
                    var ctext = view.FindViewById<CheckedTextView>(Android.Resource.Id.Text1);
                    ctext.Text = item.Word;
                    break;
            }

            return view;
        }
    }

    
}
