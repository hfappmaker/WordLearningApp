using Android.OS;
using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using Common.Entry;
using Common.Visitors;
using System.Collections.Generic;
using System.Linq;
using WordLearning.Adapter;
using WordLearning.Entry;
using WordLearning.Fragment;
using WordLearning.Language;
using WordLearning.Messages;
using WordLearning.Utility;

namespace WordLearning.Dialog
{
    public class MoveDirectoryDialogFragment : WlAlartDialogFragment
    {
        private readonly WlFolder _rootFolder;


        public MoveDirectoryDialogFragment(WlFolder rootFolder) : base()
        {
            _rootFolder = rootFolder;
        }


        public override Android.App.Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            AlertDialog.Builder builder = new(Activity);
            View layout                 = LayoutInflater.Inflate(Resource.Layout.Dialog_Move_Start, null);
            RecyclerView listFolder     = layout.FindViewById<RecyclerView>(Resource.Id.lv_Dialog_Move_Start);
            listFolder.SetLayoutManager(new LinearLayoutManager(Activity));
            var checkedItems            = _rootFolder.Accept(new GetCheckedEntryVisitor());
            Start_MoveAdapter adapter   = new(() => _rootFolder.Accept(new GetHierarchicalEntryVisitor(checkedItems))
                                            .Where(entry => entry is WlFolder)
                                            .Select(entry => entry as WlFolder));
            listFolder.SetAdapter(adapter);
            builder.SetMessage(Resource.String.SelectDestination);
            builder.SetPositiveButton(Resource.String.Moving, (_, _) =>
            {
                if (adapter.CurrentSelectedFolder != null)
                {
                    foreach (WlEntry item in checkedItems)
                    {
                        item.ClearCheck();
                        item.MoveTo(adapter.CurrentSelectedFolder);
                    }
                }

                OnDialogResult(true);
            });
            builder.SetNegativeButton("CANCEL", (_, _) => OnDialogResult());
            builder.SetView(layout);
            builder.SetCancelable(false);
            return builder.Create();
        }
    }
}
