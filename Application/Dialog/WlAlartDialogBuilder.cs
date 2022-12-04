using Android.Content;
using AndroidX.AppCompat.App;
using WordLearning.Domain.Utility;

namespace WordLearning.Application.Dialog
{
    public abstract class WlAlartDialogBuilder : AlertDialog.Builder
    {
        public WlAlartDialogBuilder(Context context) : base(context)
        {
        }


        public override AlertDialog Create()
        {
            AlertDialog dialog = base.Create();
            WlUtility.AddEventToEachView(dialog, this);
            return dialog;
        }
    }
}
