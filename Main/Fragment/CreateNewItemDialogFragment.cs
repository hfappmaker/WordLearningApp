using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using Common.Entry;
using Common.Extension;
using Common.Visitors;
using System;
using WordLearning.Adapter;
using WordLearning.Entry;
using WordLearning.Utility;

namespace WordLearning.Application.Fragment
{
    public class CreateNewItemDialogFragment : WlAlartDialogFragment
    {
        private const string EDITTEXT_KEY = "EditText";
        public const string ENTRY_TYPE_KEY = "EntryType";
        private EditText _editText;
        public CreateNewItemDialogFragment(Bundle bundle) : base(bundle)
        {
        }


        public CreateNewItemDialogFragment() : base()
        {

        }


        public override Android.App.Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(Activity);
            _editText = new EditText(Activity);
            if (savedInstanceState != null)
            {
                _editText.Text = savedInstanceState.GetString(EDITTEXT_KEY);
            }

            builder.SetView(_editText);
            builder.SetMessage(Resource.String.SetName);
            builder.SetNegativeButton("CANCEL", (_, _) => { });
            builder.SetPositiveButton("OK", (_, _) => CreateNewItem(_editText.Text));


            AlertDialog.Builder builder = new(Activity);
            View layout = LayoutInflater.Inflate(Resource.Layout.Dialog_Move_Start, null);
            RecyclerView listFolder = layout.FindViewById<RecyclerView>(Resource.Id.lv_Dialog_Move_Start);
            listFolder.SetLayoutManager(new LinearLayoutManager(Activity));
            var checkedItems = _rootFolder.Accept(new GetCheckedEntryVisitor());
            Start_MoveAdapter adapter = new(() => _rootFolder.Accept(new GetHierarchicalEntryVisitor(checkedItems))
                                          .Where(entry => entry is WlFolder)
                                          .Select(entry => entry as WlFolder));
            listFolder.SetAdapter(adapter);
            builder.SetMessage(Resource.String.SelectDestination);
            builder.SetPositiveButton(Resource.String.Moving, (_, _) =>
            {
                if (adapter.CurrentSelectedFolder != null)
                {
                    foreach (WlEntry item in checkedItems.ToList())
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


        private void CreateNewItem(string fileName)
        {
            WlEntryType entryType = Arguments.GetEnum<WlEntryType>(ENTRY_TYPE_KEY);
            if (WlUtility.FileNameCheck(fileName, Context))
            {
                OnDialogResult((entryType, fileName));
            }
        }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }


        public override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutString(EDITTEXT_KEY, _editText.Text);
            base.OnSaveInstanceState(outState);
        }


        public override void OnDetach()
        {
            base.OnDetach();
        }

        [Obsolete]
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
        }


        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}
