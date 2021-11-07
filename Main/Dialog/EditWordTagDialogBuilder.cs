using Android.Content;
using Android.Views;
using Android.Widget;
using WordLearning.Adapter;

namespace WordLearning.Dialog
{
    public class EditWordTagDialogBuilder : WlAlartDialogBuilder
    {
        public EditWordTagDialogBuilder(Context context) : base(context)
        {
            Initialize(context);
        }


        private void Initialize(Context context)
        {
            LayoutInflater inflater = LayoutInflater.From(context);
            View view = inflater.Inflate(Resource.Layout.Dialog_CreateNewTag, null);
            ListView selectedTag = new ListView(context)
            {
                Adapter = new SelectedTagAdapter(context, Resource.Layout.row_SelectedTag),
                ChoiceMode = ChoiceMode.Multiple
            };
            SetNegativeButton("OK", SetTagOfWord);
            SetPositiveButton("CANCEL", (s3, e3) => { return; });
        }


        private void SetTagOfWord(object sender, DialogClickEventArgs e)
        {
            // Android.Support.V7.App.AlertDialog dlgEditTagofWord = (Android.Support.V7.App.AlertDialog)sender;
        }
    }
}
