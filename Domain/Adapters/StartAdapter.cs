using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Subjects;
using WordLearning.Domain.Colors;
using WordLearning.Domain.Entry;
using WordLearning.CoreLibrary.Extension;
using WordLearning.Domain.Entry.EntryCore;
using WordLearning.Domain.Adapters.AdapterCore;

namespace WordLearning.Domain.Adapters
{
    /// <summary>
    /// Array adapter start.
    /// </summary>
    public class StartAdapter : CustomArrayAdapter<WlDirectory>
    {
        private CompositeDisposable _folderDisposable = new();
        private readonly CompositeDisposable _adapterDisposable = new();
        private CompositeDisposable _itemDisposable = new();

        private WlFolder _currentFolder;
        public WlFolder CurrentFolder
        {
            get => _currentFolder;
            set
            {
                if (_currentFolder == value) return;
                _currentFolder = value;
                _folderChanged.OnNext(value);
            }
        }

        private readonly Subject<WlFolder> _folderChanged = new();

        public StartAdapter(AppCompatActivity context, int resource, WlFolder folder) : base(context, resource, folder)
        {
            _adapterDisposable.Add(_folderChanged.Subscribe(value =>
            {
                _folderDisposable.Dispose();
                _folderDisposable = new();
                _folderDisposable.Add(value.RegisterCollectionChanged((entries, e) =>
                {
                    NotifyDataSetChanged(entries);
                }));

                NotifyDataSetChanged(value);
            }));

            CurrentFolder = folder;
        }


        private void NotifyDataSetChanged(IEnumerable<WlEntry> newItems)
        {
            _itemDisposable.Dispose();
            _itemDisposable = new();
            foreach (WlEntry entry in newItems)
            {
                _itemDisposable.Add(entry.RegisterCheckedChanged(isChecked =>
                {
                    NotifyDataSetChanged();
                }));
            }

            Clear();
            AddAll(newItems.ToList());
            NotifyDataSetChanged();
        }

        public IDisposable SubscribeFolderChangedObservable(Action<WlFolder> folderChangedAction)
        {
            IDisposable disposeble = _folderChanged.Subscribe(folderChangedAction);
            _folderChanged.OnNext(CurrentFolder);
            return disposeble;
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view;
            bool isConvertView = convertView != null;
            if (isConvertView)
            {
                view = convertView;
            }
            else
            {
                view = Inflater.Inflate(LayoutID, null);
                view.SetPaddingRelative(48, 48, 48, 48);
            }

            WlDirectory item = this.GetItem<WlDirectory>(position);
            TextView textView = view.FindViewById<TextView>(Resource.Id.tvRow_Explorer);
            ImageView imageView = view.FindViewById<ImageView>(Resource.Id.ivRow_Explorer);
            ImageButton imageButton = view.FindViewById<ImageButton>(Resource.Id.ibRow_Explorer);
            textView.Text = item.Name;
            switch (item.EntryType)
            {
                case nameof(WlFolder):
                    imageView.SetImageResource(Resource.Drawable.ic_folder2_48pt);
                    break;
                case nameof(WlWordList):
                    imageView.SetImageResource(Resource.Drawable.ic_wordlist2_48pt);
                    if (!isConvertView)
                    {
                        imageButton.Click += ImageButton_Click;
                    }
                    break;
            }
            imageView.SetColorFilter(ThemeColor.Color);
            imageView.Visibility = ViewStates.Visible;
            imageButton.Visibility = ViewStates.Invisible;
            view.SetBackgroundColor(WlColorUtil.GetSelectColor(item.IsChecked));

            return view;
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            // ImageButton imageButton = sender as ImageButton;
            //Utility.CurrentEntiry = (Utility.CurrentEntry as WlDirectory).Entries[int.Parse(imageButton.GetTag(Constant.FreeTagKey2).ToString())];
            //LayoutInflater inflater = LayoutInflater.From(start);
            //View view = inflater.Inflate(Resource.Layout.Dialog_SettingWordlist, null);
            //EditText edittext = view.FindViewById<EditText>(Resource.Id.etxtInterval_Dialog_SettingWordlist);
            //var dlg = new Android.Support.V7.App.AlertDialog.Builder(start);
            //Spinner spinnerWord     = view.FindViewById<Spinner>(Resource.Id.spChooselanguageWord_Dialog_SettingWordlist);
            //Spinner spinnerMeaning  = view.FindViewById<Spinner>(Resource.Id.spChooselanguageMeaning_Dialog_SettingWordlist);
            //spinnerWord.Adapter     = new ArrayAdapter(start, Android.Resource.Layout.SimpleSpinnerItem, Utility.Localedict.Keys.ToList());
            //spinnerMeaning.Adapter  = new ArrayAdapter(start,Android.Resource.Layout.SimpleSpinnerItem,Utility.Localedict.Keys.ToList());
            //spinnerMeaning.SetSelection(Utility.Localedict.Keys.ToList().IndexOf(WlLanguage.日本語));
            //edittext.Text = "5";
            //var currentWordList = WlUtility.CurrentEntry as WordList;
            //if (currentWordList.SleepCount != null)
            //{
            //    edittext.Text = currentWordList.SleepCount.ToString();
            //}
            //if (currentWordList.VoiceLanguageWord != WlLanguage.None)
            {
                //if (WlLocale.Keys.ToList().Contains(currentWordList.VoiceLanguageWord))
                //{
                //    //spinnerWord.SetSelection(Utility.Localedict.Keys.ToList().IndexOf(currentWordList.VoiceLanguageWord));
                //}
            }
            //if (currentWordList.VoiceLanguageMeaning != WlLanguage.None)
            {
                //if (WlUtility.Localedict.Keys.ToList().Contains(currentWordList.VoiceLanguageMeaning))
                //{
                //    //spinnerMeaning.SetSelection(Utility.Localedict.Keys.ToList().IndexOf(currentWordList.VoiceLanguageMeaning));
                //}
            }
            //dlg.SetView(view);
            //dlg.SetPositiveButton("OK", (s1, e1) => {
            //    //Utility.CurrentEntry = (Utility.CurrentEntry as WlDirectory).Entries[int.Parse(imageButton.GetTag(Constant.FreeTagKey2).ToString())];
            //    int SleepCount = 5;
            //    if (view.FindViewById<EditText>(Resource.Id.etxtInterval_Dialog_SettingWordlist).Text != string.Empty)
            //    {
            //        int.TryParse(view.FindViewById<EditText>(Resource.Id.etxtInterval_Dialog_SettingWordlist).Text, out SleepCount);
            //    }
            //    //string voiceLanguageWord = view.FindViewById<Spinner>(Resource.Id.spChooselanguageWord_Dialog_SettingWordlist).SelectedItem.ToString();
            //    //string voiceLanguageMeaning = view.FindViewById<Spinner>(Resource.Id.spChooselanguageMeaning_Dialog_SettingWordlist).SelectedItem.ToString();
            //    if (SleepCount > 60 || SleepCount < 1)
            //    {
            //        if (SleepCount > 60) SleepCount = 60;
            //        if (SleepCount < 1) SleepCount = 1;
            //    }
            //    var currentWordList = WlUtility.CurrentEntry as WordList;
            //    view.FindViewById<EditText>(Resource.Id.etxtInterval_Dialog_SettingWordlist).Text = SleepCount.ToString();
            //    WlUtility.CurrentEntry = WlUtility.CurrentEntry.Parent;
            //});
            //dlg.SetNegativeButton("CANCEL", (s1, e1) => { });
            //dlg.Show();
            //WlUtility.CurrentEntry = WlUtility.CurrentEntry.Parent;
        }


        public new void Dispose()
        {
            _folderDisposable?.Dispose();
            _adapterDisposable.Dispose();
            base.Dispose();
        }
    }
}
