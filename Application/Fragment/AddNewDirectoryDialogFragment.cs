﻿using Android.Content;
using Android.OS;
using AndroidX.AppCompat.App;
using WordLearning.Domain.Utility;
using WordLearning.Domain.Entry;
using WordLearning.Domain.Entry.EntryCore;
using WordLearning.CoreLibrary.Utility;
using WordLearning.CoreLibrary.Extension;

namespace WordLearning.Application.Fragment
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
                    AddDirectory((dialog as AlertDialog), e.Which == 0 ? nameof(WlFolder) : nameof(WlWordList));
                });

            builder.SetPositiveButton("CANCEL", (_, _) => { });
            return builder.Create();
        }


        /// <summary>
        /// Add new wordlist or folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDirectory(AlertDialog dialog, string entryType)
        {
            Bundle renameDirectoryBundle = new();
            renameDirectoryBundle.PutExtra(RenameDirectoryDialogFragment.RenameDirectoryKey, CommonUtility.CreateInstance<WlDirectory>(WlUtility.CurrentAssembly, entryType));
            var temp = new RenameDirectoryDialogFragment(renameDirectoryBundle);
            ParentFragmentManager.SetFragmentResultListenerXamarin(RenameDirectoryDialogFragment.RenameDirectoryDialogResultKey, temp, (key, bundle) => 
                {
                    WlDirectory directory = renameDirectoryBundle.GetExtra<WlDirectory>(RenameDirectoryDialogFragment.RenameDirectoryKey);
                    if (bundle.GetEnum<DialogButtonType>(nameof(DialogButtonType)) == DialogButtonType.Positive)
                    {
                        var addNewDirectoryBundle = new Bundle();
                        addNewDirectoryBundle.PutExtra(nameof(WlDirectory), directory);
                        ParentFragmentManager.SetFragmentResult(AddNewDirectoryKey, addNewDirectoryBundle);
                    }
                });
            temp.Show(ParentFragmentManager, null);
            dialog.Hide();
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
