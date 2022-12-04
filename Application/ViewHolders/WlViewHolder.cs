using Android.Runtime;
using Android.Views;
using System;

namespace WordLearning.Domain.ViewHolders
{
    public abstract class WlViewHolder<TItem> : AndroidX.RecyclerView.Widget.RecyclerView.ViewHolder
        where TItem : Java.Lang.Object
    {
        protected WlViewHolder(View itemView) : base(itemView)
        {
        }

        protected WlViewHolder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public abstract void Bind(TItem item);
    }
}