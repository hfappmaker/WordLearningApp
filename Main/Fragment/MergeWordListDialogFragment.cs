using Android.Content;
using Android.OS;
using Android.Views;
using AndroidX.AppCompat.App;
using Common.Visitors;
using Google.Android.Material.TextField;
using System.Linq;
using WordLearning.Entry;
using WordLearning.Fragment;

namespace WordLearning.Dialog
{
    public class MergeWordListDialogFragment : WlAlartDialogFragment
    {
        private readonly WlFolder _rootFolder;

        private TextInputEditText _wordlist;


        private const string EditMergedWordListNameKey = "MergedWordListNameKey";


        public MergeWordListDialogFragment(WlFolder rootFolder) : base()
        {
            _rootFolder = rootFolder;
        }

        /// <summary>
        /// Integrate wordlists.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        public override Android.App.Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var checkedItems = _rootFolder.Accept(new GetCheckedEntryVisitor());

            if (checkedItems.Any(item => item is not WlWordList))
            {
                AlertDialog.Builder builder = new(Activity);
                builder.SetMessage(Resource.String.SelectWordListOnly);

                builder.SetPositiveButton("OK", (_, _) =>
                {

                });

                return builder.Create();
            }

            AlertDialog.Builder mergeDialogBuilder = new(Activity);

            View layout = LayoutInflater.Inflate(Resource.Layout.Dialog_MergedWordListName, null);

            _wordlist = layout.FindViewById<TextInputEditText>(Resource.Id.etxtMergedWordListName_Dialog_MergedWordListName);

            if (savedInstanceState != null) // 画面回転時
            {
                _wordlist.Text = savedInstanceState.GetString(EditMergedWordListNameKey);
            }

            mergeDialogBuilder.SetView(layout);
            mergeDialogBuilder.SetPositiveButton("OK", (_, _) => 
            {
                var wordlist = new WlWordList(_wordlist.Text);
                foreach(WlWordList checkedItem in checkedItems.ToList())
                {
                    foreach (var word in checkedItem.ToList())
                    {
                        word.MoveTo(wordlist);
                    }

                    checkedItem.Delete();
                }

                OnDialogResult(wordlist);

            });
            return mergeDialogBuilder.Create();
        }


        public override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutString(EditMergedWordListNameKey, _wordlist.Text);
            base.OnSaveInstanceState(outState);
        }
    }
}
