using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Android.Content;
using AndroidX.AppCompat.App;
using Common.Entry;
using WordLearning.Entry;
using WordLearning.Language;
using WordLearning.Messages;
using WordLearning.Utility;

namespace WordLearning.Dialog
{
    public class IntegrateDirectoryDialogBuilder : WlAlartDialogBuilder
    {
        public IntegrateDirectoryDialogBuilder(AppCompatActivity context) : base(context)
        {
            SetMessage(WlMessage.IntegrationConfirm[WlLanguageUtil.CurrentLanguage]);
            SetPositiveButton("OK", Integrate);
            SetNegativeButton("CANCEL", (_s, _e) =>
            {
            });
        }

        /// <summary>
        /// Integrate wordlists.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void Integrate(object sender, DialogClickEventArgs e)
        {
            // var dlg = new Android.Support.V7.App.AlertDialog.Builder(Context);
            //dlg.SetMessage(WlMessage.SetName[WlLanguageUtil.CurrentLanguage]);
            //dlg.SetPositiveButton("OK", (s1, e1) =>
            //{
            //    var dlg2 = (Android.Support.V7.App.AlertDialog)s1;
            //    {
            //        var Integratelist = new List<WlEntry>();
            //        //var Newwordlist = new WlWordList(new XElement("Wordlist", new XAttribute("Name", ""), new XAttribute("SleepCount", 5), new XAttribute("VoiceLanguageWord", WlLanguage.English), new XAttribute("VoiceLanguageMeaning", WlLanguageUtil.CurrentLanguage)), null);
            //        //foreach (var entry in (WlUtility.CurrentEntry as WlDirectory).Entries.Where(entry => entry.IsChecked))
            //        //{
            //        //    Integratelist.Add(entry);
            //        //}
            //        //Integratelist.ForEach(elm =>
            //        //{
            //        //    Newwordlist.Add(elm);
            //        //    elm.Delete();
            //        //});
            //        //(WlUtility.CurrentEntry as WlDirectory).Add(Newwordlist);
            //    }
            //});
            //dlg.SetNegativeButton("CANCEL", (s1, e1) =>
            //{
            //});
            //dlg.Show();
        }
    }
}
