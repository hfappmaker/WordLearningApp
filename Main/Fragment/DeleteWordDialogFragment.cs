using Android.Content;
using Android.OS;
using AndroidX.AppCompat.App;
using WordLearning.Language;
using WordLearning.Messages;

namespace WordLearning.Fragment
{
    public class DeleteWordDialogFragment : WlAlartDialogFragment
    {
        public const string TARGET_WORDLIST = "TargetWordlist";


        public DeleteWordDialogFragment() : base()
        {
        }


        public override Android.App.Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(Activity);
            builder.SetMessage(WlMessage.DeleteWordConfirm[WlLanguageUtil.CurrentLanguage]);
            builder.SetNegativeButton("CANCEL", (_, _) => { });
            builder.SetPositiveButton("OK", Delete);
            return builder.Create();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete(object sender, DialogClickEventArgs e)
        {
            // WlUtility.RootFolder.Accept(new DeleteCheckedEntryVisitor());
            OnDialogResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, DialogClickEventArgs e)
        {
        }
    }
}
