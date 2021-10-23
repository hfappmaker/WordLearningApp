﻿using Android.App;
using Android.OS;
using System.Collections.Generic;
using Android.Content;
using static Android.Widget.AdapterView;
using Android.Views;
using System;
using Android.Util;
using Android.Runtime;
using Firebase.Iid;
using Android.Gms.Common;
using WordLearning.Utility;
using WordLearning.Entry;
using WordLearning.Adapter;
using WordLearning.Language;
using WordLearning.Messages;
using Android.Widget;
using WordLearning.Fragment;
using Common.Entry;
using System.Reactive.Disposables;
using Common.Extension;
using WordLearning.States;
using WordLearning.Dialog;

namespace WordLearning.Activities
{
    [Activity(Label = "@string/app_name", MainLauncher = true, LaunchMode = Android.Content.PM.LaunchMode.SingleTop)]
    public class Start : CustomActivity
    {
        protected override int ToolbarId { get; } = Resource.Id.flToolbar_Start;

        protected override int LayoutId { get; } = Resource.Layout.Start;

        private static readonly string CHANNEL_ID = "my_notification_channel";

        private static readonly string CURRENT_FOLDER_KEY = "CurrentFolderKey";

        private ListView _listView;

        private readonly CompositeDisposable _disposables = new();
        /// <summary>
        /// Run Method
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentViewAndToolbar<StartInitToolbarState>();
            _listView = FindViewById<ListView>(Resource.Id.lv_Start);
            StartAdapter adapter;
            if (savedInstanceState == null)
            {
                adapter = new StartAdapter(this, Resource.Layout.row_Explorer, WlUtility.RootFolder);
            }
            else
            {
                var currentFolder = savedInstanceState.GetExtra<WlFolder>(CURRENT_FOLDER_KEY);
                adapter = new StartAdapter(this, Resource.Layout.row_Explorer, currentFolder);
            }

            IDisposable disposable = null;

            _disposables.Add(adapter.SubscribeFolderChangedObservable(value =>
            {
                disposable?.Dispose();
                SupportActionBar.Title = value.Name;
                SupportActionBar.SetDisplayHomeAsUpEnabled(value != WlUtility.RootFolder);
                SupportActionBar.SetHomeButtonEnabled(value != WlUtility.RootFolder);
                disposable = value.RegisterPropertyValueChanged(nameof(WlFolder.Name),
                                name => SupportActionBar.Title = name);
            }));

            _listView.Adapter = adapter;

            IsPlayServicesAvailable();
            CreateNotificationChannel();
        }


        private void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var channel = new NotificationChannel(CHANNEL_ID,
                                                  "FCM Notifications",
                                                  NotificationImportance.Default)
            {
                Description = "Firebase Cloud Messages appear in this channel"
            };

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
        }


        protected override void NotifyToolbarStateChanged()
        {
            base.NotifyToolbarStateChanged();
        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            bool isVisible = ToolbarState is StartDeleteToolbarState
                || _listView.GetAdapter<StartAdapter>().CurrentFolder != WlUtility.RootFolder;
            SupportActionBar.SetDisplayHomeAsUpEnabled(isVisible);
            SupportActionBar.SetHomeButtonEnabled(isVisible);
            return base.OnCreateOptionsMenu(menu);
        }


        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutExtra(CURRENT_FOLDER_KEY, _listView.GetAdapter<StartAdapter>().CurrentFolder);
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
        }

        protected override void OnDestroy()
        {
            _disposables.Dispose();
            base.OnDestroy();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnResume()
        {
            base.OnResume();
            IsPlayServicesAvailable();
        }

        protected override void OnStop()
        {
            base.OnStop();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        #region event

        #region listview click
        /// <summary>
        /// When lv_Register's item is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void lv_Start_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ToolbarState is StartDeleteToolbarState)
            {
                _listView.GetItem<WlEntry>(e.Position).ChangeCheck();
                return;
            }
            var adapter = _listView.Adapter as StartAdapter;
            var selectedDirectory = adapter.CurrentFolder[e.Position] as WlDirectory;
            switch (selectedDirectory.EntryType)
            {
                case nameof(WlFolder):
                    adapter.CurrentFolder = selectedDirectory as WlFolder;
                    break;
                case nameof(WlWordList):
                    var intent = new Intent(this, typeof(Edit_Wordlist));
                    intent.PutExtra(nameof(Edit_Wordlist), selectedDirectory);
                    StartActivity(intent);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// When lv_Register's item is clicked long time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void lv_Start_ItemLongClick(object sender, ItemLongClickEventArgs e)
        {
            if (ToolbarState is StartInitToolbarState)
            {
                _listView.GetItem<WlEntry>(e.Position).ChangeCheck();
                SetToolbar<StartDeleteToolbarState>();
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_add_Start_Init:
                    new AddNewDirectoryDialogFragment().Show(SupportFragmentManager, null);
                    break;
                case Resource.Id.action_settings_Start_Init:
                    StartActivity(new Intent(this, typeof(Settings)));
                    break;
                case Android.Resource.Id.Home:
                    switch (ToolbarState.ToolbarId)
                    {
                        case Resource.Id.tbStart_Init:
                            var adapter = _listView.GetAdapter<StartAdapter>();
                            adapter.CurrentFolder = adapter.CurrentFolder.GetParent<WlFolder>();
                            break;
                        case Resource.Id.tbStart_Deletemode:
                            _listView.GetAdapter<StartAdapter>().CurrentFolder.ClearCheck();
                            SetToolbar<StartInitToolbarState>();
                            break;
                    }
                    break;
                case Resource.Id.action_delete_Start_Deletemode:
                    new DeleteEntriesDialogFragment().Show(SupportFragmentManager, null);
                    break;
                case Resource.Id.action_move_Start_Deletemode:
                    new MoveDirectoryDialogFragment().Show(SupportFragmentManager, null);
                    break;
                case Resource.Id.action_rename_Start_Deletemode:
                    var bundle = new Bundle();
                    bundle.PutExtra<WlDirectory>(RenameDirectoryDialogFragment.RenameDirectoryKey, _listView.GetAdapter<StartAdapter>().CurrentFolder);
                    new RenameDirectoryDialogFragment(bundle).Show(SupportFragmentManager, null);
                    break;
                case Resource.Id.action_integration_Start_Deletemode:
                    //new WlAlartDialogFragment(typeof(IntegrateDirectoryDialogBuilder)).Show(SupportFragmentManager, null);
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
        /// <summary>
        /// When returning from Edit_Wordlist
        /// </summary>
        protected override void OnRestart()
        {
            base.OnRestart();
        }
        #endregion


        #region Method

        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                     GoogleApiAvailability.Instance.GetErrorString(resultCode);
                else
                {
                    Finish();
                }
                return false;
            }
            else
            {
                return true;
            }
        }


        public override void OnDialogResult(dynamic result, string dialogName)
        {
            switch (dialogName)
            {
                case nameof(CreateNewItemDialogFragment):
                    var targetFolder = _listView.GetAdapter<StartAdapter>().CurrentFolder;
                    var (entryType, fileName) = ((WlEntryType, string))result;
                    WlDirectory directory = null;
                    switch (entryType)
                    {
                        case WlEntryType.Folder:
                            directory = new WlFolder(fileName);
                            break;
                        case WlEntryType.WordList:
                            directory = new WlWordList(fileName);
                            break;
                    }

                    directory?.AddTo(targetFolder);
                    break;
                case nameof(DeleteEntriesDialogFragment):
                    SetToolbar<StartInitToolbarState>();
                    Toast.MakeText(this, WlMessage.Delete[WlLanguageUtil.CurrentLanguage], ToastLength.Short).Show();
                    break;
                case nameof(MoveDirectoryDialogFragment):
                    SetToolbar<StartInitToolbarState>();
                    if (result == true)
                    {
                        Toast.MakeText(this, WlMessage.Move[WlLanguageUtil.CurrentLanguage], ToastLength.Short).Show();
                    }
                    break;
                case nameof(RenameDirectoryDialogFragment):
                    break;
            }
        }

        #endregion

    }

    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    [Obsolete]
    public class MyFirebaseIIDService : FirebaseInstanceIdService
    {
        const string TAG = "MyFirebaseIIDService";

        [Obsolete]
        public override void OnTokenRefresh()
        {
            string refreshedToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(TAG, "Refreshed token: " + refreshedToken);
            SendRegistrationToServer(refreshedToken);
        }
        void SendRegistrationToServer(string token)
        {
            // Add custom implementation, as needed.
        }
    }
}