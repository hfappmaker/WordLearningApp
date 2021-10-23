using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using WordLearning.Entry;
using WordLearning.Language;
using WordLearning.Messages;
using WordLearning.Utility;

namespace WordLearning.Dialog
{
    public class RenameDirectoryDialogBuilder : WlAlartDialogBuilder
    {
        private readonly EditText _editText;
        public RenameDirectoryDialogBuilder(AppCompatActivity context) : base(context)
        {
            _editText = new EditText(context);
            SetView(_editText);
            SetMessage(Resource.String.SetName);
            SetNegativeButton("OK", Rename);
            SetPositiveButton("CANCEL", (_, _) => { });
            SetCancelable(false);
        }


        public override AlertDialog Show()
        {
            var dialog = base.Show();
            dialog.Window.SetSoftInputMode(SoftInput.StateAlwaysVisible);
            _editText.RequestFocus();
            return dialog;
        }


        #region RenameItem
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rename(object sender, DialogClickEventArgs e)
        {
            if (WlUtility.FileNameCheck(_editText.Text, Context))
            {
                //(WlUtility.CurrentEntry as WlDirectory).DirectoryName = _editText.Text;
            }
        }
        #endregion
    }
}
