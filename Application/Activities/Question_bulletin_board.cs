using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using Google.Android.Material.TextField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using WordLearning.Application.Activities.ActivityCore;
using WordLearning.Domain.Adapters;
using static Android.Widget.AdapterView;

namespace WordLearning.Application.Activities
{
    [Activity(Label = "Question_bulletin_board")]
    public class Question_bulletin_board : CustomActivity
    {
        protected override int ToolbarId { get; } = Resource.Id.flToolbar_Question_bulletin_board;

        protected override int LayoutId { get; } = Resource.Layout.Question_bulletin_board;


        private DatabaseReference mDatabase;
        private static ListView listView;
        private static List<(string, string, DateTime)> listboard = new();
        private static List<(string, DateTime)> listtitle = new();
        private int position;
        private string selecttitle;
        private string selecttitledate;

        private enum Mode { Title, Board };

        private Mode mode;
        private readonly string yourname = string.Empty;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // SetContentViewAndToolbar(Resource.Layout.Question_bulletin_board, Resource.Id.tbQuestion_bulletin_board,Resource.Menu.menu_Question_bulletin_board,true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            listView = FindViewById<ListView>(Resource.Id.lv_Question_bulletin_board);
            GetDatabaseQuery();
        }

        /// <summary>
        /// When Destroying this activity.
        /// </summary>
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        /// <summary>
        /// データベースのクエリを取得
        /// </summary>
        /// <returns>設定値に応じたデータベースへの参照</returns>
        private void GetDatabaseQuery()
        {
            mDatabase = FirebaseDatabase.GetInstance("https://api-4876079148476953481-415794.firebaseio.com/").Reference;
            mDatabase.AddValueEventListener(new listtitleevent(this));
            Setmode(Mode.Title);
        }

        private void Setmode(Mode mode)
        {
            this.mode = mode;
            InvalidateOptionsMenu();
        }

        public void lv_Question_bulletin_board_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (mode == Mode.Board)
            {
                return;
            }


            string title = listView.Adapter.GetItem(e.Position).ToString();
            string titlename = XmlConvert.EncodeName(title.TrimStart('(').TrimEnd(')').Split(',')[0]);
            string titledate = title.TrimStart('(').TrimEnd(')').Split(',')[1].Trim();
            DateTime.TryParse(titledate, null, System.Globalization.DateTimeStyles.AssumeLocal | System.Globalization.DateTimeStyles.AdjustToUniversal, out DateTime dateTime);
            titledate = XmlConvert.EncodeName(dateTime.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-us")));
            DatabaseReference test = mDatabase.Child(titlename).Child(titledate);
            position = e.Position;
            selecttitle = titlename;
            selecttitledate = titledate;
            SupportActionBar.Title = XmlConvert.DecodeName(selecttitle);
            test.AddValueEventListener(new listboardevent(this));
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            Setmode(Mode.Board);
        }

        private void Writeonboard(object sender, DialogClickEventArgs e)
        {
            //var test = mDatabase.Child(selecttitle).Child(selecttitledate);
            //var dlg = sender as Android.Support.V7.App.AlertDialog;
            //TextInputEditText textInputEditText = dlg.FindViewById<TextInputEditText>(Constant.FreeDlgId2);
            //if (string.IsNullOrEmpty(editText.Text)) return;
            //if (string.IsNullOrEmpty(textInputEditText.Text)) textInputEditText.Text = "Guest";
            //string nowtime = DateTime.UtcNow.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-us"));
            //await test.Child(XmlConvert.EncodeName(nowtime)).SetValueAsync(string.Empty); //SetValue(XmlConvert.EncodeName(editText.Text));
            //await test.Child(XmlConvert.EncodeName(nowtime)).Child(XmlConvert.EncodeName(textInputEditText.Text)).SetValueAsync(XmlConvert.EncodeName(editText.Text));
            //test.AddValueEventListener(new listboardevent(this));
            //yourname = textInputEditText.Text;
        }

        public void lv_Question_bulletin_board_ItemLongClick(object sender, ItemLongClickEventArgs e)
        {

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            // var dlg = new Android.Support.V7.App.AlertDialog.Builder(this);
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    if (mode == Mode.Board)
                    {
                        Setmode(Mode.Title);
                        //SetContentViewAndToolbar(Resource.Layout.Question_bulletin_board, Resource.Id.tbQuestion_bulletin_board, Resource.Menu.menu_Question_bulletin_board, true);
                        SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                        SupportActionBar.SetHomeButtonEnabled(true);
                        SupportActionBar.Title = Resources.GetString(Resource.String.Question_bulletin_board);
                        listView = FindViewById<ListView>(Resource.Id.lv_Question_bulletin_board);
                        GetDatabaseQuery();
                    }
                    else
                    {
                        Finish();
                    }
                    break;
                case Resource.Id.action_add_Question_bulletin_board:
                    TextInputLayout tlititle = new TextInputLayout(this)
                    {
                        LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent)
                    };
                    TextInputEditText textInputEditTexttitle = new TextInputEditText(this)
                    {
                        Hint = "Title"
                    };
                    textInputEditTexttitle.SetMaxHeight(140);
                    tlititle.AddView(textInputEditTexttitle);
                    //dlg.SetTitle("Create title");
                    //dlg.SetPositiveButton("OK", Createtitle);
                    //dlg.SetNegativeButton("CANCEL", (s2, e2) => { });
                    //dlg.SetView(tlititle);
                    //dlg.Show();
                    break;
                case Resource.Id.action_write_Question_bulletin_board:
                    LinearLayout linearLayout = new LinearLayout(this)
                    {
                        Orientation = Orientation.Vertical,
                        LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent)
                    };
                    EditText editText = new EditText(this)
                    {
                        LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent)
                    };
                    TextInputLayout tli = new TextInputLayout(this)
                    {
                        LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent)
                    };
                    TextInputEditText textInputEditText = new TextInputEditText(this)
                    {
                        Hint = "Name"
                    };
                    textInputEditText.SetMaxHeight(140);
                    textInputEditText.Text = yourname;
                    tli.AddView(textInputEditText);
                    editText.SetMaxHeight(280);
                    linearLayout.AddView(tli);
                    linearLayout.AddView(editText);
                    //dlg.SetTitle("Write");
                    //dlg.SetPositiveButton("OK", Writeonboard);
                    //dlg.SetNegativeButton("CANCEL", (s2, e2) => { });
                    //dlg.SetView(linearLayout);
                    //dlg.Show();
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    if (menuResID.HasValue)
        //    {
        //        MenuInflater.Inflate((int)menuResID, menu);
        //        this.menu = menu;
        //        switch (mode) 
        //        { 
        //            case Mode.Title:
        //                menu.GetItem(0).SetVisible(true);
        //                menu.GetItem(1).SetVisible(false);
        //                break;
        //            case Mode.Board:
        //                menu.GetItem(0).SetVisible(false);
        //                menu.GetItem(1).SetVisible(true);
        //                break; 
        //        }
        //    }
        //    return true;
        //}

        public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            if (mode == Mode.Board)
            {
                Setmode(Mode.Title);
                //SetContentViewAndToolbar();
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);
                SupportActionBar.Title = Resources.GetString(Resource.String.Question_bulletin_board);
                listView = FindViewById<ListView>(Resource.Id.lv_Question_bulletin_board);
                GetDatabaseQuery();
                return false;
            }
            return base.OnKeyDown(keyCode, e);
        }

        private void Createtitle(object sender, DialogClickEventArgs e)
        {
            //var test = mDatabase;
            //var dlg = sender as Android.Support.V7.App.AlertDialog;
            //if (string.IsNullOrEmpty(textInputEditText.Text)) return;
            ////FirebaseVisionImage
            //if (listtitle.Select(p => p.Item1).Contains(textInputEditText.Text))
            //{
            //    var dlg2 = new Android.Support.V7.App.AlertDialog.Builder(this);
            //    dlg2.SetMessage(WlMessage.AnotherTitle[Utility.Language]);
            //    dlg2.SetPositiveButton("OK",(s1,e1) => { dlg.Show(); });
            //    dlg2.Show();
            //    return;
            //}
            //await test.Child(XmlConvert.EncodeName(textInputEditText.Text)).SetValueAsync(string.Empty);
            //string datenow = DateTime.UtcNow.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-us"));
            ////var pp = FirebaseInstanceId.Instance.Id;
            //await test.Child(XmlConvert.EncodeName(textInputEditText.Text)).Child(XmlConvert.EncodeName(datenow)).SetValueAsync(string.Empty);
            //test.AddValueEventListener(new listtitleevent(this));
        }

        public override void OnDialogResult(object result, string dialogName)
        {
            throw new NotImplementedException();
        }

        public class tt : Java.Lang.Object, IChildEventListener
        {
            public void OnCancelled(DatabaseError error)
            {
                // throw new NotImplementedException();
            }

            public void OnChildAdded(DataSnapshot snapshot, string previousChildName)
            {
                //throw new NotImplementedException();
            }

            public void OnChildChanged(DataSnapshot snapshot, string previousChildName)
            {
                //throw new NotImplementedException();
            }

            public void OnChildMoved(DataSnapshot snapshot, string previousChildName)
            {
                //throw new NotImplementedException();
            }

            public void OnChildRemoved(DataSnapshot snapshot)
            {
                //throw new NotImplementedException();
            }
        }

        public class listboardevent : Java.Lang.Object, IValueEventListener
        {
            private readonly Question_bulletin_board question_bulletin_board;

            public listboardevent(Question_bulletin_board question_bulletin_board)
            {
                this.question_bulletin_board = question_bulletin_board;
            }

            public void OnCancelled(DatabaseError error)
            {
                //throw new NotImplementedException();
            }

            public void OnDataChange(DataSnapshot snapshot)
            {
                listboard = new List<(string, string, DateTime)>();
                foreach (DataSnapshot dss in snapshot.Children.ToEnumerable())
                {
                    JavaDictionary nameandsentence = dss.GetValue(true) as JavaDictionary;
                    if (nameandsentence == null)
                    {
                        continue;
                    }

                    JavaSet name = nameandsentence.Keys as JavaSet;
                    JavaCollection sentence = nameandsentence.Values as JavaCollection;
                    string namestr = name.OfType<string>().First();
                    System.Collections.IEnumerator sentencestr = sentence.GetEnumerator();
                    sentencestr.MoveNext();

                    DateTime.TryParse(XmlConvert.DecodeName(dss.Key), null, System.Globalization.DateTimeStyles.AssumeUniversal, out DateTime datetime);
                    listboard.Add((XmlConvert.DecodeName(sentencestr.Current.ToString()), XmlConvert.DecodeName(namestr), datetime));
                }
                listboard = listboard.OrderByDescending(elm => elm.Item3).ToList();
                if (question_bulletin_board.mode == Mode.Board)
                {
                    listView.Adapter = new PostAdapter(question_bulletin_board, Resource.Layout.row_Post, listboard);
                }
            }
        }

        public class listtitleevent : Java.Lang.Object, IValueEventListener
        {
            private readonly Question_bulletin_board question_bulletin_board;

            public listtitleevent(Question_bulletin_board question_bulletin_board)
            {
                this.question_bulletin_board = question_bulletin_board;
            }

            public void OnCancelled(DatabaseError error)
            {
                //throw new NotImplementedException();
            }

            public void OnDataChange(DataSnapshot snapshot)
            {
                listtitle = new List<(string, DateTime)>();
                foreach (DataSnapshot dss in snapshot.Children.ToEnumerable())
                {
                    DateTime datetime;
                    JavaDictionary date = dss.GetValue(true) as JavaDictionary;
                    Java.Lang.String date2 = dss.GetValue(true) as Java.Lang.String;
                    if (date == null && date2 != null)
                    {
                        DateTime.TryParse(XmlConvert.DecodeName(date2.ToString()), null, System.Globalization.DateTimeStyles.AssumeUniversal, out datetime);
                        listtitle.Add((XmlConvert.DecodeName(dss.Key), datetime));
                    }
                    else if (date != null)
                    {
                        JavaSet teststr = date.Keys as JavaSet;
                        string datestr = teststr.OfType<string>().First();
                        DateTime.TryParse(XmlConvert.DecodeName(datestr), null, System.Globalization.DateTimeStyles.AssumeUniversal, out datetime);
                        listtitle.Add((XmlConvert.DecodeName(dss.Key), datetime));
                    }

                }
                listtitle = listtitle.OrderByDescending(elm => elm.Item2).ToList();
                if (question_bulletin_board.mode == Mode.Title)
                {
                    listView.Adapter = new ArrayAdapter_Title(question_bulletin_board, Resource.Layout.row_Post, listtitle);
                }
            }
        }
    }
}