using Android.OS;
using AndroidX.AppCompat.App;
using Common.Visitors;
using WordLearning.Utility;

namespace WordLearning.Fragment
{
    public class DeleteEntriesDialogFragment : WlAlartDialogFragment
    {
        public DeleteEntriesDialogFragment() : base()
        {
        }


        public override Android.App.Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(Activity);
            builder.SetMessage(Resource.String.DeleteEntryConfirm);
            builder.SetPositiveButton("OK", (_, _) =>
            {
                WlUtility.RootFolder.Accept(new DeleteCheckedEntryVisitor());
                OnDialogResult();
            });
            builder.SetNegativeButton("CANCEL", (_, _) => { });
            return builder.Create();
        }
    }
}
