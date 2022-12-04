using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Database;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using WordLearning.Application.Activities;
using WordLearning.Application.Activities.ActivityCore;
using WordLearning.Application.Dialog;
using static Android.Widget.AdapterView;

namespace WordLearning.Application.Activities
{
    [Activity(Label = "Settings")]
    public class Settings : CustomActivity, ActivityCompat.IOnRequestPermissionsResultCallback
    {
        protected override int ToolbarId { get; } = Domain.Resource.Id.flToolbar_Settings;

        protected override int LayoutId { get; } = Domain.Resource.Layout.Settings;

        private ListView listView_BU_And_RC;
        private readonly SeekBar[] seekBars = new SeekBar[3];
        private readonly List<(string, List<string[]>)> contentdata = new();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // SetContentViewAndToolbar();
            listView_BU_And_RC = FindViewById<ListView>(Domain.Resource.Id.lv_Settings_Backup_And_Recover);
            //if (File.Exists(Utility.BackupPath))
            //{
            //    listView_BU_And_RC.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, Message.BackUp[Utility.Language]);
            //}
        }

        #region listView(Backup And Recover) Click
        /// <summary>
        /// Lvs the settings click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        public void lv_Settings_Backup_And_Recover_ItemClick(object sender, ItemClickEventArgs e)
        {
            //System.EventHandler<DialogClickEventArgs>[] handler = new System.EventHandler<DialogClickEventArgs>[2];
            //handler[0] = CreateBackupCheck;
            //handler[1] = RecoverfromBackupCheck;
            //var dlgConfirm = new Android.Support.V7.App.AlertDialog.Builder(this);
            //dlgConfirm.SetMessage(WlMessage.BU_And_RC[WlLanguageUtil.CurrentLanguage][e.Position]);
            //dlgConfirm.SetNegativeButton("OK", handler[e.Position]);
            //dlgConfirm.SetPositiveButton("CANCEL", (_s, _e) => { });
            //dlgConfirm.Show();
        }

        /// <summary>
        /// Lvs the settings click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        public void lv_Settings_Backup_And_Recover_ItemLongClick(object sender, ItemLongClickEventArgs e)
        {

        }
        #endregion

        #region listView(Change themecolor) Click
        /// <summary>
        /// Lvs the settings click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        public void lv_Settings_Changethemecolor_ItemClick(object sender, ItemClickEventArgs e)
        {
            new ChangeThemeColorDialogBuilder(ApplicationContext).Show();
        }

        /// <summary>
        /// Lvs the settings click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        public void lv_Settings_Changethemecolor_ItemLongClick(object sender, ItemLongClickEventArgs e)
        {

        }
        #endregion

        #region listview(CSVfile import) Click

        public void lv_Settings_CSVfileimport_ItemClick(object sender, ItemClickEventArgs e)
        {
            Intent intent = new Intent(Intent.ActionGetContent);
            intent.AddCategory(Intent.CategoryOpenable);
            intent.SetType("*/*");
            intent.PutExtra(Intent.ExtraAllowMultiple, true);
            StartActivityForResult(Intent.CreateChooser(intent, "Select csvfile"), (int)RequestCode.SELECT_CSVFILE);
        }


        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            contentdata.Clear();
            if (requestCode == (int)RequestCode.SELECT_CSVFILE && resultCode == Result.Ok)
            {
                Android.Net.Uri uri = data.Data;
                if (uri != null) //１つだけ選択した場合
                {
                    (string, List<string[]>) csvdata = new ValueTuple<string, List<string[]>>
                    {
                        Item2 = new List<string[]>()
                    };
                    string name = "test";
                    bool skipflag = false;
                    Stream st = ContentResolver.OpenInputStream(uri);
                    string[] projection = { MediaStore.MediaColumns.DisplayName };
                    ICursor cursor = ContentResolver.Query(uri, projection, null, null, null);
                    if (cursor != null)
                    {
                        //name = null;
                        if (cursor.MoveToFirst())
                        {
                            name = cursor.GetString(0);
                            if (name.Length > 3)
                            {
                                if (name.Substring(name.Length - 4, 4) != ".csv")
                                {
                                    skipflag = true;
                                }
                            }
                        }
                        cursor.Close();
                    }
                    if (!skipflag)
                    {
                        try
                        {
                            // csvファイルを開く
                            using (StreamReader sr = new StreamReader(st, System.Text.Encoding.GetEncoding("UTF-8")))
                            {
                                csvdata.Item1 = new string(name.SkipLast(4).ToArray());
                                // ストリームの末尾まで繰り返す
                                while (!sr.EndOfStream)
                                {
                                    // ファイルから一行読み込む
                                    string line = sr.ReadLine();
                                    // 読み込んだ一行をカンマ毎に分けて配列に格納する
                                    string[] values = line.Split(',');
                                    // 出力する
                                    if (values.Length > 1)
                                    {
                                        if (values.Length == 2)
                                        {
                                            csvdata.Item2.Add(new string[] { values[0], values[1], string.Empty });
                                        }
                                        else
                                        {
                                            csvdata.Item2.Add(new string[] { values[0], values[1], values[2] });
                                        }
                                    }
                                }
                                //contentdataに保存
                                contentdata.Add(csvdata);
                            }
                        }
                        catch (System.Exception e)
                        {
                            // ファイルを開くのに失敗したとき
                            System.Console.WriteLine(e.Message);
                        }
                    }

                }
                else if (data.ClipData != null)//２つ以上選択した場合
                {
                    for (int i = 0; i < data.ClipData.ItemCount; i++)
                    {
                        Android.Net.Uri uri2 = data.ClipData.GetItemAt(i).Uri;
                        (string, List<string[]>) csvdata = new ValueTuple<string, List<string[]>>
                        {
                            Item2 = new List<string[]>()
                        };
                        string name = "test";
                        Stream st = ContentResolver.OpenInputStream(uri2);
                        string[] projection = { MediaStore.MediaColumns.DisplayName };
                        ICursor cursor = ContentResolver.Query(uri2, projection, null, null, null);
                        if (cursor != null)
                        {
                            if (cursor.MoveToFirst())
                            {
                                name = cursor.GetString(0);
                                if (name.Length > 3)
                                {
                                    if (name.Substring(name.Length - 4, 4) != ".csv")
                                    {
                                        cursor.Close();
                                        continue;
                                    }
                                }
                            }
                            cursor.Close();
                        }
                        try
                        {
                            // csvファイルを開く
                            using (StreamReader sr = new StreamReader(st, System.Text.Encoding.GetEncoding("UTF-8")))
                            {
                                csvdata.Item1 = new string(name.SkipLast(4).ToArray());
                                // ストリームの末尾まで繰り返す
                                while (!sr.EndOfStream)
                                {
                                    // ファイルから一行読み込む
                                    string line = sr.ReadLine();
                                    // 読み込んだ一行をカンマ毎に分けて配列に格納する
                                    string[] values = line.Split(',');
                                    // 出力する
                                    if (values.Length > 1)
                                    {
                                        if (values.Length == 2)
                                        {
                                            csvdata.Item2.Add(new string[] { values[0], values[1], string.Empty });
                                        }
                                        else
                                        {
                                            csvdata.Item2.Add(new string[] { values[0], values[1], values[2] });
                                        }
                                    }
                                }
                                //contentdataに保存
                                contentdata.Add(csvdata);
                            }
                        }
                        catch (System.Exception e)
                        {
                            // ファイルを開くのに失敗したとき
                            System.Console.WriteLine(e.Message);
                        }

                    }
                }
                if (contentdata.Count > 0)
                {
                    //    var dlg = new Android.Support.V7.App.AlertDialog.Builder(this);
                    //    dlg.SetMessage(WlMessage.RegisterWordListConfirm[WlLanguageUtil.CurrentLanguage]);
                    //    ListView listView = new ListView(this)
                    //    {
                    //        Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, (from dataelm in contentdata select dataelm.Item1).ToList())
                    //    };
                    //    dlg.SetView(listView);
                    //    dlg.SetPositiveButton("OK", Addcsvdata);
                    //    dlg.SetNegativeButton("CANCEL", (s, e) => { });
                    //    dlg.Show();
                }
            }
            //else if (requestCode == (int)RequestCode.RESLUT_CAMERA && resultCode == Result.Ok)
            //{
            //    if (data.Extras != null)
            //    {
            //        Bitmap bitmap = (Bitmap)data.Extras.Get("data");
            //        if (bitmap != null)
            //        {
            //            FirebaseVisionImage firebaseVisionImage = FirebaseVisionImage.FromBitmap(bitmap);
            //            var detector = FirebaseVision.Instance.OnDeviceTextRecognizer;
            //            var result = detector.ProcessImage(firebaseVisionImage).AddOnSuccessListener(new Recognizertext());
            //            // 画像サイズを計測
            //            int bmpWidth = bitmap.Width;
            //            int bmpHeight = bitmap.Height;
            //        }
            //        // dataから画像を取り出す
            //    }
            //}
        }

        private void Addcsvdata(object sender, DialogClickEventArgs e)
        {
            //var dlgMove = new Android.Support.V7.App.AlertDialog.Builder(this);
            //LayoutInflater Inflater;
            //Inflater = (LayoutInflater)GetSystemService(LayoutInflaterService);
            //View layout = Inflater.Inflate(Resource.Layout.Dialog_Move_Start, (ViewGroup)FindViewById(Resource.Id.ll_Dialog_Move_Start));
            //ListView listFolder = layout.FindViewById<ListView>(Resource.Id.lv_Dialog_Move_Start);
            //RecyclerView listFolder = layout.FindViewById<RecyclerView>(Resource.Id.lv_Dialog_Move_Start);
            //listFolder.Adapter = new ArrayAdapter_Start_Move(this, Resource.Layout.row, AllFolder.ToList());
            //listFolder.SetLayoutManager(new LinearLayoutManager(this));
            //listFolder.SetAdapter(new Start_MoveAdapter(this, Resource.Layout.row_SelectDestination));
            //listFolder.ItemClick += (_s, _e) =>
            //{

            //    if (listFolder.GetTag(Constant.FreeTagKey) != null)
            //    {
            //        int previousselectpositon = (int)listFolder.GetTag(Constant.FreeTagKey) - listFolder.FirstVisiblePosition;
            //        if (previousselectpositon >= 0 && previousselectpositon <= listFolder.LastVisiblePosition)
            //        {
            //            listFolder.GetChildAt(previousselectpositon).SetBackgroundColor(Constant.SelectColor[false]);
            //        }
            //    }
            //    listFolder.SetTag(Constant.FreeTagKey, _e.Position);
            //    listFolder.GetChildAt(_e.Position - listFolder.FirstVisiblePosition).SetBackgroundColor(Color.Green);
            //    position_dlg = _e.Position;
            //    return;
            //};
            //dlgMove.SetMessage(WlMessage.SelectPlace[WlLanguageUtil.CurrentLanguage]);
            //dlgMove.SetPositiveButton(WlMessage.Add[WlLanguageUtil.CurrentLanguage], Addcsvdata2);
            //dlgMove.SetNegativeButton("CANCEL", (_s, _e) => { });
            //dlgMove.SetView(layout);
            //dlgMove.SetCancelable(false);
            //dlgMove.Show();
        }

        /// <summary>
        /// Move the specified sender and e.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void Addcsvdata2(object sender, DialogClickEventArgs e)
        {
            //var dlg = (Android.Support.V7.App.AlertDialog)sender;
            //ListView listFolder = dlg.FindViewById<ListView>(Resource.Id.lv_Dialog_Move_Start);
            //foreach ((string, List<string[]>) data in contentdata)
            //{
            //    var wordlistxml = new XElement("Wordlist", new XAttribute("Name", XmlConvert.EncodeLocalName(data.Item1)));
            //    foreach (string[] wordandmeaning in data.Item2)
            //    {
            //        wordlistxml.Add(new XElement("Word", new XElement("Wordname", XmlConvert.EncodeLocalName(wordandmeaning[0])), new XElement("Wordmeaning", wordandmeaning[1]), new XElement("Tag", "00000"), new XElement("Memo", XmlConvert.EncodeLocalName(wordandmeaning[2]))));
            //    }
            //}
            //Toast.MakeText(this, WlMessage.AddComplete[WlLanguageUtil.CurrentLanguage], ToastLength.Short).Show();
            //return;
        }

        /// <summary>
        /// Get all folders.
        /// </summary>
        /// <returns>The all folder.</returns>
        /// <param name="xDocument">X document.</param>
        private Dictionary<List<int>, XElement> GetAllFolder(XDocument xDocument)
        {
            XElement currentElement = xDocument.Root.Element("Folder");
            List<int> path = new List<int>() { 0, 0 };
            Dictionary<List<int>, XElement> retAllFolder = new Dictionary<List<int>, XElement>();
            Action<XElement> func = null;
            func = (ChildElement) =>
            {
                foreach ((XElement, int) xElement in ChildElement.Elements().Select((v, i) => (v, i)))
                {
                    if (xElement.Item1.Name == "Folder")
                    {
                        path.Add(xElement.Item2);
                        func(xElement.Item1);
                        path.RemoveAt(path.Count - 1);
                    }
                }
                if (ChildElement.Name == "Folder")
                {
                    List<int> vs = new List<int>(path);
                    retAllFolder.Add(vs, ChildElement);
                }
            };
            func(currentElement);
            return retAllFolder;
        }

        #endregion

        #region listview(Question_bulletin_board) Click

        public void lv_Settings_Question_bulletin_board_ItemClick(object sender, ItemClickEventArgs e)
        {
            Intent intent = new Intent(this, typeof(Question_bulletin_board));
            StartActivity(intent);
        }

        #endregion

        /// <summary>
        /// When Destroying this activity.
        /// </summary>
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        #region Method
        /// <summary>
        /// Check whether creating backup is enabled or not.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void CreateBackupCheck(object sender, DialogClickEventArgs e)
        {
            Permission permission = CheckSelfPermission(Manifest.Permission.WriteExternalStorage);
            if (permission != Permission.Granted)
            {
                RequestPermissions(new string[] { Manifest.Permission.WriteExternalStorage }, (int)PermissionRequestCode.CreateBackup);
            }
            else
            {
                CreateBackup();
            }
        }

        /// <summary>
        /// Create backup.
        /// </summary>
        private void CreateBackup()
        {
            //            var dlgResult = new Android.Support.V7.App.AlertDialog.Builder(this);
            //            try
            //            {
            //                //if (File.Exists(Utility.BackupPath))
            //                //{
            //                //    File.Delete(Utility.BackupPath);
            //                //}
            //                //else
            //                {
            //                    if (!Directory.Exists(GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments).AbsolutePath))
            //                    {
            //                        Directory.CreateDirectory(GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments).AbsolutePath);
            //                    }
            //                }
            //                //File.Copy(Utility.WordListPath, Utility.BackupPath, true);
            //                dlgResult.SetMessage(WlMessage.CreateBackupComplete[WlLanguageUtil.CurrentLanguage]);
            //            }
            //            catch (UnauthorizedAccessException ex)
            //            {
            //#if DEBUG
            //                System.Diagnostics.Debug.Print(ex.Message);
            //#endif

            //                dlgResult.SetTitle(WlMessage.Error[WlLanguageUtil.CurrentLanguage]);
            //                dlgResult.SetMessage(WlMessage.RequireStorageAccess[WlLanguageUtil.CurrentLanguage]);
            //            }
            //            catch (Exception ex)
            //            {
            //#if DEBUG
            //                System.Diagnostics.Debug.Print(ex.Message);
            //#endif

            //                dlgResult.SetTitle(WlMessage.Error[WlLanguageUtil.CurrentLanguage]);
            //                dlgResult.SetMessage(WlMessage.CreateBackupFailure[WlLanguageUtil.CurrentLanguage]);
            //            }
            //            finally
            //            {
            //                dlgResult.SetPositiveButton("OK", (_s, _e) => { });
            //                dlgResult.Show();
            //            }
        }
        /// <summary>
        /// Recover from backup.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void RecoverfromBackupCheck(object sender, DialogClickEventArgs e)
        {
            Permission permission = CheckSelfPermission(Manifest.Permission.WriteExternalStorage);
            if (permission != Permission.Granted)
            {
                RequestPermissions(new string[] { Manifest.Permission.WriteExternalStorage }, (int)PermissionRequestCode.RecoverFromBackup);
            }
            else
            {
                RecoverfromBackup();
            }
        }

        /// <summary>
        /// Recover from backup.
        /// </summary>
        private void RecoverfromBackup()
        {
            // var dlgResult = new Android.Support.V7.App.AlertDialog.Builder(this);
            //bool toomanyflag = false;
            //if (File.Exists(Utility.BackupPath))
            //{
            //    try
            //    {
            //        // var xelmBU = XDocument.Load(Utility.BackupPath).Root.Element("Folder");

            //        Window.SetStatusBarColor(ThemeColor.DarkColor);
            //        Window.SetNavigationBarColor(ThemeColor.Color);
            //        toolbar.BackgroundTintList = ColorStateList.ValueOf(ThemeColor.Color);
            //        if (toomanyflag)
            //        {
            //            dlgResult.SetMessage(Message.Restorecompletedtoomanyfolder[Utility.Language]);
            //        }
            //        dlgResult.SetMessage(Message.Restorecompleted[Utility.Language]);
            //    }
            //    catch (UnauthorizedAccessException)
            //    {
            //        dlgResult.SetTitle(Message.Error[Utility.Language]);
            //        dlgResult.SetMessage(Message.RequireStorageAccess[Utility.Language]);
            //    }
            //    catch (System.Exception)
            //    {
            //        dlgResult.SetTitle(Message.Error[Utility.Language]);
            //        dlgResult.SetMessage(Message.Restorefaliure[Utility.Language]);
            //    }
            //}
            //else
            //{
            //    dlgResult.SetMessage(Message.Noneofbackup[Utility.Language]);
            //}
            // dlgResult.SetPositiveButton("OK", (_s, _e) => { });
            // dlgResult.Show();
        }
        /// <summary>
        /// Recover the specified xelm and xelmBU.
        /// </summary>
        /// <param name="xelm">Xelm.</param>
        /// <param name="xelmBU">Xelm bu.</param>
        private void Recover(XElement xelm, XElement xelmBU)
        {
            //bool duplicateflag = false;
            //foreach (XElement elmBU in xelmBU.Elements())
            //{
            //    foreach (XElement elm in xelm.Elements())
            //    {
            //        if (elmBU.Name == elm.Name && elmBU.Attribute("type").Value == elm.Attribute("type").Value)
            //        {
            //            duplicateflag = true;
            //            if (elmBU.Attribute("type").Value == "Wordlist")
            //            {
            //                xelmnow.Elements().ToList().Find((p) => { return p.Name == elmBU.Name && p.Attribute("type").Value == elmBU.Attribute("type").Value; }).Remove();
            //                duplicateflag = false;
            //                break;
            //            }
            //            else if (elmBU.Attribute("type").Value == "Themecolor")
            //            {
            //                xelmnow.Elements().Single((p) => { return p.Attribute("type").Value == "Themecolor"; }).Remove();
            //                duplicateflag = false;
            //                break;
            //            }
            //            xelmnow = xelmnow.Elements().ToList().Find((p) => { return p.Name == elmBU.Name && p.Attribute("type").Value == elmBU.Attribute("type").Value; });
            //            Recover(elm, elmBU);
            //            xelmnow = xelmnow.Ancestors().First();
            //        }
            //    }
            //    if (!duplicateflag)
            //    {
            //        xelmnow.Add(elmBU);
            //    }
            //}

        }
        ///// <summary>
        ///// Check whether Camera is enabled or not.
        ///// </summary>
        ///// <param name="sender">Sender.</param>
        ///// <param name="e">E.</param>
        //private void CameraCheck()
        //{
        //    Permission permission = CheckSelfPermission(Manifest.Permission.Camera);
        //    if (permission != Permission.Granted)
        //    {
        //        RequestPermissions(new string[] { Manifest.Permission.Camera }, (int)PermissionRequestCode.ImportFromImage);
        //    }
        //    else
        //    {
        //        ImportFromImage();
        //    }
        //}

        private void ImportFromImage()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, (int)RequestCode.RESLUT_CAMERA);
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
                case Android.Resource.Id.Home:
                    Finish();
                    break;
            }
            return base.OnOptionsItemSelected(item);
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
        /// <summary>
        /// Select method from permissionsresult
        /// </summary>
        /// <param name="requestCode">Request code.</param>
        /// <param name="permissions">Permissions.</param>
        /// <param name="grantResults">Grant results.</param>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionRequestCode prc = (PermissionRequestCode)requestCode;
            switch (prc)
            {
                case PermissionRequestCode.CreateBackup:
                    CreateBackup();
                    break;
                case PermissionRequestCode.RecoverFromBackup:
                    RecoverfromBackup();
                    break;
                case PermissionRequestCode.ImportFromImage:
                    ImportFromImage();
                    break;
                default:
                    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
                    break;
            }
        }

        public override void OnDialogResult(object result, string dialogName)
        {
            throw new NotImplementedException();
        }

        private enum RequestCode
        {
            RESLUT_CAMERA = 0,
            SELECT_CSVFILE = 1
        };

        private enum PermissionRequestCode
        {
            CreateBackup = 0,
            RecoverFromBackup = 1,
            ImportFromImage = 2
        };

    }
}
