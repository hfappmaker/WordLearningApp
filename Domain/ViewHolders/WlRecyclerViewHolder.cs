using Android.Views;
using Android.Widget;
using WordLearning.Domain.Entry;

namespace WordLearning.Domain.ViewHolders
{
    public class WlRecyclerViewHolder : WlViewHolder<WlFolder>
    {
        public WlRecyclerViewHolder(ViewGroup parent, int viewType)
            : base(CreateView(parent, viewType))
        {

        }


        public override void Bind(WlFolder item)
        {
            var textView = ItemView.FindViewById<TextView>(Resource.Id.tvFoldername_row_SelectDestination);
        }

        private static View CreateView(ViewGroup parent, int viewType)
        {
            return LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row_SelectDestination, parent);
        }
    }
}