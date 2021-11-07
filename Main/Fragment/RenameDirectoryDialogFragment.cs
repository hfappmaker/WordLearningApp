using Android.Content;
using Android.OS;
using Android.Views;
using AndroidX.AppCompat.App;
using Common.Entry;
using Common.Extension;
using Google.Android.Material.TextField;
using WordLearning.Fragment;

namespace WordLearning.Dialog
{
    public class RenameDirectoryDialogFragment : WlAlartDialogFragment
    {
        public const string RenameDirectoryKey = "RenameDirectoryKey";
        private const string EditRenameDirectoryKey = "EditRenameDirectoryKey";


        protected TextInputEditText _directory;
        public RenameDirectoryDialogFragment() : base()
        {
        }

        public RenameDirectoryDialogFragment(Bundle bundle) : base(bundle)
        {
        }


        public override Android.App.Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(Activity);

            View layout = LayoutInflater.Inflate(Resource.Layout.Dialog_DirectoryName, null);

            _directory = layout.FindViewById<TextInputEditText>(Resource.Id.etxtDirectoryName_Dialog_DirectoryName);

            WlDirectory directory = Arguments.GetExtra<WlDirectory>(RenameDirectoryKey);
            _directory.Text = directory.Name;
            if (savedInstanceState != null) // 画面回転時
            {
                _directory.Text = savedInstanceState.GetString(EditRenameDirectoryKey);
            }

            builder.SetView(layout);
            builder.SetNegativeButton("CANCEL", ButtonPressAction);
            builder.SetPositiveButton("OK", ButtonPressAction);
            return builder.Create();
        }


        public override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutString(EditRenameDirectoryKey, _directory.Text);
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
            WlDirectory directory = Arguments.GetExtra<WlDirectory>(RenameDirectoryKey);
            if ((DialogButtonType)e.Which == DialogButtonType.Negative)
            {
                return;
            }

            directory.Name = _directory.Text;
            OnDialogResult(directory);
        }
    }
}
