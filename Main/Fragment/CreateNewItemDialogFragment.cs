using System;
using System.Linq;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using Common.Entry;
using Common.Extension;
using WordLearning.Activities;
using WordLearning.Dialog;
using WordLearning.Entry;
using WordLearning.Language;
using WordLearning.Messages;
using WordLearning.Utility;

namespace WordLearning.Fragment
{
    public class CreateNewItemDialogFragment : WlAlartDialogFragment
    {
        private const string    EDITTEXT_KEY   = "EditText";
        public const string     ENTRY_TYPE_KEY = "EntryType";
        private EditText _editText;
        public  CreateNewItemDialogFragment(Bundle bundle) : base(bundle)
        {
        }


        public CreateNewItemDialogFragment() : base()
        {

        }


        public override Android.App.Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var builder = new AlertDialog.Builder(Activity);
            _editText   = new EditText(Activity);
            if (savedInstanceState != null)
            {
                _editText.Text = savedInstanceState.GetString(EDITTEXT_KEY);
            }

            builder.SetView(_editText);
            builder.SetMessage(Resource.String.SetName);
            builder.SetNegativeButton("CANCEL", (_, _) => { });
            builder.SetPositiveButton("OK", (_, _) => CreateNewItem(_editText.Text));
            return builder.Create();
        }


        private void CreateNewItem(string fileName)
        {
            var entryType = Arguments.GetEnum<WlEntryType>(ENTRY_TYPE_KEY);
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
            outState.PutString(EDITTEXT_KEY,    _editText.Text);
            base.OnSaveInstanceState(outState);
        }


        public override void OnDetach()
        {
            base.OnDetach();
        }


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
