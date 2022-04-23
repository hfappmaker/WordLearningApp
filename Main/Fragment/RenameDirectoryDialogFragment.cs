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
        public static readonly  string RenameDirectoryKey               = nameof(RenameDirectoryKey);
        private static readonly string EditRenameDirectoryKey           = nameof(EditRenameDirectoryKey);
        public static readonly  string RenameDirectoryDialogResultKey   = nameof(RenameDirectoryDialogResultKey);


        protected TextInputEditText _directory;


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
           
            if ((DialogButtonType)e.Which == DialogButtonType.Positive)
            {
                WlDirectory directory = Arguments.GetExtra<WlDirectory>(RenameDirectoryKey);
                directory.Name = _directory.Text;
            }

            var bundle = new Bundle();
            bundle.PutEnum(nameof(DialogButtonType), (DialogButtonType)e.Which);
            ParentFragmentManager.SetFragmentResult(RenameDirectoryDialogResultKey, bundle);
            // OnDialogResult(directory);
        }
    }
}
