using System;
using Android.Content;
using Android.Runtime;
using WordLearning.Utility;
using AndroidX.AppCompat.App;
using Common.Utility;

namespace WordLearning.Dialog
{
    public abstract class WlAlartDialogBuilder : AlertDialog.Builder
    {
        public WlAlartDialogBuilder(Context context) : base(context)
        {
        }


        public override AlertDialog Create()
        {
            var dialog = base.Create();
            WlUtility.AddEventToEachView(dialog, this);
            return dialog;
        }
    }
}
