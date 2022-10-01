using Android.Content;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace WordLearning.Application.Dialog
{
    public class JumpDialogBuilder : WlAlartDialogBuilder
    {
        private EditText _editText;
        public JumpDialogBuilder(Context context) : base(context)
        {
            Initialize(context);
        }


        private void Initialize(Context context)
        {
            _editText = new EditText(context)
            {
                InputType = Android.Text.InputTypes.ClassNumber
            };
            _editText.FocusChange += (s1, e1) =>
            {
                if (e1.HasFocus)
                {
                    // context.SetSoftInputMode(SoftInput.AdjustNothing);
                }
            };
            SetMessage(Resource.String.SpecifyDestination);
            SetView(_editText);
            SetPositiveButton("OK", JumpPage);
            SetNegativeButton("CANCEL", (s1, e1) => { });
        }


        public override AlertDialog Show()
        {
            AlertDialog dialog = base.Show();
            _editText.RequestFocus();
            return dialog;
        }


        /// <summary>
        /// Jumps the page.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void JumpPage(object sender, DialogClickEventArgs e)
        {
            //var dlgJump = (Android.Support.V7.App.AlertDialog)sender;
            //if (!int.TryParse(_editText.Text, out int PageNo) || PageNo < 1)
            //{
            //    var dlg = new Android.Support.V7.App.AlertDialog.Builder(Context);
            //    dlg.SetMessage(WlMessage.GetWarningPageSelect(WlLanguageUtil.CurrentLanguage));
            //    dlg.SetPositiveButton("OK", (s1, e1) => { dlgJump.Show(); });
            //    dlg.Show();
            //    return;
            //}
            //WlUtility.WordNumber = PageNo - 1;
            //RadioGroup rdog = dlgJump.FindViewById<RadioGroup>(Resource.Id.rdogSelectVisible);
            ////txtWord.Text = Utility.WordandMeanings.ElementAt(Utility.WordNumber).Value.Wordname;
            ////txtMeaning.Text = Utility.WordandMeanings.ElementAt(Utility.WordNumber).Value.Wordmeaning;
            ////SetGridLayout(Utility.WordandMeanings.ElementAt(Utility.WordNumber).Value.Tag);
            //rdog.Check(Resource.Id.rdoOnlyWord);
            ////rdogSelectVisible_CheckedChange(new object(), new CheckedChangeEventArgs(Resource.Id.rdoOnlyWord));
            //dlgJump.FindViewById<TextView>(Resource.Id.txtPrev).Visibility = ViewStates.Visible;
            //dlgJump.FindViewById<TextView>(Resource.Id.txtNext).Visibility = ViewStates.Visible;
            //if (Utility.WordNumber == 0)
            //{
            //    FindViewById<TextView>(Resource.Id.txtPrev).Visibility = ViewStates.Invisible;
            //}
            //if (Utility.WordNumber == Utility.WordandMeanings.Count - 1)
            //{
            //    FindViewById<TextView>(Resource.Id.txtNext).Visibility = ViewStates.Invisible;
            //}
            //txtPageNo.Text = Utility.WordNumber + 1 + "/" + Utility.WordandMeanings.Count;
        }
    }
}
