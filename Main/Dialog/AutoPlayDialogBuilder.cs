﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Android.Content;
using Android.Runtime;
using WordLearning.Language;
using WordLearning.Messages;

namespace WordLearning.Dialog
{
    public class AutoPlayDialogBuilder : WlAlartDialogBuilder
    {
        public AutoPlayDialogBuilder(Context context) : base(context)
        {
            Initialize(context);
        }


        private void Initialize(Context context)
        {
            SetMessage(WlMessage.AutoPlayConfirm[WlLanguageUtil.CurrentLanguage]);
            SetPositiveButton("OK", AutoPlayStart);
            SetNegativeButton("CANCEL", (s1, e1) => { });
        }


        private void AutoPlayStart(object sender, DialogClickEventArgs e)
        {
            var tokenSource = new CancellationTokenSource();
            // InvalidateOptionsMenu();
            Task.Run(() =>
            {
                while (!tokenSource.Token.IsCancellationRequested)
                {
                    //handler.Post(() => 
                    //{
                    //    txtNext_Click(new object(), new EventArgs());
                    //    if (Utility.localeWord != null)
                    //    {
                    //        ibVoice_Word_Click(new object(), new EventArgs());
                    //    }
                    //});
                    //if (Utility.localeWord != null)
                    //{
                    //    Sleep(Utility.SleepCount * 1000);
                    //}
                    //handler.Post(() => 
                    //{
                    //    if (Utility.localeMeaning != null)
                    //    {
                    //        ibVoice_Meaning_Click(new object(), new EventArgs());
                    //    }
                    //});
                    //if (Utility.localeMeaning != null)
                    //{
                    //    Sleep(Utility.SleepCount * 1000);
                    //}
                    //if(Utility.localeWord == null && Utility.localeMeaning == null) 
                    //{
                    //    Sleep(Utility.SleepCount * 1000);
                    //}
                }
            }
            , tokenSource.Token);
            //throw new NotImplementedException();
        }
    }
}