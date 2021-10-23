using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Linq;
using static Android.Widget.RadioGroup;
using Android.Views;
using static Android.Views.GestureDetector;
using Android.Runtime;
using Android.Graphics;
using Android.Content;
using Android.Speech.Tts;
using Android.Views.InputMethods;
using System.Threading;
using WordLearning.Dialog;
using WordLearning.Utility;
using WordLearning.Colors;
using WordLearning.Messages;
using WordLearning.Language;

namespace WordLearning.Activities
{
    [Activity(Label = "Learn_Wordlist")]
    public class Learn_Wordlist : CustomActivity, TextToSpeech.IOnInitListener
    {
        protected override int ToolbarId { get; } = Resource.Id.flToolbar_Learn_Wordlist;

        protected override int LayoutId { get; } = Resource.Layout.Learn_Wordlist;


        private GestureDetector mGestureDetector;
        private GestureListener mOnGestureListener;
        TextToSpeech ttsword,ttsmeaning;
        TextView txtWord;
        TextView txtMeaning;
        TextView txtPageNo;
        GridLayout gridLayout;
        private bool IsAutomode = false;
        CancellationTokenSource tokenSource = new ();
        Handler handler = new (handler:null);
        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // SetContentViewAndToolbar();
            GetWordandMeanings();
            mOnGestureListener = new GestureListener(this);
            mGestureDetector = new GestureDetector(this, mOnGestureListener);
            txtWord = FindViewById<TextView>(Resource.Id.txtWord);
            txtMeaning = FindViewById<TextView>(Resource.Id.txtMeaning);
            //var currentWord = WlUtility.CurrentEntry as Word;
            //txtWord.Text = currentWord.Wordname;
            //txtMeaning.Text = currentWord.Wordmeaning;
            txtPageNo = FindViewById<TextView>(Resource.Id.txtPageNo);
            //txtPageNo.Text = "1/" + currentWordlist.CurrentEntries.Count();
            gridLayout = FindViewById<GridLayout>(Resource.Id.gl_Taglist_Learn_Wordlist);
            // SetGridLayout(Utility.WordandMeanings.First().Value.Tag);
            ttsword = new TextToSpeech(this, this);
            ttsmeaning = new TextToSpeech(this, this);
            ImageButton voicebtn_word = FindViewById<ImageButton>(Resource.Id.ibVoice_Word);
            ImageButton voicebtn_meaning = FindViewById<ImageButton>(Resource.Id.ibVoice_Meaning);
            ImageButton memobtn = FindViewById<ImageButton>(Resource.Id.ibMemo);
            voicebtn_word.SetColorFilter(ThemeColor.Color, PorterDuff.Mode.SrcIn);
            voicebtn_meaning.SetColorFilter(ThemeColor.Color,PorterDuff.Mode.SrcIn);
            memobtn.SetColorFilter(ThemeColor.Color, PorterDuff.Mode.SrcIn);
            // WlUtility.WordNumber = 0;
            rdogSelectVisible_CheckedChange(new object(), new CheckedChangeEventArgs(Resource.Id.rdoOnlyWord));
        }
        /// <summary>
        /// Gets the wordand meanings.
        /// </summary>
        private void GetWordandMeanings()
        {
            //switch(Intent.GetIntExtra("RadioButton", Resource.Id.rdoAscendant))
            //{
                //case Resource.Id.rdoAscendant:
                //    Utility.WordandMeanings = Utility.WordandMeanings.OrderBy(p => p.Value.Wordname).ToDictionary(p => p.Key,p=>p.Value);
                //    break;
                //case Resource.Id.rdoDescendant:
                //    Utility.WordandMeanings = Utility.WordandMeanings.OrderByDescending(p => p.Value.Wordname).ToDictionary(p => p.Key, p => p.Value);
                //    break;
                //case Resource.Id.rdoRandomize:
                //    Utility.WordandMeanings = Utility.WordandMeanings.OrderBy(p => Guid.NewGuid()).ToDictionary(p => p.Key, p => p.Value);
                //    break;
            //}
        }

        /// <summary>
        /// Sets the grid layout.
        /// </summary>
        private void SetGridLayout(string Tag)
        {
            if (gridLayout.ChildCount != 0)
            {
                gridLayout.RemoveViews(0, gridLayout.ChildCount);
            }

            foreach(var pair in TagColorCollection.Instance.Select((TagColor, Index) => (TagColor, Index)))
            {
                var imageView = new ImageView(ApplicationContext);
                var drawable = GetDrawable((int)pair.TagColor.Shape);
                drawable.Mutate();
                drawable.SetColorFilter(new BlendModeColorFilter(pair.TagColor.WlColor, BlendMode.Multiply));
                imageView.SetImageDrawable(drawable);
                var param = new GridLayout.LayoutParams
                {
                    RowSpec = GridLayout.InvokeSpec(pair.Index),
                    ColumnSpec=GridLayout.InvokeSpec(0)
                };
                imageView.LayoutParameters = param;
                gridLayout.AddView(imageView);
            }
        }
        /// <summary>
        /// Ons the key down.
        /// </summary>
        /// <returns><c>true</c>, if key down was oned, <c>false</c> otherwise.</returns>
        /// <param name="keyCode">Key code.</param>
        /// <param name="e">E.</param>
        public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.Back)
            {

            }
            return base.OnKeyDown(keyCode, e);
        }
        /// <summary>
        /// When radiobox's check is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void rdogSelectVisible_CheckedChange(object sender, CheckedChangeEventArgs e)
        {
            txtWord.Visibility = ViewStates.Visible;
            txtMeaning.Visibility = ViewStates.Visible;
            switch (e.CheckedId)
            {
                case Resource.Id.rdoOnlyWord:
                    txtMeaning.Visibility = ViewStates.Invisible;
                    break;
                case Resource.Id.rdoOnlyMeaning:
                    txtWord.Visibility = ViewStates.Invisible;
                    break;
            }
        }
        /// <summary>
        /// Click txtPrev
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void txtPrev_Click(object sender, EventArgs e)
        {
            RadioGroup rdog = FindViewById<RadioGroup>(Resource.Id.rdogSelectVisible);
            //Utility.WordNumber--;
            //if(Utility.WordNumber < 0) 
            //{
            //    Utility.WordNumber = Utility.WordandMeanings.Count - 1;
            // }
            //txtWord.Text = Utility.WordandMeanings.ElementAt(Utility.WordNumber).Value.Wordname;
            //txtMeaning.Text = Utility.WordandMeanings.ElementAt(Utility.WordNumber).Value.Wordmeaning;
            //SetGridLayout(Utility.WordandMeanings.ElementAt(Utility.WordNumber).Value.Tag);
            rdog.Check(Resource.Id.rdoOnlyWord);
            rdogSelectVisible_CheckedChange(new object(), new CheckedChangeEventArgs(Resource.Id.rdoOnlyWord));
            //txtPageNo.Text = Utility.WordNumber + 1 + "/" + Utility.WordandMeanings.Count;
        }
        /// <summary>
        /// Click txtNext
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void txtNext_Click(object sender, EventArgs e)
        {
            RadioGroup rdog = FindViewById<RadioGroup>(Resource.Id.rdogSelectVisible);
            //Utility.WordNumber++;
            //if(Utility.WordNumber == Utility.WordandMeanings.Count) 
            //{
            //    Utility.WordNumber = 0;
            // }
            //txtWord.Text = Utility.WordandMeanings.ElementAt(Utility.WordNumber).Value.Wordname;
            //txtMeaning.Text = Utility.WordandMeanings.ElementAt(Utility.WordNumber).Value.Wordmeaning;
            //SetGridLayout(Utility.WordandMeanings.ElementAt(Utility.WordNumber).Value.Tag);
            if (IsAutomode)
            {
                rdog.Check(Resource.Id.rdoBoth);
                rdogSelectVisible_CheckedChange(new object(), new CheckedChangeEventArgs(Resource.Id.rdoBoth));
            }
            else
            {
                rdog.Check(Resource.Id.rdoOnlyWord);
                rdogSelectVisible_CheckedChange(new object(), new CheckedChangeEventArgs(Resource.Id.rdoOnlyWord));
            }
            //txtPageNo.Text = Utility.WordNumber + 1 + "/" + Utility.WordandMeanings.Count;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override bool OnTouchEvent(MotionEvent e)
        {
            if(e.Action == MotionEventActions.Down)
            {

            }
            else if(e.Action == MotionEventActions.Move)
            {

            }
            bool result = mGestureDetector.OnTouchEvent(e);
            if (e.Action == MotionEventActions.Up)
            {
                RadioGroup rdog = FindViewById<RadioGroup>(Resource.Id.rdogSelectVisible);
                if (!rdog.Selected && e.EventTime - e.DownTime > 50 && !result)
                {
                    switch (rdog.CheckedRadioButtonId)
                    {
                        case Resource.Id.rdoBoth:
                            rdog.Check(Resource.Id.rdoOnlyWord);
                            rdogSelectVisible_CheckedChange(new object(), new CheckedChangeEventArgs(Resource.Id.rdoOnlyWord));
                            break;
                        case Resource.Id.rdoOnlyWord:
                            rdog.Check(Resource.Id.rdoOnlyMeaning);
                            rdogSelectVisible_CheckedChange(new object(), new CheckedChangeEventArgs(Resource.Id.rdoOnlyMeaning));
                            break;
                        case Resource.Id.rdoOnlyMeaning:
                            rdog.Check(Resource.Id.rdoBoth);
                            rdogSelectVisible_CheckedChange(new object(), new CheckedChangeEventArgs(Resource.Id.rdoBoth));
                            break;
                    }
                }
            }
            return result;          
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
                case Resource.Id.action_edit_Learn_Wordlist:
                    if (IsAutomode) break;
                    new EditWordTagDialogBuilder(ApplicationContext).Show();
                    break;
                case Resource.Id.action_jump_Learn_Wordlist:
                    if (IsAutomode) break;
                    new JumpDialogBuilder(ApplicationContext).Show();
                    break;
                case Resource.Id.action_auto_Learn_Wordlist:
                    new AutoPlayDialogBuilder(ApplicationContext).Show();
                    break;
                case Resource.Id.action_pause_Learn_Wordlist:
                    IsAutomode = false;
                    InvalidateOptionsMenu();
                    tokenSource.Cancel();
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            base.OnPrepareOptionsMenu(menu);
            var auto = menu.FindItem(Resource.Id.action_auto_Learn_Wordlist);
            var pause = menu.FindItem(Resource.Id.action_pause_Learn_Wordlist);
            auto.SetVisible(!IsAutomode);
            pause.SetVisible(IsAutomode);
            return true;
        }
        


        /// <summary>
        /// Sets the tagof word.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void SetTagofWord(object sender, DialogClickEventArgs e)
        {
            // Android.Support.V7.App.AlertDialog dlgEditTagofWord = (Android.Support.V7.App.AlertDialog)sender;
            //Utility.cd.Add((int)lv.GetTag(Constant.FreeTagKey));
            //XElement Word_xml = Utility.GetXElement(Utility.cd, xml);
            {
                //Word_xml.Element("Tag").Value = Word_xml.Element("Tag").Value.Substring(0, (int)lv.GetTag(i + 0x7000000)) + Convert.ToInt32(tagselectlist[i].Item5).ToString() + Word_xml.Element("Tag").Value.Substring((int)lv.GetTag(i + 0x7000000) + 1);
            }
            //Utility.WordandMeanings[Utility.WordandMeanings.ElementAt(Utility.WordNumber).Key] = new ValueTuple<string, string, string,string>
            //(Utility.WordandMeanings.ElementAt(Utility.WordNumber).Value.Wordname,
            // Utility.WordandMeanings.ElementAt(Utility.WordNumber).Value.Wordmeaning,
            // Word_xml.Element("Tag").Value,
            // Utility.WordandMeanings.ElementAt(Utility.WordNumber).Value.Memo);
            //Utility.cd.RemoveAt(Utility.cd.Count - 1);
            //SetGridLayout(Utility.WordandMeanings.ElementAt(Utility.WordNumber).Value.Tag);
        }

        public void OnInit([GeneratedEnum] OperationResult status)
        {
            //ttsword.SeWlLanguage.Utility.localeWord);
            //ttsmeaning.SeWlLanguage.Utility.localeMeaning);
        }

        public void ibVoice_Word_Click(object sender,EventArgs e)
        {
            ttsword.Speak(txtWord.Text, QueueMode.Flush,null,"Word");
        }

        public void ibVoice_Meaning_Click(object sender, EventArgs e)
        {
            ttsmeaning.Speak(txtMeaning.Text, QueueMode.Flush, null, "Meaning");
        }

        public void ibMemo_Click(object sender, EventArgs e)
        {
            if (IsAutomode) return;
            //var dlgMemo = new Android.Support.V7.App.AlertDialog.Builder(this) 
            {

            };
            EditText textView = new EditText(this)
            {
               // Text = (WlUtility.CurrentEntry as Word).Memo,
            };
            textView.SetMaxHeight(120 * 4);　//2019.03.24 add
            textView.Focusable = false;
            textView.LongClickable = false;
            //dlgMemo.SetTitle(WlMessage.Memo[WlLanguageUtil.CurrentLanguage]);
            //dlgMemo.SetPositiveButton("OK", (s1, e1) =>
            //{
            //    //var targetWord = WlUtility.CurrentEntry as Word;
            //    //targetWord.Memo = XmlConvert.EncodeLocalName(textView.Text);
            //});
            //dlgMemo.SetNegativeButton("CANCEL", (s1, e1) => { });
            //dlgMemo.SetNeutralButton("EDIT", (s1,e1) => { });
            //dlgMemo.SetView(textView);
            //var dlgMemoins = dlgMemo.Create();
            //dlgMemoins.Show();
            //var neutralbtn = dlgMemoins.GetButton((int)DialogButtonType.Neutral);
            //neutralbtn.Click += (s1, e1) =>
            //{
            //    textView.Focusable = true;
            //    textView.FocusableInTouchMode = true;
            //    textView.LongClickable = true;
            //    textView.RequestFocus();
            //    var imm = GetSystemService(InputMethodService) as InputMethodManager;
            //    imm.ShowSoftInput(textView, ShowFlags.Implicit);
            //};
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnRestart()
        {
            base.OnRestart();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnStop()
        {
            base.OnStop();
        }

        public override void OnDialogResult(object result, string dialogName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public class GestureListener : SimpleOnGestureListener
        {
            private const int SWIPE_THRESHOLD = 100;
            private const int SWIPE_VELOCITY_THRESHOLD = 100;
            private Learn_Wordlist learn_Wordlist;
            
            public GestureListener(Learn_Wordlist learn_Wordlist)
            {
                this.learn_Wordlist = learn_Wordlist;
            }
            public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
            {
                bool result = false;

                float diffY = e2.GetY() - e1.GetY();
                float diffX = e2.GetX() - e1.GetX();
                if (Math.Abs(diffX) > Math.Abs(diffY))
                {
                    if (Math.Abs(diffX) > SWIPE_THRESHOLD && Math.Abs(velocityX) > SWIPE_VELOCITY_THRESHOLD)
                    {
                        if (diffX > 0)
                        {
                            OnSwipeRight();
                        }
                        else
                        {
                            OnSwipeLeft();
                        }
                        result = true;
                    }
                }
                else if (Math.Abs(diffY) > SWIPE_THRESHOLD && Math.Abs(velocityY) > SWIPE_VELOCITY_THRESHOLD)
                {
                    if (diffY > 0)
                    {
                        OnSwipeBottom();
                    }
                    else
                    {
                        OnSwipeTop();
                    }
                    result = true;
                }
                return result;
            }

            /// <summary>
            /// 
            /// </summary>
            public void OnSwipeRight()
            {
                learn_Wordlist.txtPrev_Click(new object(), new EventArgs());
            }
            /// <summary>
            /// 
            /// </summary>
            public void OnSwipeLeft()
            {
                learn_Wordlist.txtNext_Click(new object(), new EventArgs());
            }

            private void OnSwipeTop()
            {

            }

            private void OnSwipeBottom()
            {

            }
        }

    }
}