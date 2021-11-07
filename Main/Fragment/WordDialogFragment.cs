using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using Common.Extension;
using Google.Android.Material.TextField;
using WordLearning.Entry;

namespace WordLearning.Fragment
{
    public class WordDialogFragment : WlAlartDialogFragment
    {
        private const string WORD_KEY = "Word";
        private const string WORD_MEANING_KEY = "WordMeaning";
        private const string MEMO_KEY = "Memo";
        protected EditText _word;
        protected EditText _wordMeaning;
        protected EditText _memo;
        public const string EDIT_WORD_KEY = "EditWord";


        public WordDialogFragment(Bundle bundle) : base(bundle)
        {
        }


        public WordDialogFragment() : base() { }


        public override Android.App.Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(Activity);

            Android.Views.View layout = LayoutInflater.Inflate(Resource.Layout.Dialog_Word, null);

            _word = layout.FindViewById<TextInputEditText>(Resource.Id.etxtWord_WordDialog);
            _wordMeaning = layout.FindViewById<TextInputEditText>(Resource.Id.etxtMeaning_WordDialog);
            _memo = layout.FindViewById<TextInputEditText>(Resource.Id.etxtMemo_WordDialog);

            WlWord editWord = Arguments.GetExtra<WlWord>(EDIT_WORD_KEY);
            _word.Text = editWord.Word;
            _wordMeaning.Text = editWord.WordMeaning;
            _memo.Text = editWord.Memo;
            if (savedInstanceState != null) // 画面回転時
            {
                _word.Text = savedInstanceState.GetString(WORD_KEY);
                _wordMeaning.Text = savedInstanceState.GetString(WORD_MEANING_KEY);
                _memo.Text = savedInstanceState.GetString(MEMO_KEY);
            }

            builder.SetView(layout);
            builder.SetNegativeButton("CANCEL", ButtonPressAction);
            builder.SetPositiveButton("OK", ButtonPressAction);
            return builder.Create();
        }


        public override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutString(WORD_KEY, _word.Text);
            outState.PutString(WORD_MEANING_KEY, _wordMeaning.Text);
            outState.PutString(MEMO_KEY, _memo.Text);
            base.OnSaveInstanceState(outState);
        }


        public override void OnDestroy()
        {
            base.OnDestroy();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPressAction(object sender, DialogClickEventArgs e)
        {
            WlWord editWord = Arguments.GetExtra<WlWord>(EDIT_WORD_KEY);
            if ((DialogButtonType)e.Which == DialogButtonType.Negative)
            {
                return;
            }

            editWord.Word = _word.Text;
            editWord.WordMeaning = _wordMeaning.Text;
            editWord.Memo = _memo.Text;
            OnDialogResult(editWord);
        }
    }
}
