using Android.Views;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using WordLearning.CoreLibrary.Core;
using WordLearning.Domain.ViewHolders;
using static AndroidX.RecyclerView.Widget.RecyclerView;

namespace WordLearning.Domain.Adapters.AdapterCore
{
    public abstract class RecyclerAdapter<TItem, TViewHolder> : AndroidX.RecyclerView.Widget.RecyclerView.Adapter
        where TItem : Java.Lang.Object
        where TViewHolder : WlViewHolder<TItem>
    {
        private readonly CompositeDisposable _adapterDisposable = new();

        protected IReadOnlyList<TItem> Items  => _items;

        public override int ItemCount => Items.Count;


        private List<TItem> _items = new();

        protected RecyclerAdapter(IEnumerableV2<TItem> items)
        {
            _adapterDisposable.Add(items.RegisterCollectionChanged((entries, e) =>
            {
                _items.Clear();
                _items.AddRange(entries);
                NotifyDataSetChanged();
            }));

            _adapterDisposable.Add(Disposable.Create(() => items.Dispose()));
        }


        public override ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            return (TViewHolder)Activator.CreateInstance(typeof(TViewHolder), parent, viewType);
        }


        public override void OnBindViewHolder(ViewHolder holder, int position)
        {
            OnBindViewHolder((TViewHolder)holder, position);
        }


        protected virtual void OnBindViewHolder(TViewHolder holder, int position)
        {
            holder.Bind(Items[position]);
        }


        public new void Dispose()
        {
            _adapterDisposable.Dispose();
            base.Dispose();
        }
    }
}