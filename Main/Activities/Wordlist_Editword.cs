using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using static Android.Views.View;
using Android.Views;
using System.Xml;
using WordLearning.Utility;
using WordLearning.Entry;
using WordLearning.Messages;
using WordLearning.Language;

namespace WordLearning
{
    [Activity(Label = "Wordlist_Editword", WindowSoftInputMode = SoftInput.AdjustResize)]
    public class Wordlist_Editword : CustomActivity
    {
        //EditText etxtWord, etxtMeaning;
        //int position;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //SetContentViewAndToolbar(Resource.Layout.Wordlist_Editword, Resource.Id.tbWordlist_Editword);
            //etxtWord = FindViewById<EditText>(Resource.Id.etxtWord_Wordlist_Editword);
            //etxtMeaning = FindViewById<EditText>(Resource.Id.etxtMeaning_Wordlist_Editword);
            //position = Intent.GetIntExtra("Position", 0);
            //etxtWord.Text       = ((WlUtility.CurrentEntry as WlDirectory).Entries[position] as Word).Wordname;
            //etxtMeaning.Text    = ((WlUtility.CurrentEntry as WlDirectory).Entries[position] as Word).Wordmeaning;
            //WlUtility.WordNumber = position;
            //etxtWord.RequestFocus();
        }

        #region Wordlist_Editword
        /// <summary>
        /// Click register button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnRegister_Wordlist_Editword_Click(object sender, EventArgs e)
        {
            //string etxtWord = this.etxtWord.Text;
            //string etxtMeaning = this.etxtMeaning.Text;
            //if (string.IsNullOrEmpty(etxtWord))
            //{
            //    var dlg = new Android.Support.V7.App.AlertDialog.Builder(this);
            //    dlg.SetTitle(WlMessage.EnterWord[WlLanguageUtil.CurrentLanguage]);
            //    dlg.SetPositiveButton("OK", (_sender, _e) => { return; });
            //    dlg.Show();
            //}
            //else
            //{
            //    Registerword(etxtWord, etxtMeaning);
            //    Finish();
            //}
        }
        /// <summary>
        /// Click cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnCancel_Wordlist_Editword_Click(object sender, EventArgs e)
        {
            Finish();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void etxtWord_Wordlist_Editword_FocusChange(object sender, FocusChangeEventArgs e)
        {
            if (e.HasFocus)
            {
                Window.SetSoftInputMode(SoftInput.AdjustResize);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void etxtMeaning_Wordlist_Editword_FocusChange(object sender, FocusChangeEventArgs e)
        {
            if (e.HasFocus)
            {
                Window.SetSoftInputMode(SoftInput.AdjustResize);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
        /// <summary>
        /// Register word
        /// </summary>
        /// <param name="etxtWord"></param>
        /// <param name="etxtMeaning"></param>
        private void Registerword(string etxtWord, string etxtMeaning)
        {
            //var targetWord = (WlUtility.CurrentEntry as WordList).Entries[position] as Word;
            //targetWord.Edit(XmlConvert.EncodeLocalName(etxtWord), XmlConvert.EncodeLocalName(etxtMeaning));
        }

        public override void OnDialogResult(object result, string dialogName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}