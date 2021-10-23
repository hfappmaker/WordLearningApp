using System;
using Android.Widget;
using Common.Adapters;

namespace Common.Extension
{
    public static class ListViewExtension
    {
        public static T GetAdapter<T>(this ListView @this) where T : CustomArrayAdapter
        {
            if (@this.Adapter is not T)
            {
                throw new InvalidCastException();
            }

            return @this.Adapter as T;
        }


        public static T GetItem<T>(this ListView @listView, int position) where T : Java.Lang.Object
        {
            return listView.Adapter.GetItem<T>(position);
        }
    }
}
