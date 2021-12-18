using Android.OS;
using AndroidX.AppCompat.App;
using Common.Entry;
using Common.Visitors;
using WordLearning.Entry;
using WordLearning.Utility;

namespace WordLearning.Fragment
{
    public class DeleteEntriesDialogFragment : WlAlartDialogFragment
    {
        private readonly WlDirectory _rootFolder;


        public DeleteEntriesDialogFragment(WlDirectory rootFolder) : base()
        {
            _rootFolder = rootFolder;
        }


        public override Android.App.Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(Activity);
            builder.SetMessage(Resource.String.DeleteEntryConfirm);
            builder.SetPositiveButton("OK", (_, _) =>
            {
                _rootFolder.Accept(new DeleteCheckedEntryVisitor());
                OnDialogResult();
            });
            builder.SetNegativeButton("CANCEL", (_, _) => { });
            return builder.Create();
        }
    }
}
