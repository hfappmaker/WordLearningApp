﻿namespace WordLearning.Application.Fragment
{
    internal class EditTagDialogFragment : WlAlartDialogFragment
    {
        public EditTagDialogFragment() : base()
        {
        }




        //private void Initialize(Context context)
        //{
        //    var inflater = LayoutInflater.From(context);
        //    var view = inflater.Inflate(Resource.Layout.Dialog_EditTag, null);
        //    SetView(view);
        //    Android.Support.V7.Widget.Toolbar toolbar_dlg = view.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.tbDialog_EditTag_include);
        //    var TagList = view.FindViewById<ListView>(Resource.Id.lv_Dialog_EditTag);
        //    TagList.Adapter = new TagListAdapter(context, Resource.Layout.row_Taglist);
        //    toolbar_dlg.Title = WlMessage.EditTag[WlLanguageUtil.CurrentLanguage];
        //    toolbar_dlg.InflateMenu(Resource.Menu.menu_Dialog_EditTag);

        //}

        //public void row_Taglist_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    var dlgNewTag = new Android.Support.V7.App.AlertDialog.Builder(Context);
        //    dlgNewTag.SetPositiveButton("CANCEL", (s2, e2) => { return; });
        //    dlgNewTag.SetNegativeButton("OK", (s2, e2) => { return; }); ;
        //    dlgNewTag.Show();
        //}

        //public void tbDialog_EditTag_include_MenuItemClick(object sender, MenuItemClickEventArgs e)
        //{
        //    switch (e.Item.ItemId)
        //    {
        //        case Resource.Id.action_add_Dialog_EditTag:
        //            new CreateNewTagDialogBulder(Context).Show();
        //            break;
        //    }
        //}
    }
}
