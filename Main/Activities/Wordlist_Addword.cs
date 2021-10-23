using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using static Android.Views.View;
using Android.Views;
using System.Xml.Linq;
using System.Xml;
using WordLearning.Utility;
using WordLearning.Entry;
using WordLearning.Messages;
using WordLearning.Language;

namespace WordLearning
{
    [Activity(Label = "Wordlist_Addword", WindowSoftInputMode = SoftInput.AdjustResize)]
    public class Wordlist_Addword : CustomActivity
    {
        EditText etxtWord, etxtMeaning;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //SetContentViewAndToolbar(Resource.Layout.Wordlist_Addword, Resource.Id.tbWordlist_Addword);
            //etxtWord = FindViewById<EditText>(Resource.Id.etxtWord_Wordlist_Addword);
            //etxtMeaning = FindViewById<EditText>(Resource.Id.etxtMeaning_Wordlist_Addword);
            //etxtWord.RequestFocus();
        }

        #region event
        /// <summary>
        /// Click register button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnRegister_Wordlist_Addword_Click(object sender, EventArgs e)
        {
            Registerword();
        }
        /// <summary>
        /// Click cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnCancel_Wordlist_Addword_Click(object sender, EventArgs e)
        {
            Finish();
        }
        /// <summary>
        /// Click register and next button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnRegister_and_Next_Wordlist_Addword_Click(object sender, EventArgs e)
        {
            if (Registerword())
            {
                Intent intent = new Intent(this, typeof(Wordlist_Addword));
                StartActivity(intent);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void etxtWord_Wordlist_Addword_FocusChange(object sender, FocusChangeEventArgs e)
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
        public void etxtMeaning_Wordlist_Addword_FocusChange(object sender, FocusChangeEventArgs e)
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
        #endregion

        #region Method
        /// <summary>
        /// Register new word
        /// </summary>
        /// <returns>true:success false: failure</returns>
        private bool Registerword()
        {
            string etxtWord = this.etxtWord.Text;
            string etxtMeaning = this.etxtMeaning.Text;
            if (string.IsNullOrEmpty(etxtWord))
            {
                var dlg = new Android.Support.V7.App.AlertDialog.Builder(this);
                dlg.SetTitle(WlMessage.EnterWord[WlLanguageUtil.CurrentLanguage]);
                dlg.SetPositiveButton("OK", (sender, e) => { return; });
                dlg.Show();
                return false;
            }
            else
            {
            //    (WlUtility.CurrentEntry as WordList).Add(
            //        new Word(new XElement("Word",
            //            new XElement("Wordname", XmlConvert.EncodeLocalName(etxtWord)),
            //            new XElement("Wordmeaning", XmlConvert.EncodeLocalName(etxtMeaning)),
            //            new XElement("Tag", "00000"),
            //            new XElement("Memo", XmlConvert.EncodeLocalName(string.Empty)))
            //        ,WlUtility.CurrentEntry));
            //    Finish();
                return true;
            }
        }

        public override void OnDialogResult(object result, string dialogName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}