﻿using Android.Widget;
using Java.IO;

namespace WordLearning.CoreLibrary.Extension
{
    public static class AdapterExtension
    {
        public static T GetItem<T>(this IAdapter @adapter, int position) where T : Java.Lang.Object
        {
            Java.Lang.Object item = adapter.GetItem(position);
            if (item is not T)
            {
                throw new InvalidClassException("cast error");
            }

            return item as T;
        }
    }
}
