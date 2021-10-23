using Android.Content;
using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using WordLearning.Adapter;
using WordLearning.Language;
using WordLearning.Messages;
using WordLearning.Fragment;
using Android.OS;
using WordLearning.Utility;
using System.Collections.Generic;
using Common.Entry;
using System.Linq;
using WordLearning.Entry;
using Common.Visitors;

namespace WordLearning.Dialog
{
    public class MoveDirectoryDialogFragment : WlAlartDialogFragment
    {
        private readonly IEnumerable<WlEntry> _checkedItems = new GetCheckedEntryVisitor().Visit(WlUtility.RootFolder);
        public MoveDirectoryDialogFragment() : base()
        {
        }


        public override Android.App.Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var builder = new AlertDialog.Builder(Activity);
            var layout = LayoutInflater.Inflate(Resource.Layout.Dialog_Move_Start, null);
            RecyclerView listFolder = layout.FindViewById<RecyclerView>(Resource.Id.lv_Dialog_Move_Start);
            listFolder.SetLayoutManager(new LinearLayoutManager(Activity));
            var adapter = new Start_MoveAdapter(GetDestinationFolder);
            listFolder.SetAdapter(adapter);
            builder.SetMessage(WlMessage.SelectDestination[WlLanguageUtil.CurrentLanguage]);
            builder.SetPositiveButton(WlMessage.Moving[WlLanguageUtil.CurrentLanguage], (_, _) =>
            {
                if (adapter.CurrentSelectedFolder != null)
                {
                    foreach (var item in _checkedItems.ToList())
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


        private IEnumerable<WlFolder> GetDestinationFolder()
        {
            return new GetHierarchicalEntryVisitor(_checkedItems).Visit(WlUtility.RootFolder)
                            .Where(entry => entry is WlFolder)
                            .Select(entry => entry as WlFolder);
        }
    }
}
