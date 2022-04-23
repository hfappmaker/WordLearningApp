using Android.Widget;
using Common.Adapters;
using System;

namespace DomainModel.Extension
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
    }
}
