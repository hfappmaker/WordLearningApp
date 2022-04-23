﻿using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using WordLearning.Colors;
using WordLearning.Shape;
using static Android.Widget.RadioGroup;
using static Android.Widget.SeekBar;

namespace WordLearning.Dialog
{
    internal class ChangeThemeColorDialogBuilder : WlAlartDialogBuilder
    {
        public ChangeThemeColorDialogBuilder(Context context) : base(context)
        {
            Initialize(context);
        }

        private void Initialize(Context context)
        {
            LayoutInflater inflater = LayoutInflater.From(context);
            View view = inflater.Inflate(Resource.Layout.Dialog_Changethemecolor, null);
            SetMessage(Resource.String.ChangeThemeColor);
            SetView(view);
        }


        public void rdogSelectshape_CheckedChange(object sender, CheckedChangeEventArgs e)
        {
            View view = (sender as RadioGroup).RootView;
            Color tagColor = TagColorCollection.Instance[0].WlColor;
            WlShape shape = TagColorCollection.Instance[0].Shape;
            IReadOnlyDictionary<int, WlShape> drawableDictionary = new Dictionary<int, WlShape>()
                                        {
                                            {Resource.Id.rdorect,WlShape.Square},
                                            {Resource.Id.rdostar,WlShape.Star},
                                            {Resource.Id.rdoheart,WlShape.Heart},
                                        };

            VectorDrawable drawable = Context.GetDrawable((int)drawableDictionary[e.CheckedId]) as VectorDrawable;
            drawable.Mutate();
            drawable.SetColorFilter(new BlendModeColorFilter(tagColor, BlendMode.Multiply));
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
            View view = (sender as SeekBar).RootView;
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
