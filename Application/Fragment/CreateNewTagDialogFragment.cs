using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using WordLearning.Domain.Colors;
using WordLearning.Domain.Utility;
using WordLearning.Domain.Shape;
using static Android.Widget.RadioGroup;
using static Android.Widget.SeekBar;

namespace WordLearning.Application.Fragment
{
    internal class CreateNewTagDialogFragment : WlAlartDialogFragment
    {
        public CreateNewTagDialogFragment() : base()
        {
        }


        public override Android.App.Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(Activity);
            Android.Views.LayoutInflater inflater = Android.Views.LayoutInflater.From(Activity);
            Android.Views.View view = inflater.Inflate(Resource.Layout.Dialog_CreateNewTag, null);
            builder.SetMessage(Resource.String.MaxCountOfTag);
            builder.SetView(view);
            AlertDialog dialog = builder.Create();
            WlUtility.AddEventToEachView(dialog, this);
            return dialog;
        }


        public void rdogSelectshape_CheckedChange(object sender, CheckedChangeEventArgs e)
        {
            int position = 0;
            Android.Views.View view = (sender as RadioGroup).RootView;
            Color tagColor = TagColorCollection.Instance[position].WlColor;
            WlShape shape = TagColorCollection.Instance[position].Shape;
            IReadOnlyDictionary<int, WlShape> drawableDictionary = new Dictionary<int, WlShape>()
                                        {
                                            {Resource.Id.rdorect,WlShape.Square},
                                            {Resource.Id.rdostar,WlShape.Star},
                                            {Resource.Id.rdoheart,WlShape.Heart},
                                        };

            VectorDrawable drawable = Context.GetDrawable((int)drawableDictionary[e.CheckedId].Id) as VectorDrawable;
            drawable.Mutate();
            drawable.SetColorFilter(new BlendModeColorFilter(tagColor, BlendMode.Multiply));
            shape = drawableDictionary[e.CheckedId];
        }


        public void Sb_Red_Dialog_CreateNewTag_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SetSeekBar(sender, e);
        }

        public void Sb_Green_Dialog_CreateNewTag_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SetSeekBar(sender, e);
        }

        public void Sb_Blue_Dialog_CreateNewTag_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SetSeekBar(sender, e);
        }

        private void SetSeekBar(object sender, ProgressChangedEventArgs e)
        {
            Android.Views.View view = (sender as SeekBar).RootView;
            SeekBar[] seekBars = new SeekBar[]
            {
                view.FindViewById<SeekBar>(Resource.Id.Sb_Red_Dialog_CreateNewTag),
                view.FindViewById<SeekBar>(Resource.Id.Sb_Green_Dialog_CreateNewTag),
                view.FindViewById<SeekBar>(Resource.Id.Sb_Blue_Dialog_CreateNewTag)
            };

            const int colorValue = 255;
            int[] progressTintColor = new int[]
            {
                Convert.ToInt32(sender == seekBars[0]) * colorValue,
                Convert.ToInt32(sender == seekBars[1]) * colorValue,
                Convert.ToInt32(sender == seekBars[2]) * colorValue,
            };

            e.SeekBar.ProgressTintList = ColorStateList.ValueOf(Android.Graphics.Color.Argb(e.Progress, progressTintColor[0], progressTintColor[1], progressTintColor[2]));
            Color tagColor = Android.Graphics.Color.Rgb(seekBars[0].Progress, seekBars[1].Progress, seekBars[2].Progress);
            ImageView imageView = view.FindViewById<ImageView>(Resource.Id.ivDialog_CreateNewTag);
            VectorDrawable drawable = imageView.Drawable as VectorDrawable;
            drawable.Mutate();
            drawable.SetColorFilter(new BlendModeColorFilter(tagColor, BlendMode.Multiply));
        }
    }
}
