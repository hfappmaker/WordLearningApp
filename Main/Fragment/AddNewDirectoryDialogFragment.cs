using Android.Content;
using Android.OS;
using AndroidX.AppCompat.App;
using Common.Entry;
using Common.Extension;
using Common.Utility;
using System;
using System.Reflection;
using WordLearning.Adapter;
using WordLearning.Dialog;
using WordLearning.Entry;
using WordLearning.Utility;

namespace WordLearning.Fragment
{
    public class AddNewDirectoryDialogFragment : WlAlartDialogFragment
    {
        public static readonly string AddNewDirectoryKey = nameof(AddNewDirectoryKey);


        public AddNewDirectoryDialogFragment() : base()
        {
        }


        public override Android.App.Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            AlertDialog.Builder builder = new(Activity);
            builder.SetItems(new string[] {
                    Resources.GetString(Resource.String.AddFolder),
                    Resources.GetString(Resource.String.AddWordlist)
                },
                (dialog, e) =>
                {
                    AddDirectory(e.Which == 0 ? nameof(WlFolder) : nameof(WlWordList));
                });

            builder.SetPositiveButton("CANCEL", (_, _) => { });
            return builder.Create();
        }


        /// <summary>
        /// Add new wordlist or folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDirectory(string entryType)
        {
            Bundle renameDirectoryBundle = new();
            renameDirectoryBundle.PutExtra(RenameDirectoryDialogFragment.RenameDirectoryKey, CommonUtility.CreateInstance<WlDirectory>(WlUtility.CurrentAssembly, entryType));
            ParentFragmentManager.SetFragmentResultListenerXamarin(RenameDirectoryDialogFragment.RenameDirectoryDialogResultKey, this, (key, bundle) => 
                {
                    WlDirectory directory = renameDirectoryBundle.GetExtra<WlDirectory>(RenameDirectoryDialogFragment.RenameDirectoryKey);
                    if (bundle.GetEnum<DialogButtonType>(nameof(DialogButtonType)) == DialogButtonType.Positive)
                    {
                        var addNewDirectoryBundle = new Bundle();
                        addNewDirectoryBundle.PutExtra(nameof(WlDirectory), directory);
                        ParentFragmentManager.SetFragmentResult(AddNewDirectoryKey, addNewDirectoryBundle);
                    }
                });
            new RenameDirectoryDialogFragment(renameDirectoryBundle).Show(ParentFragmentManager, null);
            // OnDialogResult();
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


        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}
