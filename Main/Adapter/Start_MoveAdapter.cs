using Android.Graphics;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using WordLearning.Entry;
using static AndroidX.RecyclerView.Widget.RecyclerView;

namespace WordLearning.Adapter
{
    /// <summary>
    /// Array adapter start move.
    /// </summary>
    public class Start_MoveAdapter : RecyclerAdapter
    {
        private readonly List<WlFolder> _items = new();
        private readonly Func<IEnumerable<WlFolder>> _getter;
        public WlFolder CurrentSelectedFolder { get; private set; }
        public Start_MoveAdapter(Func<IEnumerable<WlFolder>> getter)
            : base()
        {
            _getter = getter;
            _items.AddRange(_getter());
            NotifyDataSetChanged();
        }


        public override int ItemCount => _items.Count;


        public override void OnBindViewHolder(ViewHolder holder, int position)
        {
            WlFolderView vh = holder as WlFolderView;
            vh.ItemView.Visibility = ViewStates.Visible;
            vh.ItemView.SetPadding(_items[position].Rank * 48, 0, 0, 0);
            vh.FolderName.Text = _items[position].Name;
            if (CurrentSelectedFolder == _items[position])
            {
                vh.ItemView.SetBackgroundColor(Color.Green);
            }
            else
            {
                vh.ItemView.SetBackgroundColor(Color.White);
            }
            if (_items[position].IsExpanded)
            {
                vh.ArrowImage.SetImageResource(Resource.Drawable.ic_below_48pt);
            }
            else
            {
                vh.ArrowImage.SetImageResource(Resource.Drawable.ic_switchdirectory_48pt);
            }
        }


        public override ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row_SelectDestination, parent, false);
            WlFolderView vh = new(itemView, OnImageClick, OnTextClick);
            return vh;
        }


        private void OnImageClick(int position)
        {
            _items[position].ChangeExpanded();
            _items.Clear();
            _items.AddRange(_getter());
            NotifyDataSetChanged();
        }

        private void OnTextClick(int position)
        {
            CurrentSelectedFolder = _items[position];
            NotifyDataSetChanged();
        }


        private class WlFolderView : ViewHolder
        {
            public ImageView ArrowImage { get; private set; }
            public TextView FolderName { get; private set; }

            public WlFolderView(View itemView, Action<int> imageClickAction, Action<int> textClickAction) : base(itemView)
            {
                ArrowImage = itemView.FindViewById<ImageView>(Resource.Id.iv_row_SelectDestination);
                FolderName = itemView.FindViewById<TextView>(Resource.Id.tvFoldername_row_SelectDestination);
                ArrowImage.Click += (sender, e) => imageClickAction(LayoutPosition);
                FolderName.Click += (sender, e) => textClickAction(LayoutPosition);
            }
        }
    }
}
