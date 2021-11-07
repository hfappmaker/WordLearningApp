using Android.OS;
using AndroidX.AppCompat.App;
using Common.Extension;
using System;
using WordLearning.Entry;

namespace WordLearning.Fragment
{
    public class AddNewDirectoryDialogFragment : WlAlartDialogFragment
    {
        public AddNewDirectoryDialogFragment() : base()
        {
        }


        public override Android.App.Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(Activity);
            builder.SetItems(new string[] {
                    Resources.GetString(Resource.String.AddFolder),
                    Resources.GetString(Resource.String.AddWordlist)
                },
                (dialog, e) =>
                {
                    AddDirectory((WlEntryType)e.Which);
                });

            builder.SetPositiveButton("CANCEL", (_, _) => { });
            return builder.Create();
        }


        /// <summary>
        /// Add new wordlist or folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDirectory(WlEntryType entryType)
        {
            Bundle bundle = new Bundle();
            bundle.PutEnum(CreateNewItemDialogFragment.ENTRY_TYPE_KEY, entryType);
            new CreateNewItemDialogFragment(bundle).Show(Activity.SupportFragmentManager, null);
        }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }


        public override void OnSaveInstanceState(Bundle outState)
        {
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
