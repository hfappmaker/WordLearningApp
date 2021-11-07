using Android.Content;

namespace WordLearning.Dialog
{
    internal class SetLearnWordDialogBuilder : WlAlartDialogBuilder
    {
        public SetLearnWordDialogBuilder(Context context) : base(context)
        {
            Initialize(context);
        }

        private void Initialize(Context context)
        {
            //var inflater = LayoutInflater.From(context);
            //var view = inflater.Inflate(Resource.Layout.Dialog_SetLearnWord, null);
            //var Wordlist = WlUtility.CurrentEntry as WordList;
            //if (Wordlist.Entries.Count() > 0)
            //{
            //    var TagList = view.FindViewById<ListView>(Resource.Id.lvTagList_Dialog_SetLearnWord);
            //    TagList.Adapter = new SelectedTagAdapter(context, Resource.Layout.row_SelectedTag);
            //    SetView(view);
            //    SetNegativeButton("OK", MoveLearn_Wordlist);
            //    SetPositiveButton("CANCEL", (_, _) => { });
            //}
            //else
            //{
            //    SetMessage(WlMessage.NoRegisteredWord[WlLanguageUtil.CurrentLanguage]);
            //    SetPositiveButton("OK", (_, _) => { return; });
            //}
        }


        private void MoveLearn_Wordlist(object sender, DialogClickEventArgs e)
        {

        }
    }
}
