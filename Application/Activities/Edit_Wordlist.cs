﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Reactive.Disposables;
using WordLearning.Application.Activities.ActivityCore;
using WordLearning.Application.Dialog;
using WordLearning.Application.Fragment;
using WordLearning.CoreLibrary.Extension;
using WordLearning.Domain.Adapters;
using WordLearning.Domain.Entry;
using WordLearning.Domain.States;
using WordLearning.Domain.Utility;
using static Android.Widget.AdapterView;

namespace WordLearning.Application.Activities
{
    [Activity(Label = "Edit_Wordlist")]
    public class Edit_Wordlist : CustomActivity
    {
        protected override int ToolbarId { get; } = Resource.Id.flToolbar_Edit_Wordlist;


        protected override int LayoutId { get; } = Resource.Layout.Edit_Wordlist;


        private ListView _listView;


        private readonly CompositeDisposable _disposables = new();

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentViewAndToolbar<Edit_WordlistInitToolbarState>();
            _listView = FindViewById<ListView>(Resource.Id.lv_Edit_Wordlist);
            WlWordList selectedWordList = Intent.GetExtra<WlWordList>(nameof(Edit_Wordlist));
            Edit_WordListAdapter adapter = new(this, Resource.Layout.row_Latest, selectedWordList);
            _listView.Adapter = adapter;

            _disposables.Add(selectedWordList.RegisterPropertyValueChanged(nameof(WlWordList.Name), name => SupportActionBar.Title = name.ToString()));
            SupportActionBar.Title = selectedWordList.Name;
            _listView.Adapter = adapter;
        }


        protected override void NotifyToolbarStateChanged()
        {
            base.NotifyToolbarStateChanged();
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
        }

        /// <summary>
        /// Ons the key down.
        /// </summary>
        /// <returns><c>true</c>, if key down was oned, <c>false</c> otherwise.</returns>
        /// <param name="keyCode">Key code.</param>
        /// <param name="e">E.</param>
        public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            return base.OnKeyDown(keyCode, e);
        }


        #region Edit_Wordlist
        /// <summary>
        /// Click lv_Edit_Wordlist's item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void lv_Edit_Wordlist_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ToolbarState is Edit_WordlistInitToolbarState)
            {
                Bundle bundle = new();
                bundle.PutExtra(WordDialogFragment.EDIT_WORD_KEY, _listView.Adapter.GetItem<WlWord>(e.Position));
                new WordDialogFragment(bundle).Show(SupportFragmentManager, null);
            }
            else
            {
            }
        }
        /// <summary>
        /// Click lv_Edit_Wordlist's item long time 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void lv_Edit_Wordlist_ItemLongClick(object sender, ItemLongClickEventArgs e)
        {
            if (ToolbarState is Edit_WordlistInitToolbarState)
            {
                //var state = _listView.OnSaveInstanceState();
                //_listView.OnRestoreInstanceState(state);
                _listView.ChoiceMode = ChoiceMode.Multiple;
                _listView.SetItemChecked(e.Position, true);
                _listView.Selector = GetDrawable(Resource.Color.accent);
                SetToolbar<Edit_WordlistDeleteToolbarState>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Bundle bundle = new Bundle();

            switch (item.ItemId)
            {
                case Resource.Id.action_add_Edit_Wordlist_Init:
                    bundle.PutExtra(WordDialogFragment.EDIT_WORD_KEY, new WlWord(string.Empty, string.Empty, string.Empty));
                    new WordDialogFragment(bundle).Show(SupportFragmentManager, null);
                    break;
                case Resource.Id.action_delete_Edit_Wordlist_Deletemode:
                    new DeleteEntriesDialogFragment(_listView.GetAdapter<Edit_WordListAdapter>().CurrentWordList).Show(SupportFragmentManager, null);
                    break;
                case Resource.Id.action_edit_Edit_Wordlist_Init:
                    new EditTagDialogBulder(this).Show();
                    break;
                case Resource.Id.action_play_Edit_Wordlist_Init:
                    new SetLearnWordDialogBuilder(this).Show();
                    break;
                case Android.Resource.Id.Home:
                    {
                        switch (ToolbarState.ToolbarId)
                        {
                            case Resource.Id.tbEdit_Wordlist_Deletemode:
                                {
                                    _listView.ClearChoices();
                                    _listView.ChoiceMode = ChoiceMode.None;
                                    IParcelable state = _listView.OnSaveInstanceState();
                                    _listView.OnRestoreInstanceState(state);
                                    SetToolbar<Edit_WordlistInitToolbarState>();
                                    break;
                                }
                            case Resource.Id.tbEdit_Wordlist_Init:
                                Finish();
                                break;
                        }
                    }
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }



        /// <summary>
        /// Handles the event handler.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        public void MoveLearn_Wordlist(object sender, DialogClickEventArgs e)
        {
            //var currentWordList       = WlUtility.CurrentEntry as WordList;
            //WlLanguageUtil.LocaleWord      = WlLanguageUtil.GetLocale(currentWordList.VoiceLanguageWord);
            //WlLanguageUtil.LocaleMeaning   = WlLanguageUtil.GetLocale(currentWordList.VoiceLanguageMeaning);
            //WlUtility.SleepCount      = currentWordList.SleepCount.Value;
        }


        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
        }
        /// <summary>
        /// When returning from Wordlist_Addword or Wordlist_Editword
        /// </summary>
        protected override void OnRestart()
        {
            base.OnRestart();
        }


        protected override void OnPause()
        {
            base.OnPause();
        }


        protected override void OnDestroy()
        {
            _disposables.Dispose();
            base.OnDestroy();
        }


        public override void OnDialogResult(dynamic result, string dialogName)
        {
            switch (dialogName)
            {
                case nameof(WordDialogFragment):
                    result.AddTo(_listView.GetAdapter<Edit_WordListAdapter>().CurrentWordList);
                    result.Save(WlUtility.WordListPath);
                    break;
            }
        }


        #endregion
    }
}