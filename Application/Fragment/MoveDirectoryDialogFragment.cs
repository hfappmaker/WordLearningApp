using Android.OS;
using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using System.Linq;
using WordLearning.Domain.Adapters;
using WordLearning.Domain.Entry.EntryCore;

namespace WordLearning.Application.Fragment
{
    public class MoveDirectoryDialogFragment : WlAlartDialogFragment
    {
        public MoveDirectoryDialogFragment() : base()
        {
        }


        public override Android.App.Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            AlertDialog.Builder builder = new(Activity);
            View layout                 = LayoutInflater.Inflate(Resource.Layout.Dialog_Move_Start, null);
            RecyclerView listFolder     = layout.FindViewById<RecyclerView>(Resource.Id.lv_Dialog_Move_Start);
            listFolder.SetLayoutManager(new LinearLayoutManager(Activity));
            Start_MoveAdapter adapter   = new();
            listFolder.SetAdapter(adapter);
            builder.SetMessage(Resource.String.SelectDestination);
            builder.SetPositiveButton(Resource.String.Moving, (_, _) =>
            {
                //if (adapter.CurrentSelectedFolder != null)
                //{
                //    foreach (WlEntry item in checkedItems.ToList())
                //    {
                //        item.ClearCheck();
                //        item.MoveTo(adapter.CurrentSelectedFolder);
                //    }
                //}

                OnDialogResult(true);
            });
            builder.SetNegativeButton("CANCEL", (_, _) => OnDialogResult());
            builder.SetView(layout);
            builder.SetCancelable(false);
            return builder.Create();
        }
    }
}
