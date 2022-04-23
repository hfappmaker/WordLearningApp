using Android.Widget;

namespace Common.Extension
{
    public static class ListViewExtension
    {
        public static T GetItem<T>(this ListView @listView, int position) where T : Java.Lang.Object
        {
            return listView.Adapter.GetItem<T>(position);
        }
    }
}
