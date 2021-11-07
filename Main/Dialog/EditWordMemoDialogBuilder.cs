using Android.Content;
using Android.Views;
using Android.Widget;
using WordLearning.Language;
using WordLearning.Messages;

namespace WordLearning.Dialog
{
    internal class EditWordMemoDialogBuilder : WlAlartDialogBuilder
    {
        public EditWordMemoDialogBuilder(Context context) : base(context)
        {
            Initialize(context);
        }


        private void Initialize(Context context)
        {
            LayoutInflater inflater = LayoutInflater.From(context);

            EditText memo = new EditText(context);
            memo.SetMaxHeight(70 * 4);
            SetMessage(WlMessage.InputMemo[WlLanguageUtil.CurrentLanguage]);
            SetView(memo);
            SetPositiveButton("OK", (s1, e1) => { });
            SetNegativeButton("CANCEL", (s1, e1) => { });
            memo.FocusChange += (s1, e1) => { };
            memo.RequestFocus();
        }
    }
}
