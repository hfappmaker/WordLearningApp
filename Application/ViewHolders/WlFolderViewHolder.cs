using Android.Views;
using Android.Widget;
using WordLearning.Domain.Entry;
using WordLearning.Domain.Entry.EntryCore;

namespace WordLearning.Domain.ViewHolders
{
    public class WlFolderViewHolder : WlViewHolder<WlDirectory>
    {
        public WlFolderViewHolder(ViewGroup parent, int viewType)
            : base(CreateView(parent, viewType))
        {

        }


        public override void Bind(WlDirectory item)
        {
            var textView = ItemView.FindViewById<TextView>(Resource.Id.tvFoldername_row_SelectDestination);
        }

        private static View CreateView(ViewGroup parent, int viewType)
        {
            return LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row_SelectDestination, parent);
        }
    }
}