using Android.Widget;
using System;

namespace WordLearning.CoreLibrary.Extension
{
    public static class ListViewExtension
    {
        public static T GetItem<T>(this ListView @listView, int position) where T : Java.Lang.Object
        {
            return listView.Adapter.GetItem<T>(position);
        }

        public static T GetAdapter<T>(this ListView @this)
            where T : IAdapter
        {
            if (@this.Adapter is not T)
            {
                throw new InvalidCastException();
            }

            return (T)@this.Adapter;
        }
    }
}
