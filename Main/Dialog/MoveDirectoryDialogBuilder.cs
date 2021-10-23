using Android.Content;
using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using WordLearning.Adapter;
using WordLearning.Language;
using WordLearning.Messages;

namespace WordLearning.Dialog
{
    public class MoveDirectoryDialogBuilder : WlAlartDialogBuilder
    {
        public MoveDirectoryDialogBuilder(AppCompatActivity context) : base(context)
        {
            LayoutInflater Inflater;
            Inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            View layout = Inflater.Inflate(Resource.Layout.Dialog_Move_Start, (ViewGroup)context.FindViewById(Resource.Id.ll_Dialog_Move_Start));
            RecyclerView listFolder = layout.FindViewById<RecyclerView>(Resource.Id.lv_Dialog_Move_Start);
            listFolder.SetLayoutManager(new LinearLayoutManager(context));
            listFolder.SetAdapter(new Start_MoveAdapter(context, Resource.Layout.row_SelectDestination));
            SetMessage(WlMessage.SelectDestination[WlLanguageUtil.CurrentLanguage]);
            SetNegativeButton(WlMessage.Moving[WlLanguageUtil.CurrentLanguage], Move);
            SetNeutralButton("CANCEL", (_s, _e) => {});
            SetView(layout);
            SetCancelable(false);
        }


        public override AlertDialog Show()
        {
            var dialog = base.Show();
            dialog.Window.SetSoftInputMode(SoftInput.StateAlwaysVisible);
            return dialog;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Move(object sender, DialogClickEventArgs e)
        {
        }
    }
}
